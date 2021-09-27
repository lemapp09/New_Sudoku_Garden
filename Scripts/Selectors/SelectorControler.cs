using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorControler : MonoBehaviour
{
    [Range(1, 9)]
    public int CurrentSelector; // which selector is currently active
    public GameObject[] SelectorGOs; //  List of the 9 numbered selectors
    public GameObject EraserGO;
    public GameObject PencilGO;
    SelectorStatus[] Selectors = new SelectorStatus[10];
    [Range(1, 3)]
    public int ThreeMethods; // 1- Marker, 2 - Eraser, 3 - Pencil
    public GameObject Settings;
    public AudioSource clickSound;
    public BoardData boardData;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 9; i++)
        {
            Selectors[i+1] = SelectorGOs[i].GetComponent<SelectorStatus>();
        }
        Settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) { Settings.SetActive(!Settings.activeSelf); }
        if ((Input.GetKeyDown(KeyCode.Alpha1)) || (Input.GetKeyDown(KeyCode.Keypad1))) {
            CurrentSelector = 1;
            PlaySound();
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2)) || (Input.GetKeyDown(KeyCode.Keypad1))) {
            CurrentSelector = 2;
            PlaySound();
        }
        if ((Input.GetKeyDown(KeyCode.Alpha3)) || (Input.GetKeyDown(KeyCode.Keypad1))) {
            CurrentSelector = 3;
            PlaySound();
        }
        if ((Input.GetKeyDown(KeyCode.Alpha4)) || (Input.GetKeyDown(KeyCode.Keypad1))) {
            CurrentSelector = 4;
            PlaySound();
        }
        if ((Input.GetKeyDown(KeyCode.Alpha5)) || (Input.GetKeyDown(KeyCode.Keypad1))) {
            CurrentSelector = 5;
            PlaySound();
        }
        if ((Input.GetKeyDown(KeyCode.Alpha6)) || (Input.GetKeyDown(KeyCode.Keypad1))) {
            CurrentSelector = 6;
            PlaySound();
        }
        if ((Input.GetKeyDown(KeyCode.Alpha7)) || (Input.GetKeyDown(KeyCode.Keypad1))) {
            CurrentSelector = 7;
            PlaySound();
        }
        if ((Input.GetKeyDown(KeyCode.Alpha8)) || (Input.GetKeyDown(KeyCode.Keypad1))) {
            CurrentSelector = 8;
            PlaySound();
        }
        if ((Input.GetKeyDown(KeyCode.Alpha9)) || (Input.GetKeyDown(KeyCode.Keypad1))) {
            CurrentSelector = 9;
            PlaySound();
        }

        boardData.CurrentSelector = CurrentSelector;
        ResetSelectors(CurrentSelector);
    }

    void ResetSelectors(int CurrentSelector)
    {
        for (var i = 1; i < 10; i++)
        {
            Selectors[i].selected = false;
        }
        Selectors[CurrentSelector].selected = true;
    }

    void PlaySound ()
    {
        clickSound.Play();
    }
}
