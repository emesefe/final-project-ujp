using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupMenuUIManager : MonoBehaviour
{
    public static SetupMenuUIManager sharedInstance;
    
    [SerializeField] private GameObject[] modeButtons;
    [SerializeField] private GameObject[] difficultyButtons;
    [SerializeField] private Button startButton;

    private Image startButtonImage;
    private TextMeshProUGUI startButtonText;
    
    private Color defaultColor = new Color(253 / 255f, 255 / 255f, 252 / 255f);
    private Color selectedColor = new Color(248 / 255f, 150 / 255f, 216 / 255f);
    private Color notInteractiveColor = new Color(0.2980392f, 0.2980392f, 0.2980392f, 0.5f);

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        startButtonImage = startButton.GetComponent<Image>();
        startButtonText = startButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        bool isInteractive = !(PersistentData.selectedMode == Mode.None ||
                                PersistentData.selectedDifficulty == Difficulty.None);
        IsStartButtonInteractive(isInteractive);
    }

    public void OnSelectedMode(){
        foreach (GameObject button in modeButtons)
        {
            Image image = button.GetComponent<Image>();
            Mode mode = button.GetComponent<ModeSelector>().mode;
            image.color = PersistentData.selectedMode == mode ? selectedColor : defaultColor;
        }
    }
    
    public void OnSelectedDifficulty(){
        foreach (GameObject button in difficultyButtons)
        {
            Image image = button.GetComponent<Image>();
            Difficulty difficulty = button.GetComponent<DifficultySelector>().difficulty;
            image.color = PersistentData.selectedDifficulty == difficulty ? selectedColor : defaultColor;
        }
    }

    private void IsStartButtonInteractive(bool interactive)
    {
        if (interactive)
        {
            startButtonImage.color = defaultColor;
            startButtonText.color = defaultColor;
            startButton.interactable = true;
        }
        else
        {
            startButtonImage.color = notInteractiveColor;
            startButtonText.color = notInteractiveColor;
            startButton.interactable = false;
        }
    }
}
