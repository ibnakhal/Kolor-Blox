using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handler : MonoBehaviour
{
    public List<ColorChanger> blocks;
    public int counter;
    public Text counterIdentityText;
    public Text counterText;
    public List<int> scores;

    public Color winColor;
    private float winTimer = 00f;
    public float winDuration;
    public bool end;

    public GameObject winPanel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < blocks.Count; i++)
        {
            for (int x = 0; x < blocks.Count; x++)
            {
                Debug.Log("i is " + i + ":" + blocks[i].KolorDirect + "and x is "+ x + ":" + blocks[x].KolorDirect);


                if (blocks[i]!=blocks[x] && blocks[i] != blocks[x])
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
        counter++;
        Debug.Log(counter);
        counterText.text = counter.ToString();
    }

    public void End()
    {
        if (counter < scores[0])
        {
            //3star
            Debug.Log("THREE STARS!");
        }
        if (counter >= scores[0] && counter < scores[1])
        {
            //2star
            Debug.Log("TWO STARS!");

        }
        if (counter >= scores[1] && counter < scores[2])
        {
            //1star
            Debug.Log("ONE STAR!");
        }
        if (counter <= scores[2])
        {
            //0star
            Debug.Log("NO STARS!");
        }

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

        End();

    }

}
