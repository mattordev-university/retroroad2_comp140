using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    [SerializeField] private Button MainButton;
    [SerializeField] private Button HighscoreButton;
    [SerializeField] private Dropdown OptionsButton;
    [SerializeField] private Button CarPickerButton;
    [SerializeField] private Button LevelPickerButton;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenMain()
    {
        MainButton.Select();
    }

    public void OpenHighScore()
    {
        HighscoreButton.Select();
    }

    public void OpenOptions()
    {
        OptionsButton.Select();
    }

    public void OpenCarPicker()
    {
        CarPickerButton.Select();
    }
    public void OpenLevelPicker()
    {
        LevelPickerButton.Select();
    }
}
