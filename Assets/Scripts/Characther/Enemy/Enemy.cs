using System;
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
    EnemyState state = EnemyState.Patrol;
    EnemyState State
    {
        get => state;
        set
        {
            if (state != value)
            {
                state = value;
                switch (state)
                {
                    case EnemyState.Wait:
                        agent.isStopped = true;
                        agent.velocity = Vector3.zero;
                        WaitTimer = waitDuration + UnityEngine.Random.Range(0.0f, 0.5f);
                        anim.SetTrigger("Stop");
                        StateUpdata = Update_Wait;
                        break;

                    case EnemyState.Patrol:
                        agent.isStopped = false;
                        agent.SetDestination(moveTarget.position);
                        anim.SetTrigger("Move");
                        StateUpdata = Updata_Patrol;
                        break;

                    case EnemyState.Chase:
                        
                        break;

                    case EnemyState.Attack:
                        break;

                    case EnemyState.Die:
                        break;
                }
            }
        }
    }
    Action StateUpdata = null;


    // 순찰 관련 데이터 --------------------------------

    /// <summary>
    /// 순찰할 웨이포인트 모음
    /// </summary>
    public Waypoints waypoints;

    /// <summary>
    /// 지금 이동할 목적지
    /// </summary>
    Transform moveTarget;

    // 대기 관련 데이터 --------------------------------

    /// <summary>
    /// 목적지에 도달하면 기다리는 시간
    /// </summary>
    public float waitDuration = 1.0f;

    /// <summary>
    /// 실제로 기다린 시간
    /// </summary>
    float waitTimer = 0.0f;
    float WaitTimer
    {
        get => waitTimer;
        set
        {
            waitTimer = value;
            if (waypoints != null && waitTimer < 0.0f)
            {
                State = EnemyState.Patrol;
            }
        }
    }

    // 컴포넌트 ---------------------------------------

    NavMeshAgent agent;
    Animator anim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        Waypoints defaultWaypoints = GetComponentInChildren<Waypoints>();
        defaultWaypoints.transform.SetParent(null);
        if (waypoints == null)
        {
            waypoints = defaultWaypoints;
        }
    }

    private void Start()
    {
        moveTarget = waypoints.Current;
        State = EnemyState.Wait;
        anim.ResetTrigger("Stop");
    }
    private void Update()
    {
        StateUpdata();

    }
    void Updata_Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            moveTarget = waypoints.Next();
            State = EnemyState.Wait;
        }
    }
    void Update_Wait()
    {
        WaitTimer -= Time.deltaTime;
    }
}
