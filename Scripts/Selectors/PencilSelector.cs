using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PencilSelector : MonoBehaviour
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
        if (parent.ThreeMethods == 3)
        {
            redFlag.SetActive(true);
            redFlagImage.color = GameColors.CurrentPalette[0]; 
        }
        else
        {
            redFlag.SetActive(false);
        }
    }

    public void SetPencil()
    {
        if (parent.ThreeMethods != 3)
        {
            parent.ThreeMethods = 3;
        }
        else
        {
            parent.ThreeMethods = 1;
        }
    }
}
