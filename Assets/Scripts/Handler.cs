using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Handler : MonoBehaviour
{
    [Header("Level Info")]
    public int sceneIndex;


    [Header ("Win Condition")]
    public List<ColorChanger> blocks;
    public int counter;
    public Text counterText;
    public List<int> scores;

    [Header("Win Announcement")]
    public Text winText;
    public Color winColor;
    private float winTimer = 00f;
    public float winDuration;

    public GameObject winPanel;
    public Animator winAnim;
    public bool end;



    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            for (int x = 0; x < blocks.Count; x++)
            {
                //Debug.Log("i is " + i + ":" + blocks[i].KolorDirect + "and x is "+ x + ":" + blocks[x].KolorDirect);

                if (blocks[i] != blocks[x] && blocks[i] != blocks[x])
                {
                    if (blocks[i].KolorDirect != blocks[x].KolorDirect)
                    {
                        return;
                    }
                }
            }
            Debug.Log("I am skipped");
        }

        Debug.Log("Win");
        if (!end)
        {
            StartCoroutine(colorLerp());
            end = true;
        }

        winTimer += (Time.deltaTime/winDuration);
    }

    public void TurnTick()
    {
        ++counter;
        Debug.Log(counter);
        counterText.text = counter.ToString();
    }

    public void End()
    {
        print("This scene is " +SceneManager.GetActiveScene().buildIndex);
        sceneIndex = SceneManager.GetActiveScene().buildIndex - GameControl.control.levelCullModifier;
        print("Next scene is " + sceneIndex+1);
        if (GameControl.control.levelStars.Count < sceneIndex+1)
        {
            GameControl.control.levelStars.Add(0);
        }
        if (counter < scores[0])
        {
            if (GameControl.control.levelStars[sceneIndex] < 3)
            {
                GameControl.control.levelStars[sceneIndex] = 3;
                //3star
                Debug.Log("THREE STARS!");
            }
        }
        if (counter >= scores[0] && counter < scores[1])
        {
            //2star
            Debug.Log("TWO STARS!");
            if (GameControl.control.levelStars[sceneIndex] < 2)
            {
                GameControl.control.levelStars[sceneIndex] = 2;
            }
        }
        if (counter >= scores[1] && counter < scores[2])
        {
            //1star
            Debug.Log("ONE STAR!");
            if (GameControl.control.levelStars[sceneIndex] < 1)
            {
                GameControl.control.levelStars[sceneIndex] = 1;
            }
        }
        if (counter >= scores[2])
        {
            //0star
            Debug.Log("NO STARS!");
            if (GameControl.control.levelStars[sceneIndex] < 0)
            {
                GameControl.control.levelStars[sceneIndex] = 0;
            }
        }

        GameControl.control.Save();
    }


    public IEnumerator colorLerp()
    {

        for (int i = 0; i < blocks.Count; i++)
        {
            winTimer = 0;
            Debug.Log(winTimer);
            for (float t = 0.0f; t < 1;)
            {
                t += Time.deltaTime/winDuration;

                blocks[i].GetComponent<Image>().color = Color.Lerp(blocks[i].i_color[(int)blocks[i].KolorDirect], winColor, Mathf.Lerp(0, 1, t));

                yield return null;
            }
        }
        winText.text = ("Puzzle Complete");
        winAnim.SetBool("Play", true) ;
        End();

    }


    public void Next()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
