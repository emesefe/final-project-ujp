using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Operations : MonoBehaviour
{
    public int solutionIdx { get; private set; }
    
    [SerializeField] protected TextMeshProUGUI operationText;
    [SerializeField] protected TextMeshProUGUI[] solutionsText;

    protected bool canBeNegative = true;
    
    private List<int> _solutions;
    private int _figuresPerDifficulty = 2;

    private void Start()
    {
        NewOperation();
        _figuresPerDifficulty = FiguresPerDifficulty();
    }

    protected virtual void ShowOperation(int a, int b)
    {
        operationText.text = b < 0 ? $"{a} + ({b})" : $"{a} + {b}";
    }

    protected virtual int Operation(int a, int b)
    {
        return a + b;
    }

    private int GenerateRandomNumber(int figures, bool numCanBeNegative = false)
    {
        int max = (int) Mathf.Pow(10, figures);
        return Random.Range(numCanBeNegative ? -max + 1 : 0, max);
    }

    private int GenerateWrongSolution(int sol, bool numCanBeNegative = false)
    {
        int wrongSolution = sol;
        while (_solutions.Contains(wrongSolution))
        {
            wrongSolution = Random.Range(numCanBeNegative ? -2 * sol : 0, 2 * sol);
        }

        _solutions.Add(wrongSolution);
        return wrongSolution;
    }

    private void ShowSolutions(int a, int b)
    {
        int solution = Operation(a, b);
        solutionIdx = Random.Range(0, solutionsText.Length);
        solutionsText[solutionIdx].text = solution.ToString();
        
        _solutions = new List<int>();
        _solutions.Add(solution);
        
        for (int i = 0; i < solutionsText.Length; i++)
        {
            if (i == solutionIdx)
            {
                continue;
            }

            solutionsText[i].text = GenerateWrongSolution(solution, canBeNegative).ToString();
        }
    }

    private int FiguresPerDifficulty()
    {
        if (PersistentData.selectedDifficulty == Difficulty.Easy)
        {
            return 2;
        }
        
        if (PersistentData.selectedDifficulty == Difficulty.Medium)
        {
            return 3;
        }
        
        // if (PersistentData.selectedDifficulty == Difficulty.Hard)
        return 4;
    }

    public void NewOperation()
    {
        int a = GenerateRandomNumber(_figuresPerDifficulty, canBeNegative);
        int b = GenerateRandomNumber(_figuresPerDifficulty, canBeNegative);
        
        ShowOperation(a, b);

        ShowSolutions(a, b);
    }
}
