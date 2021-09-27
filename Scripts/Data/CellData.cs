using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[InlineEditor]
public class CellData : MonoBehaviour
{
    [LabelWidth(100)]
    [Range(1, 81)]
    public int cellNumber;

    [BoxGroup("Grid Placement")]
    [Range(1, 9)]
    public int x;
    [BoxGroup("Grid Placement")]
    [Range(1, 9)]
    public int y;


    [BoxGroup("Cell Values")]
    [LabelWidth(100)]
    [Range(1, 9)]
    public int realValue;
    [BoxGroup("Cell Values")]
    [LabelWidth(100)]
    [Range(1, 9)]
    public int displayValue;

    public bool visible; // Is the cell displaying a value
    public bool Highlighted;  //  See Helper Methods
    
    [BoxGroup("Pencil Marks")]
    [HorizontalGroup("Pencil Marks/PM")]
    [LabelWidth(100)]
    [LabelText("1")]
    [VerticalGroup("Pencil Marks/PM/Left")]
    public bool pencil1; // Display Pencil 

    [LabelWidth(100)]
    [LabelText("2")]
    [VerticalGroup("Pencil Marks/PM/Center")]
    public bool pencil2;

    [LabelWidth(100)]
    [LabelText("3")]
    [VerticalGroup("Pencil Marks/PM/Right")]
    public bool pencil3;

    [LabelWidth(100)]
    [LabelText("4")]
    [VerticalGroup("Pencil Marks/PM/Left")]
    public bool pencil4;

    [LabelWidth(100)]
    [LabelText("5")]
    [VerticalGroup("Pencil Marks/PM/Center")]
    public bool pencil5;

    [LabelWidth(100)]
    [LabelText("6")]
    [VerticalGroup("Pencil Marks/PM/Right")]
    public bool pencil6;


    [LabelWidth(100)]
    [LabelText("7")]
    [VerticalGroup("Pencil Marks/PM/Left")]
    public bool pencil7;

    [LabelWidth(100)]
    [LabelText("8")]
    [VerticalGroup("Pencil Marks/PM/Center")]
    public bool pencil8;

    [LabelWidth(100)]
    [LabelText("9")]
    [VerticalGroup("Pencil Marks/PM/Right")]
    public bool pencil9;
    

}
