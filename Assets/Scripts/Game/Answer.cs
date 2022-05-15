using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Answer : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int answerIndex;

    private Operations operationsScript;

    private Color defaultColor = new Color(253 / 255f, 255 / 255f, 252 / 255f);
    private Color rightColor = new Color(76 / 255f, 185 / 255f, 68 / 255f);
    private Color wrongColor = new Color(240 / 255f, 101 / 255f, 67 / 255f);
    private Image _image;

    private float penaltySeconds = -5f;

    private void Start()
    {
        _image = GetComponent<Image>();
        operationsScript = FindObjectOfType<Operations>();
    }

    private bool IsRightAnswer()
    {
        return answerIndex == operationsScript.solutionIdx;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.sharedInstance.canClickOnAnswer)
        {
            StartCoroutine(AnswerOperation(IsRightAnswer()));
        }
    }

    private IEnumerator AnswerOperation(bool answeredCorrectly)
    {
        GameManager.sharedInstance.canClickOnAnswer = false;
        _image.color = answeredCorrectly ? rightColor : wrongColor;

        if (answeredCorrectly)
        {
            GameManager.sharedInstance.OneMoreRightAnswer();
        }
        else
        {
            GameManager.sharedInstance.UpdateTimer(penaltySeconds);
        }
        
        yield return new WaitForSeconds(2f);
        
        _image.color = defaultColor;
        GameManager.sharedInstance.canClickOnAnswer = true;
        
        if (!GameManager.sharedInstance.gameOver)
        {
            operationsScript.NewOperation();
        }
    }
}
