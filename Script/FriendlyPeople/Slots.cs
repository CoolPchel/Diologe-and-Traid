using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    private TriggerUp triggUpCoin;
    private TraidWindow traidWindo;
    private ListAllItems listAll;
    private List<ItemScriptObject> filterItems = new List<ItemScriptObject>();
    private int randomNumber;
    public int rangItem;
    public ItemScriptObject itemT;
    private Image imageItem;
    public Sprite thisPay;
    public GameObject buttonPay;
    public GameObject penelInfo;

    private void Start()
    {
        triggUpCoin = FindObjectOfType<TriggerUp>();
        traidWindo = FindObjectOfType<TraidWindow>();
        imageItem = transform.GetChild(0).GetComponent<Image>();
        listAll = FindObjectOfType<ListAllItems>();
        for(int i = 0; listAll.listItems.Count > i; i++)
        {
            if(listAll.listItems[i].rang == rangItem && listAll.listItems[i].valuable != 0)
            {
                filterItems.Add(listAll.listItems[i]);
            }
        }
        randomNumber = Random.Range(0, filterItems.Count);
        itemT = filterItems[randomNumber];
        imageItem.sprite = itemT.icon;
    }

    private void Update()
    {
        if(itemT != null)
        {
            if(triggUpCoin.coins >= itemT.valuable)
            {
                gameObject.GetComponent<Image>().color = new Color(0.63f,0.63f,0.63f);
                imageItem.color = new Color(1,1,1);
            }
            else
            {
                gameObject.GetComponent<Image>().color = new Color(0.47f,0.47f,0.47f);
                imageItem.color = new Color(0.84f,0.84f,0.84f);
            }
        }
    }

    public void UdpatSlot()
    {
        if(traidWindo.canUpdatSlots)
        {
            randomNumber = Random.Range(0, filterItems.Count);
            itemT = filterItems[randomNumber];
            imageItem.sprite = itemT.icon;
        }
    }
    public void ClickMe()
    {
        if(itemT != null)
        {
            traidWindo.lastClickSlot = GetComponent<Slots>();
            buttonPay.SetActive(true);
            penelInfo.SetActive(true);
        }
        else
        {
            buttonPay.SetActive(false);
            penelInfo.SetActive(false);
        }
        traidWindo.ShowInfo();
    }
    public void ThisPay()
    {
        imageItem.sprite = thisPay;
        itemT = null;
        buttonPay.SetActive(false);
        penelInfo.SetActive(false);
    }
}
