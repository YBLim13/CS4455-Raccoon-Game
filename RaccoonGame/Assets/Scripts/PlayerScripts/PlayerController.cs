using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed = 5f;
    public float jumpHeight = 400f;
    public float turnSmoothTime = 0.1f;
    public float checkDist = 0.25f;
    float turnSmoothVelocity;

    private Rigidbody _rb;
    private CapsuleCollider _capsule;
    private Quaternion playerMovePosition;
    private Quaternion playerTurnPosition;
    private Vector3 _startPos;
    private Vector3 _endPos;
    private Vector3 moveDir;
    private Vector3 movePos;
    private Vector3 rawInputMovement;
    private PlayerInput inputSystem;
    private int _stunMultiplier = 1;
    private bool _stunned = false;
    private bool _frozen = false;
    private int _cutsceneLock = 0;
    private int _fadeLock = 1;
    private Animator anim;
    private bool _isGrounded;
    [Header("Camera")]
    public GameObject walkSound;
    public AudioSource eat;
    public AudioSource yelp;


    [Header("Camera")]
    public Transform cam;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _capsule = GetComponent<CapsuleCollider>();
        _stunMultiplier = 1;
        _cutsceneLock = 0;
        _fadeLock = 0;
        anim = GetComponentInChildren<Animator>();
        walkSound.SetActive(false);
        isDead = false;
    }

    void OnMove(InputValue value)
    {
        Vector2 inputMovement = value.Get<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    private void Update() {
        if (!CutsceneManager.Instance.isCutscene()) {
            _cutsceneLock = 1;
        }

        if (FadeManager.Instance.isFadeLocked()) {
            _fadeLock = 0;
        } else {
            _fadeLock = 1;
        }
    }

    void FixedUpdate()
    {
        MoveThePlayer();
        TurnThePlayer();

        Vector3 toSphereCenter = this.transform.forward * _capsule.height / 4;
        _startPos = this.transform.position + toSphereCenter;
        _endPos = this.transform.position + (-1 * toSphereCenter);

        _isGrounded = Physics.CapsuleCast(_startPos, _endPos, _capsule.radius, Vector3.down, checkDist) ||
                    Physics.Raycast(this.transform.position, Vector3.down, checkDist);

        SetWalkSound();
        SetAnimations();
    }

    void SetWalkSound()
    {
        if (rawInputMovement.magnitude * _stunMultiplier * _cutsceneLock * _fadeLock > 0.1 && _isGrounded)
        {
            walkSound.SetActive(true);
        }
        else
        {
            walkSound.SetActive(false);
        }
    }

    void SetAnimations()
    {
        anim.SetFloat("inputTurn", rawInputMovement.magnitude * _stunMultiplier * _cutsceneLock * _fadeLock);
        anim.SetFloat("inputForward", rawInputMovement.magnitude * _stunMultiplier * _cutsceneLock * _fadeLock);
        anim.SetBool("stunned", _frozen);
        anim.SetBool("isDead", isDead);
    }

    void MoveThePlayer()
    {
        movePos = moveDir.normalized * speed * Time.deltaTime * _stunMultiplier * _cutsceneLock * _fadeLock;
        _rb.MovePosition(transform.position + movePos);
    }

    void TurnThePlayer()
    {
        Vector3 direction = rawInputMovement.normalized * _stunMultiplier * _cutsceneLock * _fadeLock;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime) * _stunMultiplier * _cutsceneLock;

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _rb.MoveRotation(Quaternion.Euler(0f, angle, 0f));
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }


    void OnJump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(new Vector3(0, jumpHeight * _stunMultiplier * _cutsceneLock * _fadeLock, 0), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if (!_stunned && obj.tag == "Enemy")
        {
            yelp.Play();
            this.gameObject.layer = 12;              // Player so that enemy passes right through after hit
            InventoryManager.Instance.SubHealth();
            if (InventoryManager.Instance.healthCount == 0)
            {
                isDead = true;
                _stunMultiplier = 0;
            }
            else
            {
                StartCoroutine(Stun());
            }

        }
        if (other.gameObject.CompareTag("Food"))
        {
            other.gameObject.SetActive(false);
            InventoryManager.Instance.AddHealth();
            eat.Play();
            //InventoryManager.Instance.AddFood();
        }
    }


    IEnumerator Stun()
    {
        _stunMultiplier = 0;                // Freezes movement for a little bit
        GameObject child = this.transform.GetChild(0).gameObject;
        SkinnedMeshRenderer mesh = child.GetComponent<SkinnedMeshRenderer>();
        _stunned = true;
        _frozen = true;

        for (int i = 0; i < 12; i++)
        {
            mesh.enabled = !mesh.enabled;

            if (i == 6)
            {
                _stunMultiplier = 1;        // Allows for player to get away before enemy gets dangerous again
                _frozen = false;
            }

            yield return new WaitForSeconds(0.25f);
        }
        this.gameObject.layer = 9;                    // Layer back to default
        _stunned = false;
    }

    public bool isStunned() {
        return _stunned;
    }
}
