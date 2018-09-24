using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleChecker : MonoBehaviour {

    [SerializeField]
    private Toggle thisToggle;
    [SerializeField]
    private bool isSFX;

    // Use this for initialization
    void Start()
    {
        thisToggle = GetComponent<Toggle>();

        if (isSFX)
        {
            if (GameControl.control.soundVol != 1)
            {
                thisToggle.isOn = false;
            }
            else
            {
                thisToggle.isOn = true;
            }
        }
        else
        {
            if (GameControl.control.musicVol != 1)
            {
                thisToggle.isOn = false;
            }
            else
            {
                thisToggle.isOn = true;
            }
        }
    }

}
