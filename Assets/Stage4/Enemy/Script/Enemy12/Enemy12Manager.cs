using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//NavMesh���g�p���āA�^�[�Q�b�g��ǂ�������X�N���v�g
public class Enemy12Manager : MonoBehaviour
{
    NavMeshAgent agent;

    Animator animator;

    [SerializeField] Transform tartget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        agent.destination = tartget.position;
        animator.SetFloat("distance" , agent.remainingDistance);
    }
}
