using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;

    Inventory inven;

    ItemSlotUI[] slotUIs;
    //SlotUI tempSlotUI;

    PlayerInputActions inputActions;
    private void Awake()
    {
        Transform slotParent = transform.GetChild(0);
        slotUIs = slotParent.GetComponentsInChildren<ItemSlotUI>();

        //tempSlotUI
        inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        inputActions.UI.Enable();
    }
    private void OnDisable()
    {
        inputActions.UI.Disable();
    }

    /// <summary>
    /// 인벤토리 UI 초기화
    /// </summary>
    /// <param name="playerInven">이 UI가 표시할 인벤토리</param>
    public void InitializeInventory(Inventory playerInven)
    {
        inven = playerInven;

        Transform slotParent = transform.GetChild(0);
        GridLayoutGroup layout = slotParent.GetComponent<GridLayoutGroup>();
        if (Inventory.Default_Inventory_Size != inven.SlotCount)
        {
            // 기본 크기와 달라졌을 때

            // 미리 만들어져 있던 슬롯 모두 삭제
            foreach (var slot in slotUIs)
            {
                Destroy(slot.gameObject);
            }
            // 셀 크기 계산하기
            RectTransform rect = (RectTransform)slotParent;
            float totalArea = rect.rect.height * rect.rect.width;  // 부모 영역의 전체 넓이
            float slotArea = totalArea / inven.SlotCount;          // 슬롯 하나가 가질 수 있는 넓이
            float slotSideLength = Mathf.Floor(Mathf.Sqrt(slotArea)) - layout.spacing.x; // 슬롯 한변의 길이
            layout.cellSize = new Vector2(slotSideLength, slotSideLength);  // 구한 길이로 적용하기

            // 슬롯 새로 만들기
            slotUIs = new ItemSlotUI[inven.SlotCount];
            for (uint i = 0; i < inven.SlotCount; i++)
            {
                GameObject obj = Instantiate(slotPrefab, slotParent);  // 생성하고
                obj.name = $"{slotPrefab.name}_{i}";                   // 이름 붙이고
                slotUIs[i] = obj.GetComponent<ItemSlotUI>();           // 저장해 놓기
            }
        }
        // 슬롯의 초기화 작업
        for(uint i=0; i < inven.SlotCount; i++)
        {
            slotUIs[i].InitializeSlot(i, inven[i]);
        }
            
    }
}
