using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector; 

public class ColorFlags : MonoBehaviour
{
    public CanvasRenderer[] ColorFlagList;
    float colorChangeTimer;
    int cycleRange;
    int cycleDepth;

    // Start is called before the first frame update
    void Start()
    {
        colorChangeTimer = 0f;
        cycleRange = 0;
        cycleDepth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        colorChangeTimer += Time.deltaTime;
        if (colorChangeTimer >= 2.00f)
        {
            ColorChange();
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < ColorFlagList.Length; i++)
        {
            ColorFlagList[i].SetColor(Sirenix.OdinInspector.Editor.ColorPaletteManager.Instance.ColorPalettes[i].Colors[0]);
        }
        colorChangeTimer = 0f;
        cycleRange = 0;
        cycleDepth = 0;

    }

    void ColorChange()
    {
        // CycleRange determines the shade, specifiy color. There are 5 shades.
        // CycleDepth determines the rotation of palettes
        if (cycleRange > 4)
        {
            cycleRange = 0;
            cycleDepth++;
        }
        if (cycleDepth > 8) { cycleDepth = 0;  }
        for (int i = 0; i < ColorFlagList.Length; i++)
        {
            int j = i + cycleDepth;
            if (j > 8) {  j = j - 9; }
            ColorFlagList[i].SetColor(Sirenix.OdinInspector.Editor.ColorPaletteManager.Instance.ColorPalettes[j].Colors[cycleRange]);
        }

        cycleRange++;
        colorChangeTimer = 0f;
    }
}
