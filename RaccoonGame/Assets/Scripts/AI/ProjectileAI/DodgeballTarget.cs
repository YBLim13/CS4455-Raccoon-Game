using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeballTarget : MonoBehaviour
{
    // Start is called before the first frame update
    // when instantiated, grab velocity of player and calculate time to get there
    // in update, do the movement towards the player based on the velocity

    GameObject player;

    public float throwSpeed;
    private Vector3 predictedLocation;

    private Vector3 oldLocation;

    Vector3 playerVelocity;
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerVelocity = player.GetComponent<VelocityReport>().playerVelocity;
        Vector3 playerPos = player.transform.position;
        oldLocation = transform.position;
        float timeToReach = Vector3.Distance(playerPos, transform.position) / throwSpeed;

        predictedLocation = player.transform.position + new Vector3(playerVelocity.x * timeToReach, (playerVelocity.y * timeToReach) + 1f, playerVelocity.z * timeToReach);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, predictedLocation, throwSpeed * Time.deltaTime);
        if (transform.position == oldLocation)
        {
            Destroy(this.gameObject);
        } else
        {
            oldLocation = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
