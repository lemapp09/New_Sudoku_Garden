using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Sirenix.OdinInspector;

public class CellDisplay : MonoBehaviour
{
    public CellData data;
    public int value; // Value Displayed
    public int realValue;
    public bool visible;
    public GameObject valueDisplay;  // Note: ValueDisplay is different from realValue. The realValue is set by the puzzle at start.
    private TextMeshProUGUI displayText;
    public PaletteSelector GameColors;
    private Image image;
    public BoardData boardData;

    GameObject[] PMDisplay = new GameObject[10];  //  Pencil Mark Displays


    private void Start()
    {
        image = this.gameObject.GetComponent<Image>();  // Background Color
        for (int i = 0; i < 10; i++)
        {
            PMDisplay[i] = this.transform.GetChild(i).gameObject; //  PMDisplay[0] is the Text Display
        }
        valueDisplay = PMDisplay[0];   // This toggles showing the cell value
        displayText = PMDisplay[0].GetComponent<TextMeshProUGUI>();  // This sets the cell value
        boardData = GameObject.Find("/BoardData").GetComponent<BoardData>();
        UpdateDisplay(data);

    }

    private void UpdateDisplay(CellData data)
    {
        value = data.displayValue;
        realValue = data.realValue;
        visible = data.visible;
        for (int i = 0; i < 10; i++)
        {
            PMDisplay[i].GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (visible)
        {
            valueDisplay.SetActive(true);
            displayText.text = data.displayValue.ToString();
            for (int i = 1; i < 10; i++)
            {
                PMDisplay[i].SetActive(false);
            }
        }
        else
        {
            valueDisplay.SetActive(false);
            PMDisplay[1].SetActive(data.pencil1);
            PMDisplay[2].SetActive(data.pencil2);
            PMDisplay[3].SetActive(data.pencil3);
            PMDisplay[4].SetActive(data.pencil4);
            PMDisplay[5].SetActive(data.pencil5);
            PMDisplay[6].SetActive(data.pencil6);
            PMDisplay[7].SetActive(data.pencil7);
            PMDisplay[8].SetActive(data.pencil8);
            PMDisplay[9].SetActive(data.pencil9);

            image.color = GameColors.CurrentPalette[4];
        }

        if (data.Highlighted)
        {
            image.color = GameColors.CurrentPalette[6];
        }
        else
        {
            image.color = GameColors.CurrentPalette[2];
        }

        if (boardData.CurrentCell == data.cellNumber)
        {
            image.color = GameColors.CurrentPalette[6];
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay(data);
    }

    public void SetCurrentCell()
    {
        boardData.CurrentCell = data.cellNumber;
        if (!visible)
        {
           data.displayValue = boardData.CurrentSelector;
           data.visible = true;
        }
        else
        {
            if ((boardData.HelpMeth[0]) & (data.realValue != data.displayValue))
            {
                data.visible = false;
            }
        }
    }
}


