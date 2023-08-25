using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingSystem : MonoBehaviour
{
    public float speed;
    private float _waitTime;
    public float startWaitTime;

    public List<Transform> patrolPoints = new();
    private int _randomPoint;

    private void Start()
    {
        _waitTime = startWaitTime;
        _randomPoint = Random.Range(0, patrolPoints.Count);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[_randomPoint].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[_randomPoint].position) < 0.2f)
        {
            GenerateNewPoint();
        }
    }

    private void GenerateNewPoint()
    {
        if (_waitTime <= 0)
        {
            _randomPoint = Random.Range(0, patrolPoints.Count);
            _waitTime = startWaitTime;
        }
        else
        {
            _waitTime -= Time.deltaTime;
        }
    }
}
