using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Scriptable Object/Item Data - Shield", order = 7)]
public class ItemData_Shield : ItemData_Equip
{
    [Header("방패 데이터")]
    /// <summary>
    /// 방패의 방어력
    /// </summary>
    public float defancePower = 15.0f;

    /// <summary>
    /// 무기가 장착될 파츠
    /// </summary>
    public override EquipType EquipPart => EquipType.Shield;
    
}
