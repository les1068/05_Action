using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotUI : ItemSlotUI_Base, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    /// <summary>
    /// 드래그 시작을 알리는 델리게이트
    /// </summary>
    public Action<uint> onDragBegin;
    /// <summary>
    /// 드래그 종료를 알리는 델리게이트
    /// </summary>
    public Action<uint> onDragEnd;
    /// <summary>
    /// 슬롯이 클릭되었을 때 실행되는 델리게이트
    /// </summary>
    public Action<uint> onClick;

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
                onDragEnd?.Invoke(ID);
                Debug.Log("슬롯이 아닙니다. 원래 슬롯으로 되돌립니다.");
            }
        }
        else
        {
            Debug.Log("오브젝트가 없습니다.");
        }
    }

    /// <summary>
    /// 슬롯을 클릭했을 때 실행되는 함수.
    /// 임시 슬롯에 있는 아이템을 이 슬롯에 넣기 위한 용도
    /// (아이템 분리하기 위한 용도)
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke(ID);  // 클릭되어있다고 신호만 보내기
    }
}
