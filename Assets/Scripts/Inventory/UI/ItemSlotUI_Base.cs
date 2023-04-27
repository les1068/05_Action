using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemSlotUI_Base : MonoBehaviour
{
    uint id;
    public uint ID => id;

    ItemSlot itemSlot;
    public ItemSlot ItemSlot => itemSlot;
    Image ItemImage;
    TextMeshProUGUI itemCount;
    private void Awake()
    {
        Transform child = transform.GetChild(0);
        ItemImage =  child.GetComponent<Image>();
        child = transform.GetChild(1);
        itemCount = child.GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// 슬롯 초기화용 함수
    /// </summary>
    /// <param name="id">슬롯 인덱스. 슬롯 ID의 역할도 함</param>
    /// <param name="slot">이 UI가 보여줄 슬롯</param>
    public void InitializeSlot(uint id, ItemSlot slot)
    {
        //Debug.Log($"{id}슬롯 초기화");
        this.id = id;   // 값 성정
        itemSlot = slot;
        itemSlot.onSlotItemChange = Refresh;  // 슬롯에 들어있는 아이템이 변경되었을 때 실행될 함수 등록

        Refresh();      // 보이는 모습 초기화
    }

    /// <summary>
    /// 슬롯의 보이는 모습 갱신용 함수
    /// itemSlot에 들어있는 아이템이 변경될 때마다 실행.
    /// </summary>
    private void Refresh()
    {
        if(itemSlot.IsEmpty)
        {
            // 슬롯에 아이템이 들어있지 않을때
            ItemImage.sprite = null;       // 이미지 제거하고
            ItemImage.color = Color.clear; // 투명하게 만들고
            itemCount.text = string.Empty; // 갯수도 비우고
        }
        else
        {
            ItemImage.sprite = itemSlot.ItemData.itemIcon;  // 이미지 설정하고
            ItemImage.color = Color.white;                 // 불투명하게 만들고
            itemCount.text=itemSlot.ItemCount.ToString();  // 갯수 글자로 넣기
        }
    }
}
