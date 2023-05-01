using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Inventory_ItemDrop : Test_Base
{
    protected override void Test1(InputAction.CallbackContext _)
    {
        GameObject obj = ItemFactory.MakeItem(ItemCode.Ruby);
        obj.transform.position = Vector3.right * 1;
    }
    protected override void Test2(InputAction.CallbackContext _)
    {
        GameObject obj = ItemFactory.MakeItem(ItemCode.Emerald);
        obj.transform.position = Vector3.right * 2;
    }
    protected override void Test3(InputAction.CallbackContext _)
    {
        GameObject obj = ItemFactory.MakeItem(ItemCode.Sapphire);
        obj.transform.position = Vector3.right * 3;
    }

}
