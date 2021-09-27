using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class BoardData : MonoBehaviour
{
    CellData[] boardData = new CellData[82];
    int[] solvedData = { 7, 9, 2, 8, 3, 4, 1, 6, 5, 8, 3, 4, 1, 6, 5, 7, 9, 2, 1, 6, 5, 7, 9, 2, 8, 3, 4,
                6, 5, 7, 9, 2, 8, 3, 4, 1, 9, 2, 8, 3, 4, 1, 6, 5, 7, 3, 4, 1, 6, 5, 7, 9, 2, 8, 5, 7, 9,
                2, 8, 3, 4, 1, 6, 2, 8, 3, 4, 1, 6, 5, 7, 9, 4, 1, 6, 5, 7, 9, 2, 8, 3}; // 1 Dimension Board
    int[,] solvedData2 = new int[9, 9]; // 2 Dimension Board
    [Range(1, 81)]
    public int CurrentCell; // Which cell is currently selected and active
    [Range(1,9)]
    public int CurrentSelector; // Which Number Selector is active
    public bool[] HelpMeth = new bool[5];

    void Start()
    {
        // testingEquation();

        for (int i = 1; i < 82; i++)
        {
            boardData[i] = this.transform.GetChild(i).GetComponent<CellData>();
        }
        solvedData2 = SD1intoSD2(solvedData);
        if (VerifySD2(solvedData2)) {; } //  Debug.Log("sD2 is a Valid Sudoku Puzzle"); }

        for (var i = 1; i < 82; i++)
        {
            boardData[i].visible = GetRandomBool();
            boardData[i].displayValue = solvedData[i - 1];
            boardData[i].realValue = solvedData[i - 1];
        }
        for (int i = 1; i < 5; i++)
        {
            HelpMeth[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        EndOfGame();
    }

    void EndOfGame()
    {
        int CorrectCellCount = 0;
        for (var i = 1; i < 82; i++)
        {
            if ((boardData[i].visible) & (boardData[i].displayValue == boardData[i].realValue))
            {
                CorrectCellCount++;
            }
        }
        if (CorrectCellCount == 81)
        {
            Debug.Log("You've Won!");
        }
    }

    void UnHighlight()
    {
        for (int i = 1; i < 82; i++)
        {
            boardData[i].Highlighted = false;
        }
    }

    void HighlightSimilar()
    {
        int a = boardData[CurrentCell].displayValue;
        int value = boardData[CurrentCell].realValue;
        if ((boardData[CurrentCell].visible) & (a == value)) {
            for (int i = 1; i < 82; i++)
            {
                if ((boardData[i].realValue == value) & (boardData[i].visible))
                {
                    boardData[i].Highlighted = true;
                }
            }
        }
    }

    void HighlightLocation()
    {
        int row = boardData[CurrentCell].y;
        int col = boardData[CurrentCell].x;
        Debug.Log("Row: " + row + " , Col:" + col);
        for (int i = 1; i < 82; i++)
        {
            if ((boardData[i].x == col) || (boardData[i].y == row))
            {
                boardData[i].Highlighted = true;
            }
        }
    }

    void HighlightCell()
    {
        int row = ((boardData[CurrentCell].y - 1) / 3);
        int col = ((boardData[CurrentCell].x -1) / 3);
        int SuperCellStart = ((row * 27) + (col * 3)) + 1;
        boardData[SuperCellStart].Highlighted = true;
        boardData[SuperCellStart + 1].Highlighted = true;
        boardData[SuperCellStart + 2].Highlighted = true;
        boardData[SuperCellStart + 9].Highlighted = true;
        boardData[SuperCellStart + 10].Highlighted = true;
        boardData[SuperCellStart + 11].Highlighted = true;
        boardData[SuperCellStart + 18].Highlighted = true;
        boardData[SuperCellStart + 19].Highlighted = true;
        boardData[SuperCellStart + 20].Highlighted = true;
    }

    void HighlightErrors()
    {
        for (int i = 1; i < 82; i++)
        {
            if (boardData[i].realValue != boardData[i].displayValue)
            {
                boardData[i].Highlighted = true;
            }
        }
    }

    public void TogglehmSimilar()
    {
        UnHighlight();
        HelpMeth[1] = !HelpMeth[1];
        if (HelpMeth[1])
        {
            HighlightSimilar();
            HelpMeth[2] = false;
            HelpMeth[3] = false;
            HelpMeth[4] = false;
        }
    } // Toggles Helper Method Similar

    public void TogglehmLocation()
    {
        UnHighlight();
        HelpMeth[2] = !HelpMeth[2];
        if (HelpMeth[2])
        {
            HighlightLocation();
            HelpMeth[1] = false;
            HelpMeth[3] = false;
            HelpMeth[4] = false;
        }
    } // Toggles Helper Method Location

    public void TogglehmCells()
    {
        UnHighlight();
        HelpMeth[3] = !HelpMeth[3];
        if (HelpMeth[3])
        {
            HighlightCell();
            HelpMeth[1] = false;
            HelpMeth[2] = false;
            HelpMeth[4] = false;
        }
    } // Toggles Helper Method Cells 
    public void TogglehmErrors()
    {
        UnHighlight();
        HelpMeth[4] = !HelpMeth[4];
        if (HelpMeth[4])
        {
            HighlightErrors();
            HelpMeth[1] = false;
            HelpMeth[2] = false;
            HelpMeth[3] = false;
        }
    } // Toggles Helper Method Errors

    bool GetRandomBool()
    {
        int randomNumber = Random.Range(0, 100);
        return (randomNumber % 2 == 0) ? true : false;
    }

    int[,] SD1intoSD2 (int[] solvedData)
    {
        int k = 0;
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            { 
                solvedData2[i, j] = solvedData[k];
                k++;
            }
        }
        return solvedData2; 
    }

    bool VerifySD2(int[,] solvedData2)
    {
        int[] superCells = new int[9];
        int k = 0;
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                k = k + solvedData2[i, j];
            }
            if (k != 45) {
                Debug.Log("sD2 Puzzle failed! Line- I:" + i + " , K: " + k);
                return false;
            }
            k = 0;
        }

        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                k = k + solvedData2[j, i];
            }
            if (k != 45)
            {
                Debug.Log("sD2 Puzzle failed! Column- I:" + i);
                return false;
            }
            k = 0;
        }
        superCells[1] = 4;  
        for (var i = 0; i < 9;  i += 3) 
            {
            k = solvedData2[i, i] + solvedData2[i + 1, i] + solvedData2[i + 2, i];
            k = k + solvedData2[i, i + 1] + solvedData2[i + 1, i + 1] + solvedData2[i + 2, i + 1];
            k = k +solvedData2[i, i + 2] + solvedData2[i + 1, i + 2] + solvedData2[i + 2, i + 2];
            if (k != 45)
            {
                Debug.Log(solvedData2[i, i] + solvedData2[i + 1, i] + solvedData2[i + 2, i]);
                Debug.Log(k = solvedData2[i, i + 1] + solvedData2[i + 1, i + 1] + solvedData2[i + 2, i + 1]);
                Debug.Log(k = solvedData2[i, i + 2] + solvedData2[i + 1, i + 2] + solvedData2[i + 2, i + 2]);
                Debug.Log("SuperCell failed at  I:" + i);
                return false;
            }
            k = 0;
        }
        for (var i = 3; i < 9; i += 3) 
        {
            k = solvedData2[i, i] + solvedData2[i + 1, i] + solvedData2[i + 2, i];
            k = k + solvedData2[i, i + 1] + solvedData2[i + 1, i + 1] + solvedData2[i + 2, i + 1];
            k = k + solvedData2[i, i + 2] + solvedData2[i + 1, i + 2] + solvedData2[i + 2, i + 2];
            if (k != 45)
            {
                Debug.Log("SuperCell failed at  I:" + i);
                return false;
            }
            k = 0;
        }
        for (var i = 6; i < 9; i += 3) 
        {
            k = solvedData2[i, i] + solvedData2[i + 1, i] + solvedData2[i + 2, i];
            k = k + solvedData2[i, i + 1] + solvedData2[i + 1, i + 1] + solvedData2[i + 2, i + 1];
            k = k + solvedData2[i, i + 2] + solvedData2[i + 1, i + 2] + solvedData2[i + 2, i + 2];
            if (k != 45)
            {
                Debug.Log("SuperCell failed at  I:" + i);
                return false;
            }
            k = 0;
        }

        return true; 
    }

}
