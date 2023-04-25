using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Inventory : Test_Base
{
    public ItemCode code = ItemCode.Ruby;
    public int index = 0;

    Inventory inventory;

    private void Start()
    {
        inventory = new Inventory(6);
    }

    protected override void Test1(InputAction.CallbackContext _)
    {
        uint temp = (uint)Mathf.Clamp(index, 0, inventory.SlotCount);
        inventory.AddItem(code, temp);
        inventory.PrintInventory();
    }

    protected override void Test2(InputAction.CallbackContext _)
    {
        uint temp = (uint)Mathf.Clamp(index, 0, inventory.SlotCount);
        inventory.RemoveItem(temp);
        inventory.PrintInventory();
    }

    protected override void Test3(InputAction.CallbackContext _)
    {
        uint temp = (uint)Mathf.Clamp(index, 0, inventory.SlotCount);
        inventory.ClearSlot(temp);
        inventory.PrintInventory();
    }

    protected override void Test5(InputAction.CallbackContext _)
    {
        inventory.ClearInventory();
        inventory.PrintInventory();
    }
}
