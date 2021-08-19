using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _player;
    public float _radius = 1;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = _player.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;
        if (distanceToTarget <= _radius)
        {
            _agent.SetDestination(_player.transform.position);
        }
        else
        {
            _agent.SetDestination(_startPosition);
        }

    }
}
