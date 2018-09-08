using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour {
    public List<ColorChanger> blocks;
    public int counter;
    public int total;
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
}
