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


    public enum ColorKind
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black,
        Magenta,
        END,
    }
    public ColorKind Kolor;

    public Image i_sprite;
    public List<Sprite> i_direction;
    // Use this for initialization
	void Start () {
        i_sprite = this.GetComponent<Image>();
        ColorUpdate();

	}
	


    private void ColorUpdate()
    {
        i_sprite.sprite = i_direction[(int)Kolor];

        switch (Kolor)
        {
            case ColorKind.Red:
                i_sprite.color = Color.red;
                break;
            case ColorKind.Green:
                i_sprite.color = Color.green;
                break;
            case ColorKind.Blue:
                i_sprite.color = Color.blue;
                break;
            case ColorKind.Yellow:
                i_sprite.color = Color.yellow;
                break;
            case ColorKind.Black:
                i_sprite.color = Color.black;
                break;
            case ColorKind.Magenta:
                i_sprite.color = Color.magenta;
                break;
        }
    }
    public void ColorFunction()
    {
        this.GetComponentInParent<Handler>().TurnTick();
        switch (Kolor)
        {
            case ColorKind.Red:
                HorizontalChange();
                    break;
            case ColorKind.Green:
                VerticalChange();
                break;
            case ColorKind.Blue:
                CrossChange();
                break;
            case ColorKind.Magenta:
                LRDiagonalChange();
                break;
            case ColorKind.Black:
                RLDiagonalChange();
                break;
            case ColorKind.Yellow:
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
        Kolor += 1;
        if(Kolor == (ColorKind.END-LevelCap))
        {
            Kolor = 0;
        }
    }
}
