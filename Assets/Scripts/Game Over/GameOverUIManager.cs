using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, bestScoreText, mode, difficulty;
    
    void Start()
    {
        scoreText.text = PersistentData.score.ToString();
        bestScoreText.text = PersistentData.bestScores[PersistentData.selectedDifficulty]
            [(int) PersistentData.selectedMode].ToString();
        mode.text = PersistentData.selectedMode.ToString();
        difficulty.text = PersistentData.selectedDifficulty.ToString();
    }
}
