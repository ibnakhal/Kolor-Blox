using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour {
    [Header("Coordinates")]
    public GameObject upLeft;
    public GameObject up;
    public GameObject upRight;
    public GameObject right;
    public GameObject downRight;
    public GameObject down;
    public GameObject downLeft;
    public GameObject left;

    public int LevelCap;


    public enum Direction
    {
        Horizontal,
        Vertical,
        HoriVert,
        X,
        UpRightDownLeft,
        UpLeftDownRight,
        END,
    }
    public Direction KolorDirect;

    public Image i_sprite;
    public List<Sprite> i_direction;
    public List<Color> i_color;
    // Use this for initialization
	void Start ()
    {
        i_sprite = this.GetComponent<Image>();
        ColorUpdate();
	}
	


    private void ColorUpdate()
    {
        i_sprite.sprite = i_direction[(int)KolorDirect];
        i_sprite.color = i_color[(int)KolorDirect];

    }
    public void ColorFunction()
    {
        this.GetComponentInParent<Handler>().TurnTick();
        this.GetComponent<AudioSource>().Play();
        switch (KolorDirect)
        {
            case Direction.Horizontal:
                HorizontalChange();
                break;
            case Direction.Vertical:
                VerticalChange();
                break;
            case Direction.HoriVert:
                CrossChange();
                break;
            case Direction.UpLeftDownRight:
                LRDiagonalChange();
                break;
            case Direction.UpRightDownLeft:
                RLDiagonalChange();
                break;
            case Direction.X:
                CrossDiagonalChange();
                break;
        }
    }

    private void HorizontalChange()
    {
        Cycle();
        ColorUpdate();
        if (left != null)
        {
            left.GetComponent<ColorChanger>().Cycle();
            left.GetComponent<ColorChanger>().ColorUpdate();
        }
        if(right != null)
        {
            right.GetComponent<ColorChanger>().Cycle();
            right.GetComponent<ColorChanger>().ColorUpdate();
        }
    }

    private void VerticalChange()
    {
        Cycle();
        ColorUpdate();
        if (up != null)
        {
            up.GetComponent<ColorChanger>().Cycle(); 
            up.GetComponent<ColorChanger>().ColorUpdate();
        }
        if (down != null)
        {
            down.GetComponent<ColorChanger>().Cycle();
            down.GetComponent<ColorChanger>().ColorUpdate();
        }
    }

    private void CrossChange()
    {
        Cycle();
        ColorUpdate();
        if (left != null)
        {
            left.GetComponent<ColorChanger>().Cycle();
            left.GetComponent<ColorChanger>().ColorUpdate();
        }
        if (right != null)
        {
            right.GetComponent<ColorChanger>().Cycle();
            right.GetComponent<ColorChanger>().ColorUpdate();
        }
        if (up != null)
        {
            up.GetComponent<ColorChanger>().Cycle();
            up.GetComponent<ColorChanger>().ColorUpdate();
        }
        if (down != null)
        {
            down.GetComponent<ColorChanger>().Cycle();
            down.GetComponent<ColorChanger>().ColorUpdate();
        }
    }

    private void LRDiagonalChange()
    {
        Cycle();
        ColorUpdate();
        if (upLeft != null)
        {
            upLeft.GetComponent<ColorChanger>().Cycle();
            upLeft.GetComponent<ColorChanger>().ColorUpdate();
        }
        if (downRight != null)
        {
            downRight.GetComponent<ColorChanger>().Cycle();
            downRight.GetComponent<ColorChanger>().ColorUpdate();
        }
    }
  
    private void RLDiagonalChange()
    {
        Cycle();
        ColorUpdate();
        if (upRight != null)
        {
            upRight.GetComponent<ColorChanger>().Cycle();
            upRight.GetComponent<ColorChanger>().ColorUpdate();
        }
        if (downLeft != null)
        {
            downLeft.GetComponent<ColorChanger>().Cycle();
            downLeft.GetComponent<ColorChanger>().ColorUpdate();
        }
    }

    private void CrossDiagonalChange()
    {
        Cycle();
        ColorUpdate();
        if (upRight != null)
        {
            upRight.GetComponent<ColorChanger>().Cycle();
            upRight.GetComponent<ColorChanger>().ColorUpdate();
        }
        if (downLeft != null)
        {
            downLeft.GetComponent<ColorChanger>().Cycle();
            downLeft.GetComponent<ColorChanger>().ColorUpdate();
        }
        if (upLeft != null)
        {
            upLeft.GetComponent<ColorChanger>().Cycle();
            upLeft.GetComponent<ColorChanger>().ColorUpdate();
        }
        if (downRight != null)
        {
            downRight.GetComponent<ColorChanger>().Cycle();
            downRight.GetComponent<ColorChanger>().ColorUpdate();
        }
    }

    private void Cycle()
    {
        KolorDirect += 1;
        if(KolorDirect == ((int)Direction.END-(Direction.END-LevelCap)))
        {
            KolorDirect = 0;
        }
    }
}
