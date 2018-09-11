using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handler : MonoBehaviour
{
    public List<ColorChanger> blocks;
    public int counter;
    public int total;
    public Text counterIdentityText;
    public Text counterText;
    public List<int> scores;
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
                if (blocks[i].Kolor != blocks[x].Kolor)
                {
                    return;
                }
            }
        }


        End();

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

}
