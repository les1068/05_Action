using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif
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

    PlayerController playerController;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerController.OnItemPickUp += OnItemPickUp;        // 아이템 줍는다는 신호가 들어오면 줍는 처리 실행
    }

    private void Start()
    {
        inven = new Inventory(this);    // SceneLoaded보다 나중에 실행되어야 해서 Awake에서 하면 안됨
        GameManager.Inst.InvenUI.InitializeInventory(inven);
    }

    /// <summary>
    /// 아이템 줍는 처리를 하는 함수
    /// </summary>
    private void OnItemPickUp()
    {
        // 일정 범위 안에 있는 아이템 찾고
        Collider[] items = Physics.OverlapSphere(transform.position, ItemPickupRange, LayerMask.GetMask("Item"));
        foreach (Collider itemCollider in items)
        {
            Item item = itemCollider.gameObject.GetComponent<Item>();
            if (inven.AddItem(item.ItemData.code))    // 하나씩 인벤토리에 추가하고
            {    
                Destroy(item.gameObject);             // 먹은 아이템 삭제하기
            }
        }
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
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        // 아이템 획득 반경 그리기
        Handles.DrawWireDisc(transform.position, Vector3.up, ItemPickupRange);
    }
#endif
}
