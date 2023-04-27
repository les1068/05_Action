using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotUI : ItemSlotUI_Base, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Action<uint> onDragBegin;
    public Action<uint> onDragEnd;

    /// <summary>
    /// 이 슬롯UI를 초기화 하는 함수
    /// </summary>
    /// <param name="id">이 슬롯 UI의 ID</param>
    /// <param name="slot">이 슬롯 UI가 보여줄 ItemSlot</param>
    public override void InitializeSlot(uint id, ItemSlot slot)
    {
        // 델리게이트에 이전 영향 제거하기
        onDragBegin = null;
        onDragEnd = null;
        
        base.InitializeSlot(id, slot);

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"드래그 시작: {ID}번 슬롯");
        onDragBegin?.Invoke(ID);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // OnBeginDrag와 OnEndDrag를 위해 추가한 것
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject obj = eventData.pointerCurrentRaycast.gameObject; // 드래그가 끝난 지점의 게임오브젝트 가져오고
        if (obj != null)
        {
            // 오브젝트가 있으면
            ItemSlotUI endSlot = obj.GetComponent<ItemSlotUI>();
            if (endSlot != null)  // 슬롯인지 확인
            {
                // 슬롯이면 델리게이트로 이 슬롯에서 드래그가 끝났음을 알림
                onDragEnd?.Invoke(endSlot.ID);
                Debug.Log($"드래그 종료: {endSlot.ID}번 슬롯");
            }
            else
            {
                Debug.Log("슬롯이 아닙니다.");
            }
        }
        else
        {
            Debug.Log("오브젝트가 없습니다.");
        }
    }
}
