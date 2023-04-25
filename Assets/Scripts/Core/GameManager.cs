using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    ItemDataManager itemDataManager;
    public ItemDataManager ItemData => itemDataManager;

    protected override void PreInitialize()
    {
        base.PreInitialize();
        itemDataManager = GetComponent<ItemDataManager>();
    }
}
