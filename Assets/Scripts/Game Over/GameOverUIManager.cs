using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText, bestScoreText;
    
    void Start()
    {
        scoreText.text = PersistentData.score.ToString();
        bestScoreText.text = PersistentData.bestScore.ToString();
    }
}
