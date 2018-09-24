using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoadScript : MonoBehaviour
{
    public Animator changePanel;
    public Animator menuPanel;
    public Text levelText;
    [SerializeField]
    private bool autoLoad = true;

    public void LoadInvoker()
    {
        StartCoroutine(Loader());
    }
    public IEnumerator Loader()
    {
        string name;
        if (!autoLoad)
        {
            name = ("MenuSet");
        }
        else
        {
            GameObject go = this.transform.parent.gameObject;
            name = go.name;
        }
        if (levelText != null)
        {
            levelText.text = name;
        }
        if (changePanel != null)
        {
            changePanel.SetBool("Play", true);
        }
        if(menuPanel != null)
        {
            menuPanel.SetBool("Play", true);
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
