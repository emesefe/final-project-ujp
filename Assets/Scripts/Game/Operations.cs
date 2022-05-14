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
    [SerializeField] private TextMeshProUGUI operationText;
    [SerializeField] private TextMeshProUGUI[] solutionsText;
    
    private List<int> _solutions;
    public int solutionIdx { get; private set; }

    private void Start()
    {
        NewOperation();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewOperation();
        }
    }

    private void ShowOperation(int a, int b)
    {
        operationText.text = b < 0 ? $"{a} + ({b})" : $"{a} + {b}";
    }

    private int Operation(int a, int b)
    {
        return a + b;
    }

    private int GenerateRandomNumber(int figures, bool canBeNegative = false)
    {
        int max = (int) Mathf.Pow(10, figures);
        return Random.Range(canBeNegative ? -max + 1 : 0, max);
    }

    private int GenerateWrongSolution(int sol, bool canBeNegative = false)
    {
        int wrongSolution = sol;
        while (_solutions.Contains(wrongSolution))
        {
            wrongSolution = Random.Range(canBeNegative ? -2 * sol : 0, 2 * sol);
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

            solutionsText[i].text = GenerateWrongSolution(solution).ToString();
        }
    }

    private void NewOperation()
    {
        int a = GenerateRandomNumber(2);
        int b = GenerateRandomNumber(2);
        
        ShowOperation(a, b);

        ShowSolutions(a, b);
    }
}
