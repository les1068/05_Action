using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_ItemEquip : Test_Base
{
    Player player;
    private void Start()
    {
        player = GameManager.Inst.Player;
    }
    protected override void Test1(InputAction.CallbackContext _)
    {

        ItemFactory.MakeItem(ItemCode.IronSword);
    }
    protected override void Test2(InputAction.CallbackContext _)
    {
        player.Inventory.AddItem(ItemCode.IronSword);
    }
}
