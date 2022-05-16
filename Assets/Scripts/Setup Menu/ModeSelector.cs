using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Mode
{
    Sums,
    Subtractions,
    Products,
    Fractions,
    None
}

public class ModeSelector : MonoBehaviour
{
    public Mode mode;
    
    private Button _button;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SelectMode);
        _button.onClick.AddListener(SetupMenuUIManager.sharedInstance.OnSelectedMode);
        
        PersistentData.selectedMode = Mode.None;
    }

    private void SelectMode()
    {
        PersistentData.selectedMode = mode;
    }

}
