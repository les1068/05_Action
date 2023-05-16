using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Minimap : Test_Base
{
    public CinemachineVirtualCamera vc;
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
    protected override void Test2(InputAction.CallbackContext _)
    {
        vc.gameObject.SetActive(true);
    }
    protected override void Test3(InputAction.CallbackContext _)
    {
        vc.gameObject.SetActive(false);
    }
}
