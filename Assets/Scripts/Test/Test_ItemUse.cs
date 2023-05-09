using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_ItemUse : Test_Base
{
    Player player;

    private void Start()
    {
        player = GameManager.Inst.Player;
        player.HP = 10;
    }
    protected override void Test1(InputAction.CallbackContext _)
    {
        player.Inventory.AddItem(ItemCode.HealingPotion);
        player.Inventory.AddItem(ItemCode.HealingPotion);
        player.Inventory.AddItem(ItemCode.HealingPotion);
    }
    protected override void Test2(InputAction.CallbackContext _)
    {
        ItemFactory.MakeItem(ItemCode.HealingPotion);
    }
    protected override void Test3(InputAction.CallbackContext _)
    {
        player.HP = 10;
    }
}
