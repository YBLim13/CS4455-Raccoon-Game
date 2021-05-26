using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class ThrowBall : MonoBehaviour
{

    private Animator anim;
    private AudioSource sound;

    public GameObject dodgeball;
    private GameObject player;
    public int delay = 5;

    private bool inRange;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        inRange = false;
        StartCoroutine(MakeBall());
    }

    private void Update()
    {
        Vector3 playerDirection = Vector3.RotateTowards(transform.forward, player.transform.position - transform.position, 5 * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(playerDirection);
    }

    IEnumerator MakeBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            if (inRange)
            {
                anim.SetBool("throwing", true);
                yield return new WaitForSeconds(0.5f);
                sound.Play();
                yield return new WaitForSeconds(0.5f);

                Instantiate(dodgeball, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), Quaternion.identity);
                yield return new WaitForSeconds(0.25f);
                anim.SetBool("throwing", false);
                sound.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
