using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentNameScript : MonoBehaviour {
    [SerializeField]
    private Text thisText;



	// Use this for initialization
	void Start ()
    {
        thisText = this.GetComponent<Text>();
        GameObject go = this.transform.parent.gameObject;
        thisText.text = go.name;
        Color textColor = go.GetComponent<Image>().color;
        textColor.a = 0.75f;
        thisText.color = textColor;

	}

}
