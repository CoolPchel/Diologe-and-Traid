using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour, IInteractable
{
    private UiScriptDialog uiSDialog;
    private TalkScreen talkScren;
    private GivnerDialog givner; 
    public string nameOponent;
    public GameObject panelDialog;
    public GameObject[] traid0Task1;
    public GameObject chooseUI;

    // private Transform playerEyes;
    // public bool lookPlayer;

    private Conversation conver;
    public bool cantWorkScript;

    private void Start()
    {
        uiSDialog = FindObjectOfType<UiScriptDialog>();
        talkScren = FindObjectOfType<TalkScreen>();
        givner = GetComponent<GivnerDialog>();
        // playerEyes = GameObject.FindGameObjectWithTag("PlayerEys").transform;
        if(gameObject.GetComponent<Conversation>() != null)
        {
            conver = GetComponent<Conversation>();
        }
    }

    // private void Update()
    // {
    //     if(lookPlayer)
    //     {
    //         transform.LookAt(playerEyes);
    //     }
    // }

    public string GetDescription()
    {
        return "Поговорить";
    }

    public void Interact() 
    {
        if(!cantWorkScript)
        {
            if(gameObject.tag == "Trader")
            {
                // traid0Task1[1].SetActive(false);
                traid0Task1[0].SetActive(true);
            }
            // if(gameObject.tag == "Tasker")
            // {
            //     traid0Task1[0].SetActive(false);
            //     traid0Task1[1].SetActive(true);
            // }
            if(gameObject.tag != "Trader" && gameObject.tag != "Tasker")
            {
                // traid0Task1[1].SetActive(false);
                traid0Task1[0].SetActive(false);
            }
            chooseUI.SetActive(true);
            givner.OpenPanelD(); 
            uiSDialog.numberGivnerD = givner.numberGivner; //Скрипт дает номер диалога, чтобы uiSDialog взял нужный диалог для выбора
        }
        else
        {
            conver.StartConversation();
        }
        panelDialog.SetActive(true);
        talkScren.STalkScreen();
    }   
}
