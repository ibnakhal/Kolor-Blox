using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour {

    public Animator ChangePanel;
    public AnimationClip panelClose;
    public AnimationClip panelOpen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }
    public void panelInvoker(GameObject setToLoad)
    {
        StartCoroutine(PanelChange(setToLoad));
    }
    public IEnumerator PanelChange(GameObject setToLoad)
    {
        ChangePanel.SetBool("Play", true);
        yield return new WaitForSeconds(1.5f);
        setToLoad.SetActive(true);
        ChangePanel.SetBool("Play", false);
        this.gameObject.SetActive(false);

    }


}
