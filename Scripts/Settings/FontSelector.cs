using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector; 

public class FontSelector : MonoBehaviour
{
    public TextMeshProUGUI[] ValuesText ;
    public TextMeshProUGUI[] SampleFonts;
    [Range(0, 9)]
    public int fontNumber;

    void Start()
    {
        fontNumber = 0;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fontNumber++;
            if (fontNumber > SampleFonts.Length - 1 ) { fontNumber = 0;  }
            UpdateFont();
        }
    }

    public void UpdateFont ()
    {
        for (int i = 0; i < ValuesText.Length ; i++)
        {
            ValuesText[i].font = SampleFonts[fontNumber].font;
            ValuesText[i].fontSize = SampleFonts[fontNumber].fontSize;
        }
    }
}
