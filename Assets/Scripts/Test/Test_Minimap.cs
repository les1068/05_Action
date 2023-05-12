using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Minimap : Test_Base
{
    private void Start()
    {
        ItemFactory.MakeItem(ItemCode.Ruby, 10);
        GameObject obj = ItemFactory.MakeItem(ItemCode.Emerald);
        obj.transform.position = new Vector3(5, 0, 0);
        obj = ItemFactory.MakeItem(ItemCode.Emerald);
        obj.transform.position = new Vector3(-5, 0, 0);
        obj = ItemFactory.MakeItem(ItemCode.Emerald);
        obj.transform.position = new Vector3(5, 0, 5);
        obj = ItemFactory.MakeItem(ItemCode.Emerald);
        obj.transform.position = new Vector3(-5, 0, -5);
        obj = ItemFactory.MakeItem(ItemCode.Emerald);
    }
    protected override void Test1(InputAction.CallbackContext _)
    {
        GameManager.Inst.Player.Die();
    }
}
