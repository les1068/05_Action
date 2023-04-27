using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TempitemSlotUI : ItemSlotUI_Base
{
    private void Update()
    {
        // 활성화 되어있을 때 매 프레임마다 호출
        transform.position = Mouse.current.position.ReadValue(); // 마우스 위치로 오브젝트 옮기기
    }
    /*public override void InitializeSlot(uint id, ItemSlot slot)
    {
        base.InitializeSlot(id, slot);
    }*/

    /// <summary>
    /// TempSlot이 보이게 하는 함수
    /// </summary>
    public void Open()
    {
        transform.position = Mouse.current.position.ReadValue();  // 우선 위치를 마우스 위치로 옮기고
        gameObject.SetActive(true);                               // 활성화 시켜서 보이게 만들기
    }

    /// <summary>
    /// TempSlot이 보이지 않게 하는 함수
    /// </summary>
    public void Close()
    {
        gameObject.SetActive(false);          // 비활성화 시켜서 보이지 않게 만들고 Updata도 실행안되게 하기
    }   
}
