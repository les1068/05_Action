using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 먹는 즉시 사용되는 아이템이 상속받을 인터페이스
interface IConsumable
{
    /// <summary>
    /// 아이템을 소비시키는 함수
    /// </summary>
    /// <param name="target">아이템의 효과를 받을 대상</param>
    void Consume(GameObject target);
}
// ItemData_Food
// - Ihealth를 상속받은 대상만 사용할 수 있다.
// - 체력이 리젠된다.(필요한 데이터는 멤버 변수로 추가한다.)
// ItemData_Drink
// - IMana를 상속받은 대상만 사용할 수 있다.
// - 마나가 리젠된다.(필요한 데이터는 멤버 변수로 추가한다.)
