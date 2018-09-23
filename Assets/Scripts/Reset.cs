using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

    public Animator ChangePanel;
    [SerializeField]
    private Animator menuPanel;
    public void ResetInvoker()
    {
        StartCoroutine(ResetFunc());
    }

    public IEnumerator ResetFunc()
    {
        if (ChangePanel != null)
        {
            ChangePanel.SetBool("Play", true);
        }
        if(menuPanel != null)
        {
            menuPanel.SetBool("Play", true);
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
