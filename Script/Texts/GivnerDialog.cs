using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GivnerDialog : MonoBehaviour
{   
    //public bool isTraidor; 

    public string exitText;
    public string positiveText;
    public string noPositiveText;
    public List<string> starterText;
    public List<string> dialogText;
    public List<string> choiseText;
    
    public int numberGivner;
    private Interaction namePerson;
    public TextMeshProUGUI name;
    public TextMeshProUGUI textPanel;
    private int randNumber;

    private void Start()
    {
        namePerson = GetComponent<Interaction>();
    }

    public void OpenPanelD()
    {
        randNumber = Random.Range(0, starterText.Count);
        name.text = namePerson.nameOponent;
        textPanel.text = starterText[randNumber];
    }
}
