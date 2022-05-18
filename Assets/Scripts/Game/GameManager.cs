using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    
    public bool canClickOnAnswer = true;
    public bool gameOver;
    

    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private GameObject[] modes;
    
    [SerializeField] private AudioSource sfxAS;
    [SerializeField] private AudioClip rightClip, wrongClip;

    private int rightAnswersCounter;
    private float startTime = 90f; // 1:30 por ronda
    private float t;
    private Animator timerAnimator;

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
        rightAnswersCounter = 0;
        UpdateRightAnswerCounterText();

        t = startTime;
        UpdateTimerText(t);
        StartCoroutine(Timer());

        canClickOnAnswer = true;
        gameOver = false;

        timerAnimator = timer.gameObject.GetComponent<Animator>();
        
        ActiveSelectedMode();

        Time.timeScale = 1;

        sfxAS.mute = !PersistentData.sfxOn;
        sfxAS.volume = PersistentData.sfxVolume;
    }

    private void UpdateRightAnswerCounterText()
    {
        counter.text = rightAnswersCounter.ToString();
    }
    
    private void UpdateTimerText(float t)
    {
        if (t >= 0)
        {
            string minutes = ((int) t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");
            timer.text = $"{minutes}:{seconds}";
        }
        else
        {
            timer.text = "00:00";
        }
    }

    private IEnumerator Timer()
    {
        while (t > 0)
        {
            yield return new WaitForSeconds(1f);
            t--;
            UpdateTimerText(t);
        }

        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        canClickOnAnswer = false;
        gameOver = true;

        PersistentData.score = rightAnswersCounter;
        int currentBestScore =
            PersistentData.bestScores[PersistentData.selectedDifficulty][(int) PersistentData.selectedMode];
        if (rightAnswersCounter > currentBestScore)
        {
            PersistentData.bestScores[PersistentData.selectedDifficulty][(int) PersistentData.selectedMode] = 
                rightAnswersCounter;
        }
        
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game Over");
    }

    private void ActiveSelectedMode()
    {
        for (int i = 0; i < modes.Length; i++)
        {
            modes[i].SetActive(PersistentData.selectedMode == (Mode) i);
        }
    }
    
    public void OneMoreRightAnswer()
    {
        rightAnswersCounter++;
        UpdateRightAnswerCounterText();
    }

    public void UpdateTimer(float time)
    {
        t += time;
        UpdateTimerText(t);
        if (time < 0)
        {
            timerAnimator.SetTrigger("timePenalty");
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void PlayRightAnswerClip()
    {
        sfxAS.PlayOneShot(rightClip);
    }
    
    public void PlayWrongAnswerClip()
    {
        sfxAS.PlayOneShot(wrongClip);
    }
}
