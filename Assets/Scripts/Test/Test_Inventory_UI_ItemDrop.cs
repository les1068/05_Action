using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Inventory_UI_ItemDrop : Test_Base
{
    public uint invenSize = Inventory.Default_Inventory_Size;
    public InventoryUI inventoryUI;
    Inventory inventory;


    private void Start()
    {
        inventory = new Inventory(invenSize);
        inventoryUI.InitializeInventory(inventory);
        inventory.AddItem(ItemCode.Ruby);
        inventory.AddItem(ItemCode.Ruby);
        inventory.AddItem(ItemCode.Ruby, 1);
        inventory.AddItem(ItemCode.Emerald, 2);
        inventory.AddItem(ItemCode.Emerald, 2);
        inventory.AddItem(ItemCode.Emerald, 2);
        inventory.AddItem(ItemCode.Emerald, 2);
        inventory.AddItem(ItemCode.Emerald, 2);
        inventory.AddItem(ItemCode.Emerald, 2);
        inventory.AddItem(ItemCode.Emerald, 2);
        inventory.AddItem(ItemCode.Emerald, 2);

        inventory.AddItem(ItemCode.Emerald, 3);
        inventory.AddItem(ItemCode.Emerald, 3);
        inventory.AddItem(ItemCode.Emerald, 3);
        inventory.AddItem(ItemCode.Emerald, 3);

        inventory.AddItem(ItemCode.Sapphire, 5);
        inventory.AddItem(ItemCode.Sapphire, 5);
    }
}
