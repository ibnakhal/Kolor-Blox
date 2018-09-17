using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour {

    public Animator ChangePanel;
    public AnimationClip panelClose;
    public AnimationClip panelOpen;
    public Text setText;
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
        string name = setToLoad.name;
        setText.text = name;
        ChangePanel.SetBool("Play", true);
        yield return new WaitForSeconds(1.5f);
        setToLoad.SetActive(true);
        ChangePanel.SetBool("Play", false);
        this.gameObject.SetActive(false);

    }
    public void LoadInvoker()
    {
        StartCoroutine(Loader());
    }
    public IEnumerator Loader()
    {
        ChangePanel.SetBool("Play", true);
        yield return new WaitForSeconds(1.5f);
        GameObject go = this.transform.parent.gameObject;
        SceneManager.LoadScene(go.name, LoadSceneMode.Single);
    }


}
