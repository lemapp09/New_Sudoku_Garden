using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector; 

public class SelectorStatus : MonoBehaviour
{
    [Range(1,9)]
    public int SelectorNumber; 
    public bool selected;
    public bool UsedUp; // This number can only appear 9x on the board
    public GameObject display;
    private TextMeshProUGUI displayText ;
    public SelectorControler parent;
    public PaletteSelector GameColors;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.GetComponentInParent<SelectorControler>();
        display = this.transform.GetChild(0).gameObject;
        displayText = display.GetComponent<TextMeshProUGUI>();
        updateSelectors();
    }

    void Update()
    {
        updateSelectors();
    }

    void updateSelectors ()
    {
        if (selected)
        {
            displayText.color = GameColors.CurrentPalette[2];
        }
        else
        {
            displayText.color = GameColors.CurrentPalette[4];
        }
    }

    public void ChangeSelector()
    {
        parent.CurrentSelector = SelectorNumber; 
    }
}
