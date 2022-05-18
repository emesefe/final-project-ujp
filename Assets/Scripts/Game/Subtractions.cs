using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtractions : Operations
{
    private void Awake()
    {
        canBeNegative = true;
    }
    
    protected override void ShowOperation(int a, int b)
    {
        operationText.text = b < 0 ? $"{a} - {-b}" : $"{a} + {b}";
    }

    protected override int Operation(int a, int b)
    {
        return a + b;
    }
}
