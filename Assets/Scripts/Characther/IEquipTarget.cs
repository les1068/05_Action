using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEquipTarget
{
    /// <summary>
    /// 특정 파츠에 아이템이 장비되었는지를 알려주는 인덱서
    /// </summary>
    /// <param name="part">확인할 파츠</param>
    /// <returns>장비되어있으면 true, 아니면 false</returns>
    bool this[EquipType part] { get; }

    /// <summary>
    /// 아이템을 장비하는 함수
    /// </summary>
    /// <param name="part">장비할 파츠</param>
    /// <param name="slot">장비할 아이템이 들어있는 슬롯</param>
    void EquipItem(EquipType part, ItemSlot slot);

    /// <summary>
    /// 아이템을 장비 해제하는 함수
    /// </summary>
    /// <param name="part">장비해제 할 파츠</param>
    void UnEquipItem(EquipType part);
}
