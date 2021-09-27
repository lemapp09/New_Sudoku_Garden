using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EraserSelector : MonoBehaviour
{
    public GameObject redFlag;
    Image redFlagImage;
    SelectorControler parent;
    public PaletteSelector GameColors;

    private void Start()
    {
        parent = this.transform.GetComponentInParent<SelectorControler>();
        redFlagImage = redFlag.GetComponent<Image>();
    }

    private void Update()
    {
        if (parent.ThreeMethods == 2)
        {
            redFlag.SetActive(true);
            redFlagImage.color = GameColors.CurrentPalette[0];
        }
        else
        {
            redFlag.SetActive(false); 
        }
    }

    public void SetEraser ()
    {
        if (parent.ThreeMethods != 2)
        {
            parent.ThreeMethods = 2;
        }
        else
        {
            parent.ThreeMethods = 1;
        }
    }
}
