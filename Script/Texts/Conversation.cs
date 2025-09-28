using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Conversation : MonoBehaviour
{
    private TalkScreen talkScreenStript;
    private Interaction interact;
    public TextMeshProUGUI name;
    public TextMeshProUGUI textPanel;
    public List<string> textCon;
    private bool st;
    private int numberText = 0;
    private int numberQueue = 1;
    private int saveNamberDialog = 0;

    private void Start()
    {
        talkScreenStript = FindObjectOfType<TalkScreen>();
        interact = GetComponent<Interaction>();
        if(PlayerPrefs.HasKey("Chapter1"))
        {
            saveNamberDialog = PlayerPrefs.GetInt("Chapter1");
            if(saveNamberDialog == 1)
            {
                interact.cantWorkScript = false;
            }
            else
            {
                interact.cantWorkScript = true;
            }
        }
        else
        {
            interact.cantWorkScript = true;
        }
    }

    public void StartConversation()
    {
        talkScreenStript.SDialogScreen();
        name.text = interact.nameOponent;
        textPanel.text = textCon[0];
        st = true;
    }

    private void Update()
    {
        if(interact.cantWorkScript == true)
        {
            if(st)
            {
                if(Input.anyKeyDown && numberText < textCon.Count)
                {
                    numberText++;
                    if(numberText < textCon.Count)
                    {
                        textPanel.text = textCon[numberText];
                    }
                    st = false;
                }

                if(Input.anyKeyDown && numberText >= textCon.Count)
                {
                    EndConversation();
                    st = false;
                }
            }

            if(numberQueue == numberText)
            {
                st = true;
                numberQueue++;
            }
        }
    }

    private void EndConversation()
    {
        PlayerPrefs.SetInt("Chapter1", 1);
        interact.cantWorkScript = false;
        interact.panelDialog.SetActive(false);
        talkScreenStript.EDialogScreen();
        talkScreenStript.ETalkScreen();
    }
}
