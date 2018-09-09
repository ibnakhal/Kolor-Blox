using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handler : MonoBehaviour {
    public List<ColorChanger> blocks;
    public int counter;
    public int total;
    public Text counterIdentityText;
    public Text counterText;
    public List<int> scores;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(counter == 0)
        {
            Debug.Log("lose");
        }
        for (int i = 0; i < blocks.Count; i++)
        {
            for (int x = 0; x < blocks.Count; x++)
            {
                if(blocks[i].Kolor != blocks[x].Kolor)
                {
                    return;
                }
            }
        }

        Debug.Log("win");

    }

    public void TurnTick()
    {
        counter++;
        Debug.Log(counter);
        counterText.text = counter.ToString();
    }
}
