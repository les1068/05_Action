using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData_Equip : ItemData, IEquipable
{
    [Header("장비 아이템 데이터")]
    /// <summary>
    /// 아이템을 장비했을 때 보일 오브젝트의 프리팹
    /// </summary>
    public GameObject equipPrefab;

    /// <summary>
    /// 장착될 위치를 알려주는 프로퍼티
    /// </summary>
    public EquipType EquipPart { get; }


    public void EquipItem(GameObject target, ItemSlot slot)
    {
        if (target != null)
        {
            IEquipTarget equipTarget = target.GetComponent<IEquipTarget>();
            if (equipTarget != null)
            {
                equipTarget.EquipItem(EquipPart, slot);
            }
        }
    }

    public void UnEquipItem(GameObject target, ItemSlot slot)
    {
        if (target != null)
        {
            IEquipTarget equipTarget = target.GetComponent<IEquipTarget>();
            if (equipTarget != null)
            {
                equipTarget.UnEquipItem(EquipPart);
            }
        }
    }
    public void AutoEquipUnequip(GameObject target, ItemSlot slot)
    {
        if (target != null)
        {
            IEquipTarget equipTarget = target.GetComponent<IEquipTarget>();
            if (equipTarget != null)
            {
                if (equipTarget[EquipPart])    // 이 아이템과 같은 종류가 장착되어있는지 확인
                {
                    UnEquipItem(target, slot);  // 그 부위가 장착 중이면 일단 해제
                }
                EquipItem(target, slot);        // 해당 파츠 장착하기
            }
        }
    }
}
