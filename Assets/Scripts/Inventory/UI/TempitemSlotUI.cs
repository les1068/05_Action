using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TempitemSlotUI : ItemSlotUI_Base
{
    /// <summary>
    /// 임시 슬롯이 열리거나 닫힐 때 실행되는 델리게이트. (true면 열렸다. false면 닫혔다.)
    /// </summary>
    public Action<bool> onTempSlotOpenClose;

    private void Update()
    {
        // 활성화 되어있을 때 매 프레임마다 호출
        transform.position = Mouse.current.position.ReadValue(); // 마우스 위치로 오브젝트 옮기기
    }

    public override void InitializeSlot(uint id, ItemSlot slot)
    {
        onTempSlotOpenClose = null;

        base.InitializeSlot(id, slot);
    }

    /// <summary>
    /// TempSlot이 보이게 하는 함수
    /// </summary>
    public void Open()
    {
        transform.position = Mouse.current.position.ReadValue();  // 우선 위치를 마우스 위치로 옮기고
        onTempSlotOpenClose?.Invoke(true);                        // 열렸다고 알리기
        gameObject.SetActive(true);                               // 활성화 시켜서 보이게 만들기
    }

    /// <summary>
    /// TempSlot이 보이지 않게 하는 함수
    /// </summary>
    public void Close()
    {
        onTempSlotOpenClose?.Invoke(false);   // 닫혔다고 알리기
        gameObject.SetActive(false);          // 비활성화 시켜서 보이지 않게 만들고 Updata도 실행안되게 하기
    }

    /// <summary>
    /// 바닥에 아이템을 드랍하는 함수
    /// </summary>
    /// <param name="screenPos">마우스 커서의 스크린 좌표</param>
    public void OnDrop(Vector2 screenPos)
    {
        if (!ItemSlot.IsEmpty)
        {
            Debug.Log($"아이템 드랍 : {ItemSlot.ItemData.itemName},{ItemSlot.ItemCount}");
        }
    }
}
