using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScriptDialog : MonoBehaviour
{
    public int numberGivnerD;

    public Transform panelAllGivner;
    public List<GivnerDialog> givnerScript;

    public List<GameObject> objectButtons;
    public List<TextMeshProUGUI> buttonText;

    public GameObject panelChoise;
    public TextMeshProUGUI textP;

    private int choiseNumber;

    private void Awake()
    {
        for(int i = 0; i < panelAllGivner.childCount; i++)
        {
            givnerScript.Add(panelAllGivner.GetChild(i).GetComponent<GivnerDialog>());
        }
    }
    
    public void LetsDialog()
    {
        panelChoise.SetActive(true);
        textP.text = givnerScript[numberGivnerD].dialogText[0];
        for(int i = 0; i<buttonText.Count;i++)
        {
            if(givnerScript[numberGivnerD].choiseText[i] != "null")
            {
                objectButtons[i].SetActive(true);
                buttonText[i].text = givnerScript[numberGivnerD].choiseText[i];
            }
            else
            {
                objectButtons[i].SetActive(false);
                buttonText[i].text = "";
            }
            
        }
    }
    public void EndDialog()
    {
        textP.text = givnerScript[numberGivnerD].exitText;
    }

    public void ClickDialog()
    {
        if(choiseNumber == 0)
        {
            textP.text = givnerScript[numberGivnerD].dialogText[1];
            buttonText[0].color = new Color(0.3113208f,0.3113208f,0.3113208f,1);
        }
        if(choiseNumber == 1)
        {
            textP.text = givnerScript[numberGivnerD].dialogText[2];
            buttonText[1].color = new Color(0.3113208f,0.3113208f,0.3113208f,1);
        }
        if(choiseNumber == 2)
        {
            textP.text = givnerScript[numberGivnerD].dialogText[3];
            buttonText[2].color = new Color(0.3113208f,0.3113208f,0.3113208f,1);
        }
    }

    public void ClickOneQuestion()
    {
        choiseNumber = 0;
        ClickDialog();
    }
    public void ClickTwoQuestion()
    {
        choiseNumber = 1;
        ClickDialog();
    }
    public void ClickTreeQuestion()
    {
        choiseNumber = 2;
        ClickDialog();
    }
    public void PayItemSay()
    {
        textP.text = givnerScript[numberGivnerD].positiveText;
    }
    public void NoPayItemSay()
    {
        textP.text = givnerScript[numberGivnerD].noPositiveText;
    }
    public void UpdatButtons()
    {
        for(int i = 0; i<buttonText.Count;i++)
        {
            objectButtons[i].SetActive(true);
            buttonText[i].text = "";
            buttonText[i].color = new Color(0,0,0,1);
        }
    }
}
