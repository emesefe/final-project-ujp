using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupMenuUIManager : MonoBehaviour
{
    public static SetupMenuUIManager sharedInstance;
    
    [SerializeField] private GameObject[] modeButtons;
    
    private Color defaultColor = new Color(253 / 255f, 255 / 255f, 252 / 255f);
    private Color selectedColor = new Color(248 / 255f, 150 / 255f, 216 / 255f);

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
    
    public void OnSelectedMode(){
        foreach (GameObject button in modeButtons)
        {
            Image image = button.GetComponent<Image>();
            Mode mode = button.GetComponent<ModeSelector>().mode;
            image.color = PersistentData.selectedMode == mode ? selectedColor : defaultColor;
        }
    }
}
