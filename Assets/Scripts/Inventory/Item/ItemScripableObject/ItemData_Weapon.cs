using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Scriptable Object/Item Data - Weapon", order = 6)]
public class ItemData_Weapon : ItemData_Equip
{
    [Header("무기 데이터")]
    /// <summary>
    /// 무기의 공격력
    /// </summary>
    public float attackPower = 30.0f;

    /// <summary>
    /// 무기ㅣ가 장착될 파츠
    /// </summary>
    public override EquipType EquipPart => EquipType.Weapon;
    
}
