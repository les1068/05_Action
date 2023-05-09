using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item Data", menuName = "Scriptable Object/Item Data - ManaPotion", order = 5)]
public class ItemData_ManaPotion : ItemData, IUsable
{
    [Header("마나 포션 데이터")]

    /// <summary>
    /// 전체 회복량
    /// </summary>
    public float totalRegne = 30.0f;
    /// <summary>
    /// 전체 회복하는데 걸리는 시간
    /// </summary>
    public float duration = 3.0f;
    public bool Use(GameObject target)
    {
        bool result = false;
        if (target != null)
        {
            IMana mana = target.GetComponent<IMana>();
            if(mana != null)
            {
                mana.ManaRegenerate(totalRegne, duration);
                Debug.Log($"{target.name}의 HP가 {duration}만큼 증가해서 {totalRegne}가 되었습니다.");
                result = true;
            }
        }
        return result;
    }
}
