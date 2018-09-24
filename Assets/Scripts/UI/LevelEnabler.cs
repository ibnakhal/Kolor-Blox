 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnabler : MonoBehaviour {
    [SerializeField]
    private List<GameObject> levels;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < GameControl.control.levelStars.Count+1; i++)
        {
            levels[i].GetComponent<Button>().enabled = true;
        }
	}
}
