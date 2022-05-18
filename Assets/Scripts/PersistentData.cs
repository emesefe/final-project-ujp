using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistentData
{
    public static int score;
    public static Mode selectedMode = Mode.None;
    public static Difficulty selectedDifficulty = Difficulty.None;
    
    public static Dictionary<Difficulty, int[]> bestScores = new Dictionary<Difficulty, int[]>()
    {
        {Difficulty.Easy, new int[]{0, 0, 0}}, // Order: Sums, Subtractions, Products
        {Difficulty.Medium, new int[]{0, 0, 0}}, // Order: Sums, Subtractions, Products
        {Difficulty.Hard, new int[]{0, 0, 0}} // Order: Sums, Subtractions, Products
    };

    public static float musicVolume = 0.2f;
    public static bool musicOn = true;
    
    public static float sfxVolume = 1f;
    public static bool sfxOn = true;
}
