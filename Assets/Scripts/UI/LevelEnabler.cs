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
        for (int i = 0; i < GameControl.control.levelStars.Count; i++)
        {
            if (GameControl.control.levelStars[i].active)
            {
                levels[i].GetComponent<Button>().interactable = true;
                Debug.Log("Level number " + i + "is processed");
            }
        }
	}
}
