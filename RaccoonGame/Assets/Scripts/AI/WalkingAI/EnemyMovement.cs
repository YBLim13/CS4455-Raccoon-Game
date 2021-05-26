using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class EnemyMovement : MonoBehaviour
{

    public enum AIState
    {
        pursue,
        patrol,
        gohome,
        idle
    }

    // Set to player gameobject
    public GameObject player;

    // Set up waypoints here for the patrol route, or just one if you want to idle somewhere
    public GameObject[] waypoints;
    public AudioClip alert;
    public AudioClip lost;
    public AudioClip caught;

    public GameObject walkControl;
    public GameObject runControl;

    // spin tells the AI whether or not to spin in place when in the idle state
    public bool spin;
    private float rotationSpeed = 1.0f;

    private Animator anim;

    private int currWaypoint = -1;

    private NavMeshAgent agent;

    private AIState currentState;

    private Vector3 currLocation;

    private AudioSource sounds;
    private SphereCollider visionCollider;
    private PlayerController _playerController;

    private bool rotating;
    private bool spinNow;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        visionCollider = gameObject.GetComponent<SphereCollider>();
        sounds = gameObject.GetComponent<AudioSource>();
        _playerController = player.GetComponent<PlayerController>();

        setAnim("patrol");
        walkSound();
        currentState = AIState.patrol;
        agent.SetDestination(transform.position);
        currLocation = gameObject.transform.position;
        rotating = false;
        SetNextWaypoint();
    }

    void Update()
    {
        if (currentState == AIState.pursue)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
            if (agent.remainingDistance <= 0.25f && agent.pathPending == false) // if enemy touches player
            {
                StartCoroutine(pauseVision());
                setAnim("patrol");
                walkSound();
                currentState = AIState.gohome;
            }
        }
        else if (currentState == AIState.gohome)
        {
            agent.SetDestination(currLocation);
            if (agent.remainingDistance <= .5f && agent.pathPending == false)
            {
                if (waypoints.Length < 2)
                {
                    setAnim("idle");
                    stopSound();
                    currentState = AIState.idle;
                } else
                {
                    setAnim("patrol");
                    walkSound();
                    currentState = AIState.patrol;
                }
            }
        } 
        else if (currentState == AIState.idle)
        {
            if (!rotating && spin)
            {
                rotating = true;
                StartCoroutine(turnAround());
            }
            if (spinNow)
            {
                transform.Rotate(new Vector3(0, 180, 0) * (rotationSpeed * Time.deltaTime));
            }
            agent.isStopped = true;
        }
        else if (currentState == AIState.patrol && waypoints.Length != 0)
        {
            if (waypoints.Length < 2)
            {
                if (agent.remainingDistance <= 0.25f && agent.pathPending == false)
                {
                    setAnim("idle");
                    stopSound();
                    currentState = AIState.idle;
                }
            }
            else
            {
                if (agent.remainingDistance <= 0.25f && agent.pathPending == false)
                {
                    SetNextWaypoint();
                }
                agent.SetDestination(waypoints[currWaypoint].transform.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            setAnim("pursue");
            runSound();
            currentState = AIState.pursue;
            currLocation = transform.position;
            spinNow = false;
            rotating = false;
            sounds.PlayOneShot(alert, 0.1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            setAnim("patrol");
            walkSound();
            currentState = AIState.gohome;

            if (_playerController.isStunned()) {
                sounds.PlayOneShot(caught, 0.1f);
            } else {
                sounds.PlayOneShot(lost, 0.1f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other == player)
        {
            StartCoroutine(pauseVision());
            setAnim("patrol");
            walkSound();
            currentState = AIState.gohome;
            sounds.PlayOneShot(caught, 0.1f);
        }
    }

    // SetNextWaypoint() sets the next waypoint for the AI to walk to
    private void SetNextWaypoint()
    {
        if (currWaypoint < waypoints.Length - 1)
        {
            currWaypoint++;
            agent.SetDestination(waypoints[currWaypoint].transform.position);
        } else if (waypoints.Length != 0)
        {
            currWaypoint = 0;
            agent.SetDestination(waypoints[currWaypoint].transform.position);
        }
    }

    // pauseVision tells the AI to deactivate the vision cone
    private IEnumerator pauseVision()
    {
        visionCollider.enabled = false;
        yield return new WaitForSeconds(3);
        visionCollider.enabled = true;
    }

    // turnAround() turns the AI around in place
    private IEnumerator turnAround()
    {
        yield return new WaitForSeconds(4);
        spinNow = true;
        yield return new WaitForSeconds(1);
        spinNow = false;
        rotating = false;
    }

    // setAnim(string state) sets the parameters for the animation controller
    private void setAnim(string state)
    {
        anim.SetBool("pursue", false);
        anim.SetBool("idle", false);
        anim.SetBool("patrol", false);

        anim.SetBool(state, true);
    }

    // controls walking footsteps
    private void walkSound()
    {
        walkControl.GetComponent<EnemyWalkFootstepControl>().play();
        runControl.GetComponent<EnemyRunFootstepControl>().pause();
    }

    // controls run footsteps
    private void runSound()
    {
        walkControl.GetComponent<EnemyWalkFootstepControl>().pause();
        runControl.GetComponent<EnemyRunFootstepControl>().play();
    }

    // stops all footsteps
    private void stopSound()
    {
        walkControl.GetComponent<EnemyWalkFootstepControl>().pause();
        runControl.GetComponent<EnemyRunFootstepControl>().pause();
    }
}
