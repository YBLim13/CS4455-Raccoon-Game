using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CarAI : MonoBehaviour
{
    public GameObject[] waypoints;
    public float threshold = 0.0f;       // Allows for dynamic changing of remainingDistance requirement, might not always be on exact spot

    [SerializeField]
    private NavMeshAgent _navMeshAgent;
    [SerializeField]
    private Vector3 _startPos;
    [SerializeField]
    private Quaternion _startRot;
    private int _currWaypoint = -1;

    private void Awake() {
        _startPos = this.transform.position;
        _startRot = this.transform.rotation;
    }

    private void OnEnable() {
        setNextWaypoint();
    }

    private void OnDisable() {
        this.transform.position = _startPos;
        this.transform.rotation = _startRot;
        _currWaypoint = -1;
    }

    void Update()
    {
        if (_navMeshAgent.remainingDistance <= threshold && !_navMeshAgent.pathPending) {
            setNextWaypoint();
        }
    }

    private void setNextWaypoint()
    {
        int length = waypoints.Length;
        if (length == 0) {
            Debug.LogError("There are no waypoints; returning...");
            return;
        }

        _currWaypoint = (_currWaypoint + 1) % length;
        _navMeshAgent.SetDestination(waypoints[_currWaypoint].transform.position);
    }
}
