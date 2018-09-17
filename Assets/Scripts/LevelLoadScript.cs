using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoadScript : MonoBehaviour {
    public Animator ChangePanel;
    public Text levelText;

    public void LoadInvoker()
    {
        StartCoroutine(Loader());
    }
    public IEnumerator Loader()
    {

        GameObject go = this.transform.parent.gameObject;
        string name = go.name;
        if (levelText != null)
        {
            levelText.text = name;
        }
        if (ChangePanel != null)
        {
            ChangePanel.SetBool("Play", true);
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
