using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    None
}

public class DifficultySelector : MonoBehaviour
{
    public Difficulty difficulty;
    
    private Button _button;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SelectDifficulty);
        _button.onClick.AddListener(SetupMenuUIManager.sharedInstance.OnSelectedDifficulty);
        
        PersistentData.selectedDifficulty = Difficulty.None;
    }

    private void SelectDifficulty()
    {
        PersistentData.selectedDifficulty = difficulty;
    }
}
