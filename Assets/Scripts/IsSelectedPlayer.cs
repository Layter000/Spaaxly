using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsSelectedPlayer : MonoBehaviour {

    public int thisSelCar;

    private Color color;
    private Button btn;


    void Start()
    {
        btn = GetComponent <Button> ();
        color.a = 1;
    }

	void Update () {
        if (thisSelCar == GameControl.instance.selectedCharacters)
        {
            color = Color.white;
        }
        else
        { 
            color.r = 0.4f;
            color.g = 0.4f;
            color.b = 0.4f;
        }
        ColorBlock colorBlock = btn.colors;
        colorBlock.normalColor = color;
        btn.colors = colorBlock;
	}
}
