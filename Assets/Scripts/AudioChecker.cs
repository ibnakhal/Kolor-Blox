using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChecker : MonoBehaviour {

    [SerializeField]
    private bool sfx;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!sfx)
        {
            this.GetComponent<AudioSource>().volume = GameControl.control.soundVol;
        }
        else
        {
            this.GetComponent<AudioSource>().volume = GameControl.control.musicVol;

        }

    }
}
