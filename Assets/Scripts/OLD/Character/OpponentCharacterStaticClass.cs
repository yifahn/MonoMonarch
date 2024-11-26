using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OpponentCharacterStaticClass
{
    public static int opponentHealth, opponentHealthMax, opponentStamina, opponentStaminaMax, opponentStrength, opponentDefence, opponentLuck;
    public static void SaveToFile()
    {

    }
    public static void LoadFromFile()
    {

    }
    public static void NewGameForDevTesting()
    {
        opponentHealthMax = 10;
        opponentHealth = 10;
        opponentStamina = 10;
        opponentStaminaMax = 10;
        opponentStrength = 10;
        opponentDefence = 10;
        opponentLuck = 10;
    }
}
