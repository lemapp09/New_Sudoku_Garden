using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector; 

public class HelperSelectors : MonoBehaviour
{

    public bool selected;
    public int HelperMethods; 
    public GameObject redFlag;
    Image redFlagImage;
    SelectorControler parent;
    public PaletteSelector GameColors;
    BoardData boardData;

    private void Start()
    {
        parent = this.transform.GetComponentInParent<SelectorControler>();
        redFlagImage = redFlag.GetComponent<Image>();
        boardData = GameObject.Find("/BoardData").GetComponent<BoardData>();
    }

    private void Update()
    {
        redFlag.SetActive(boardData.HelpMeth[HelperMethods]);
        redFlagImage.color = GameColors.CurrentPalette[ 0];
    }

    public void ApplyMethod()
    {
        // parent.HelperMethods = 3;
    }

    public void ToggleSelected()
    {
        selected = !selected;
    }
}
