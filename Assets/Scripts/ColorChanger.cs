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
                Change(left);
                Change(right);
                break;
            case Direction.Vertical:
                Change(up);
                Change(down);
                break;
            case Direction.HoriVert:
                Change(up);
                Change(down);
                Change(left);
                Change(right);
                break;
            case Direction.UpLeftDownRight:
                Change(upLeft);
                Change(downRight);
                break;
            case Direction.UpRightDownLeft:
                Change(upRight);
                Change(downLeft);
                break;
            case Direction.X:
                Change(upRight);
                Change(downLeft);
                Change(upLeft);
                Change(downRight);
                break;
        }
        Cycle();
        ColorUpdate();
    }

    private void Change(GameObject target)
    {
        if (target != null)
        {
            target.GetComponent<ColorChanger>().Cycle();
            target.GetComponent<ColorChanger>().ColorUpdate();
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
