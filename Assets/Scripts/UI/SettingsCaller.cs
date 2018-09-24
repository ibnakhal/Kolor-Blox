using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCaller : MonoBehaviour {


    [SerializeField]
    private Animator ChangePanel;
    [SerializeField]
    private Text setText;

    private GameObject setToUnload;

    public void panelInvoker(GameObject setToLoad)
    {
        StartCoroutine(PanelChange(setToLoad));
    }

    public void unloadSetter(GameObject unloadSet)
    {
        setToUnload = unloadSet;
    }

    public IEnumerator PanelChange(GameObject setToLoad)
    {
        string name = setToLoad.name;
        setText.text = name;
        ChangePanel.SetBool("Play", true);
        yield return new WaitForSeconds(1.5f);
        setToLoad.SetActive(true);
        ChangePanel.SetBool("Play", false);
        setToUnload.SetActive(false);
    }
}
