using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEditor.Analytics;
using Random = UnityEngine.Random;

public class Operations : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI operationText;
    [SerializeField] protected TextMeshProUGUI[] solutionsText;

    protected bool canBeNegative = true;
    
    private List<int> _solutions;
    public int solutionIdx { get; private set; }

    private void Start()
    {
        NewOperation();
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

    public void NewOperation()
    {
        int a = GenerateRandomNumber(2, canBeNegative);
        int b = GenerateRandomNumber(2, canBeNegative);
        
        ShowOperation(a, b);

        ShowSolutions(a, b);
    }
}
