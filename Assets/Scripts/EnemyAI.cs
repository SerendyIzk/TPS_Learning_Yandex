using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> PatrolPoints;

    public PlayerController Player;

    public float ViewAngle;

    private bool _isPlayerNoticed;

    private NavMeshAgent _navMeshAgent;

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0 && !_isPlayerNoticed) PickNewPatrolPoint();
    }

    private void CheckViewToPlayerUpdate()
    {
        _isPlayerNoticed = false;
        var direction = Player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) <= ViewAngle)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void ChasePlayerUpdate()
    {
        if (_isPlayerNoticed) _navMeshAgent.destination = Player.transform.position;
    }

    void Start()
    {
        InitComponentLinks();

        PickNewPatrolPoint();
    }

    void Update()
    {
        CheckViewToPlayerUpdate();
        PatrolUpdate();
        ChasePlayerUpdate();
    }
}
