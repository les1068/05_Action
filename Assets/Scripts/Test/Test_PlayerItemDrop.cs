using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_PlayerItemDrop : Test_Base
{

    private void Start()
    {
        Player player = GameManager.Inst.Player;

        player.Test_AddItem(ItemCode.Ruby, 3);
        player.Test_AddItem(ItemCode.Emerald, 8);
        player.Test_AddItem(ItemCode.Sapphire, 3);
    }
    protected override void Test1(InputAction.CallbackContext _)
    {
        ItemFactory.MakeItem(ItemCode.CopperCoin);
    }
    protected override void Test2(InputAction.CallbackContext _)
    {
        ItemFactory.MakeItem(ItemCode.SilverCoin);
    }
    protected override void Test3(InputAction.CallbackContext _)
    {
        ItemFactory.MakeItem(ItemCode.GoldCoin);
    }
}
