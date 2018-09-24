using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour {

    public void SoundInvoker(GameObject toggleBool)
    {
        bool tog = toggleBool.GetComponent<Toggle>().isOn;
        GameControl.control.SoundOn(tog);
    }
    public void MusicInvoker(GameObject toggleBool)
    {
        bool tog = toggleBool.GetComponent<Toggle>().isOn;
        GameControl.control.MusicOn(tog);
    }
}
