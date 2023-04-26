using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;

    Inventory inven;

    SlotUI[] slotUIs;
    //SlotUI tempSlotUI;

    PlayerInputActions inputActions;
    private void Awake()
    {
        Transform slotParent = transform.GetChild(0);
        slotUIs = slotParent.GetComponentsInChildren<SlotUI>();

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
    public void InitializeInventory(Inventory playerInven)
    {
        inven = playerInven;

        Transform slotParent = transform.GetChild(0);
        GridLayoutGroup layout = slotParent.GetComponent<GridLayoutGroup>();    
        if(Inventory.Default_Inventory_Size != inven.SlotCount)
        {

        }
    }
}
