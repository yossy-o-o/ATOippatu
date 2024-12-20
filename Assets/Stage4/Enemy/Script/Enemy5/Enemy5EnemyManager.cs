using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//PlayerÇí«ê’Ç∑ÇÈ
public class Enemy5EnemyManager : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }
}
