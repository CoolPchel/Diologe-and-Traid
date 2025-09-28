using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TraidWindow : MonoBehaviour
{
    private TriggerUp triggUp;
    public TextMeshProUGUI textWallet;

    public List<ItemScriptObject> allProjectille;
    private float damadgeDistance;

    private TextMeshProUGUI textUdate;
    public GameObject paneArmor;
    public GameObject paneWeapon;
    public GameObject paneWeaponMelle;
    public GameObject paneWeaponDistence;
    public GameObject paneWeaponDistenceType0;
    public GameObject paneWeaponDistenceType1;
    // public GameObject paneWeaponDistenceElement;
    public Transform penelInfo;
    private ItemScriptObject slotInfoItem;
    
    public Slots lastClickSlot;

    private GameObject register;
    private UiScriptDialog uiScriptD;
    private bool isBuyItem;

    private int kolUpdat;
    public TextMeshProUGUI textbutton;
    private int moneyUpdate = 0;
    public bool canUpdatSlots = true;
    public List<Image> updat0Pay1;

    private void Awake()
    {
        textbutton.text = "бесплатно";
        uiScriptD = FindObjectOfType<UiScriptDialog>();
        triggUp = FindObjectOfType<TriggerUp>();
        register = GameObject.Find("RegisterTransform");
    }

    void Update()
    {
        textWallet.text = triggUp.coins.ToString();
        if(triggUp.coins < moneyUpdate)
        {
            canUpdatSlots = false;
            updat0Pay1[0].color = new Color(0.84f,0.84f,0.84f);
        }
        else
        {
            canUpdatSlots = true;
            updat0Pay1[0].color = new Color(1,1,1);
        }

        if(slotInfoItem != null)
        {
            if(triggUp.coins < slotInfoItem.valuable)
            {
                updat0Pay1[1].color = new Color(0.84f,0.84f,0.84f);
            }
            else
            {
                updat0Pay1[1].color = new Color(1,1,1);
            }
        }
    }

    public void PayItem()
    {
        if(triggUp.coins >= slotInfoItem.valuable)
        {
            triggUp.coins -= slotInfoItem.valuable;
            Instantiate(slotInfoItem.itemPrefab, register.transform.position ,Quaternion.identity);
            isBuyItem = true;
            lastClickSlot.ThisPay();
        }
    }

    public void UpdatSlotMoney()
    {
        if(canUpdatSlots)
        {
            triggUp.coins -= moneyUpdate;
            kolUpdat++;
            moneyUpdate = 50 * kolUpdat;
            textbutton.text = moneyUpdate.ToString();
        }
    }

    public void ExitTraid()
    {
        if(isBuyItem)
        {
            uiScriptD.PayItemSay();
        }
        else
        {
            uiScriptD.NoPayItemSay();
        }
        isBuyItem = false;
    }

    public void ShowInfo()
    {
        if(lastClickSlot.itemT != null)
        {
            for(int i = 0; i < 1; i++)
            {   
                slotInfoItem = lastClickSlot.itemT;
                paneArmor.SetActive(false);
                paneWeapon.SetActive(false);
                paneWeaponDistence.SetActive(false);
                paneWeaponMelle.SetActive(false);
                paneWeaponDistenceType0.SetActive(false);
                paneWeaponDistenceType1.SetActive(false);
                // paneWeaponDistenceElement.SetActive(false);
                textUdate = penelInfo.GetChild(0).GetComponent<TextMeshProUGUI>();
                textUdate.text = slotInfoItem.nameItem.ToString();

                textUdate = penelInfo.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
                if(!slotInfoItem.isDistanceWeapon && slotInfoItem.isArmor)
                {
                    textUdate.text = "Защита";
                    paneArmor.SetActive(true);
                    textUdate = penelInfo.GetChild(1).GetChild(3).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
                    textUdate.text = slotInfoItem.maxProtection.ToString();
                }
                if(slotInfoItem.isDistanceWeapon && !slotInfoItem.isArmor)
                {
                    textUdate.text = "Дальний бой";
                    paneWeapon.SetActive(true);
                    textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
                    for(int o = 0; o < allProjectille.Count;o++)
                    {
                        if(allProjectille[o].nameProjectille == slotInfoItem.nameProjectille)
                        {
                            damadgeDistance = allProjectille[o].cDamadge;
                        }
                    }
                    textUdate.text = damadgeDistance.ToString();
                    paneWeaponDistence.SetActive(true);
                    textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
                    textUdate.text = slotInfoItem.fDistance.ToString();
                    if(slotInfoItem.type == 0 && slotInfoItem.isHaveChamber)
                    {
                        paneWeaponDistenceType0.SetActive(true);
                        textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(2).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
                        textUdate.text = slotInfoItem.armorInChamber.ToString();
                    }
                    if(slotInfoItem.type == 1)
                    {
                        paneWeaponDistenceType1.SetActive(true);
                        textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(2).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
                        textUdate.text = slotInfoItem.useMana.ToString();
                    }
                    textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(2).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
                    textUdate.text = slotInfoItem.shotDelay.ToString();
                    textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(2).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
                    textUdate.text = slotInfoItem.nameProjectille;
                    // if(slotInfoItem.typeDamage != 0)
                    // {
                    //     paneWeaponDistenceElement.SetActive(true);
                    //     textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(2).GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
                    //     if(slotInfoItem.typeDamage == 1)
                    //     {
                    //         textUdate.text = "Огонь";
                    //     }
                    //     if(slotInfoItem.typeDamage == 2)
                    //     {
                    //         textUdate.text = "Лёд";
                    //     }
                    // }
                }
                if(!slotInfoItem.isDistanceWeapon && !slotInfoItem.isArmor)
                {
                    textUdate.text = "Ближний бой";
                    paneWeapon.SetActive(true);
                    textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
                    textUdate.text = slotInfoItem.damadge.ToString();
                    paneWeaponMelle.SetActive(true);
                    textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
                    textUdate.text = slotInfoItem.dobRWDamage.ToString();
                    textUdate = penelInfo.GetChild(1).GetChild(4).GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
                    if(slotInfoItem.typeMWeapon == 0)
                    {
                        textUdate.text = "Pасcекающий";
                    }
                    if(slotInfoItem.typeMWeapon == 1)
                    {
                        textUdate.text = "Колющий";
                    }
                    if(slotInfoItem.typeMWeapon == 2)
                    {
                        textUdate.text = "Дробящий";
                    }
                }

                textUdate = penelInfo.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
                textUdate.text = slotInfoItem.rang.ToString();

                textUdate = penelInfo.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
                if(slotInfoItem.type == 0)
                {
                    textUdate.text = "Физическое";
                }
                if(slotInfoItem.type == 1)
                {
                    textUdate.text = "Магическое";
                }

                textUdate = penelInfo.GetChild(1).GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
                textUdate.text = slotInfoItem.valuable.ToString();
            }
        }
        
    }
}
