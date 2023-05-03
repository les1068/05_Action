using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 이 플레이어가 가지고 있을 인벤토리
    /// </summary>
    Inventory inven;

    /// <summary>
    /// 아이템을 줏을 수 있는 거리
    /// </summary>
    public float ItemPickupRange = 2.0f;

    private void Start()
    {
        inven = new Inventory(this);    // SceneLoaded보다 나중에 실행되어야 해서 Awake에서 하면 안됨
        GameManager.Inst.InvenUI.InitializeInventory(inven);
    }

    /// <summary>
    /// 테스트용
    /// </summary>
    /// <param name="code">추가할 아이템 종류</param>
    /// <param name="count">추가할 갯수</param>
    public void Test_AddItem(ItemCode code, uint count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            inven.AddItem(code);
        }
    }
}
