using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleSelector : StateMachineBehaviour
{
    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("IdleSelect", RandomSelect());
    }
    int RandomSelect()
    {
        // 0 ~ 4중에서 랜덤으로 숫자를 골라 리턴
        // 각 번호별로 확률이 달라야 한다.
        // 0 : 70
        // 1 : 10
        // 2 : 7
        // 3 : 7
        // 3 : 6
        return -1;
    }

}
