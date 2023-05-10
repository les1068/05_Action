using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Minimap : Test_Base
{
    private void Start()
    {
        ItemFactory.MakeItem(ItemCode.Ruby, 10);
    }
    protected override void Test1(InputAction.CallbackContext _)
    {
        ItemFactory.MakeItem(ItemCode.Ruby, 10);

    }
}
