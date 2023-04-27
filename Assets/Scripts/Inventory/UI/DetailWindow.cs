using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailWindow : MonoBehaviour
{
    bool isPause = false;
    public bool IsPause
    {
        get => isPause;
        set
        {
            isPause = value;
            if (isPause)
            {
                Close();
            }
        }
    }

    Image itemIcon;
    TextMeshProUGUI itemName;
    TextMeshProUGUI itemPrice;
    TextMeshProUGUI itemdescription;

    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Transform child = transform.GetChild(0);
        itemIcon = child.GetComponent<Image>();
        child = transform.GetChild(1);
        itemName = child.GetComponent<TextMeshProUGUI>();
        child = transform.GetChild(2);
        itemPrice = child.GetComponent<TextMeshProUGUI>();
        child = transform.GetChild(3);
        itemdescription = child.GetComponent <TextMeshProUGUI>();

    }
    public void Open(ItemData data)
    {
        if(!IsPause&&data !=null)
        {
            itemIcon.sprite = data.itemIcon;
            itemName.text = data.itemName;
            itemPrice.text = data.price.ToString();
            itemdescription.text = data.itemDescription;

            canvasGroup.alpha = 1;
        }
    }
    public void Close()
    {

    }
}
