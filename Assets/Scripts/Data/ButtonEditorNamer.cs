using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
[ExecuteInEditMode]
#endif
public class ButtonEditorNamer : MonoBehaviour {





	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.name = transform.parent.name;

    }
}
