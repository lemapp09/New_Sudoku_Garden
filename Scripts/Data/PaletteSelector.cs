using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class PaletteSelector : MonoBehaviour
{

    [ColorPalette]
    public Color ColorOptions;
    public Color32[] CurrentPalette; 
    public float[] SampleHues = { 0.9167f, 0.7417f , 0.6444f, 0.5333f, 0.4611f, 0.2722f, 0.1611f, 0.0611f, 0.1111f , 0.2111f, 0.8555f, 0.5555f };
    [Range(0, 12)]
    public  int CurrentSampleHue = 2;

    private void Start()
    {

        GenerateCurrentPalette(SampleHues[CurrentSampleHue]);
    }

    void  GenerateCurrentPalette (float Hue)
    {
        CurrentPalette = new Color32[7];
        CurrentPalette[0] = Color.HSVToRGB(Hue, 0.72f , 1f);
        CurrentPalette[1] = Color.HSVToRGB(Hue, 0.60f, 1f);
        CurrentPalette[2] = Color.HSVToRGB(Hue, 0.48f, 1f);
        CurrentPalette[3] = Color.HSVToRGB(Hue, 0.36f, 1f);
        CurrentPalette[4] = Color.HSVToRGB(Hue, 0.24f, 1f);
        CurrentPalette[5] = Color.HSVToRGB(Hue, 0.12f, 1f);
        CurrentPalette[6] = Color.HSVToRGB((1.0f - Hue), 0.12f, 1f);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CurrentSampleHue++;
            if (CurrentSampleHue > SampleHues.Length -1) { CurrentSampleHue = 0;  }
            GenerateCurrentPalette(SampleHues[CurrentSampleHue]);
        }
    }
}
