using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Products : Operations
{
    private void Awake()
    {
        canBeNegative = false;
    }

    protected override void ShowOperation(int a, int b)
    {
        operationText.text = $"{a} x {b}";
    }

    protected override int Operation(int a, int b)
    {
        return a * b;
    }
}
