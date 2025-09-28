using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkScreen : MonoBehaviour
{
    private Hend hendClik;
    public Camera cam;
    public GameObject interfaceUI;
    private FirstPersonLook fol;
    private FirstPersonMovement fpm;
    private Animator animatorCam;

    void Start()
    {
        hendClik = FindObjectOfType<Hend>();
        fol = FindObjectOfType<FirstPersonLook>();
        fpm = FindObjectOfType<FirstPersonMovement>();
        animatorCam = GetComponent<Animator>();
    }

    public void STalkScreen()
    {
        hendClik.canAttack = false;
        fol.sensitivity = 0f;
        Cursor.lockState = CursorLockMode.None;
        fpm.speed = 0f;
        animatorCam.SetBool("TalkScreen",true);
        interfaceUI.SetActive(false);
    }
    public void ETalkScreen()
    {   
        hendClik.canAttack = true;
        interfaceUI.SetActive(true);
        fol.sensitivity = 2f;
        Cursor.lockState = CursorLockMode.Locked;
        fpm.speed = 5f;
        animatorCam.SetBool("TalkScreen",false);
    }
    public void TriggerFalseAm()
    {
        animatorCam.SetTrigger("Back");
    }
    public void SDialogScreen()
    {
        animatorCam.SetBool("DialogScreen",true);
    }
    public void EDialogScreen()
    {
        animatorCam.SetBool("DialogScreen",false);
    }
}
