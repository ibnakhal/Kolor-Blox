using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour {

    public Animator ChangePanel;
    //public AnimationClip panelClose;
    //public AnimationClip panelOpen;
    public Text setText;
	// Use this for initialization

    public void panelInvoker(GameObject setToLoad)
    {
        StartCoroutine(PanelChange(setToLoad));
    }
    public IEnumerator PanelChange(GameObject setToLoad)
    {
        string name = setToLoad.name;
        setText.text = name;
        ChangePanel.SetBool("Play", true);
        yield return new WaitForSeconds(1.5f);
        setToLoad.SetActive(true);
        ChangePanel.SetBool("Play", false);
        gameObject.SetActive(false);
    }
}
