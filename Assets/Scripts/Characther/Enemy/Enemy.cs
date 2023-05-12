using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // 순찰
    // - 정해진 웨이포인트 지점을 반복해서 이동
    // - 웨이포인트 지점에 도착하면 일정시간 정지

    // 추적
    // - 순찰 중에 플레이어 발견하면 추적
    // - 시야 범위에서 플레이어가 벗어나면 다시 순찰

    // 공격
    // - 플레이어가 공격 범위안에 들어오면 공격 시작

    // 사망
    // - 플레이어에게 일정 이상 대미지를 입으면 사망
    // - 사망하면 파티클 이팩트 재생

    protected enum EnemyState
    {
        Wait = 0,  // 대기 상태
        Patrol,    // 순찰 상태
        Chase,     // 추적 상태
        Attack,    // 공격 상태
        Die        // 죽은 상태
    }
    EnemyState state = EnemyState.Wait;

    public Waypoints waypoints;

    Transform moveTarget;

    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        waypoints = GetComponentInChildren<Waypoints>();
        waypoints.transform.SetParent(null);
    }
    private void Start()
    {
        moveTarget = waypoints.Current;
    }
    private void Update()
    {
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            moveTarget = waypoints.Next();
            agent.SetDestination(moveTarget.position);  
        }
    }
}
