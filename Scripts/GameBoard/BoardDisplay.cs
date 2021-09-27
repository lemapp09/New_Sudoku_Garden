using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BoardDisplay : MonoBehaviour
{
    public PaletteSelector GameColors;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        image.color = GameColors.CurrentPalette[ 4];
    }

    // Update is called once per frame
    void Update()
    {
        image.color = GameColors.CurrentPalette[4];
    }
}
