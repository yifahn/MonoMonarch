using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerCharacterStaticClass
{//playerLevel2, playerXP2, playerScore2, playerPP2, playerConstitution2, playerStamina2, playerStrength2, playerDefence2, playerLuck2, playerName2, playerClass2;
    public static int playerHealth, playerHealthMax, playerStamina, playerStaminaMax, playerStrength, playerDefence, playerLuck,playerLevel,playerPP,playerXP;
    public static string playerName, playerClass;
    public static bool isPlayerActive;
    public static string saveDir;
    public static string saveFileName;

    public static double playerScore;
    public static int PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }
    public static int PlayerStamina
    {
        get { return playerStamina; }
        set { playerStamina = value; }
    }
    public static int PlayerXP
    {
        get { return playerXP; }
        set { playerXP = value; }
    }
    public static int PlayerLevel
    {
        get { return playerLevel; }
        set { playerLevel = value; }
    }
    public static double PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }
    public static int PlayerPP
    {
        get { return playerPP; }
        set { playerPP = value; }
    }
    public static int PlayerDefence
    {
        get { return playerDefence; }
        set { playerDefence = value; }
    }
    public static int PlayerLuck
    {
        get { return playerLuck; }
        set { playerLuck = value; }
    }
    public static int PlayerStrength
    {
        get { return playerStrength; }
        set { playerStrength = value; }
    }
    public static int PlayerStaminaMax
    {
        get { return playerStaminaMax; }
        set { playerStaminaMax = value; }
    }
    public static int PlayerHealthMax
    {
        get { return playerHealthMax; }
        set { playerHealthMax = value; }
    }
    public static string PlayerClass
    {
        get { return playerClass; }
        set { playerClass = value; }
    }
    public static string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    public static string SaveDir
    {
        get { return saveDir; }
        set { saveDir = value; }
    }
    public static string SaveFileName
    {
        get { return saveFileName; }
        set { saveFileName = value; }
    }
    public static bool IsPlayerActive
    {
        get { return isPlayerActive; }
        set { isPlayerActive = value; }
    }
   /* public static void NewGame()
    {

    }*/
    public static int[] CalculatedClass(string className)
    {
        int[] playerStatsArray = new int[5];

        switch (className)
        {
            case "Assassin":
                playerStatsArray[0] = (int)Random.Range(-5, -2); //health
                playerStatsArray[1] = (int)Random.Range(2, 5);   //stamina
                playerStatsArray[2] = 0;                        //strength
                playerStatsArray[3] = (int)Random.Range(-5, -2); //defence
                playerStatsArray[4] = 0;                        //luck

                break;
            case "Tank":
                playerStatsArray[0] = (int)Random.Range(3, 6);
                playerStatsArray[1] = -2;
                playerStatsArray[2] = -2;
                playerStatsArray[3] = (int)Random.Range(3, 6);
                playerStatsArray[4] = 0;
                break;
            case "Grunt":
                playerStatsArray[0] = 0;
                playerStatsArray[1] = (int)Random.Range(2, 5);
                playerStatsArray[2] = (int)Random.Range(2, 5);
                playerStatsArray[3] = (int)Random.Range(-5, -2);
                playerStatsArray[4] = (int)Random.Range(-5, -2);
                break;
            case "Commander":
                playerStatsArray[0] = (int)Random.Range(-3, -1);
                playerStatsArray[1] = (int)Random.Range(-6, -3);
                playerStatsArray[2] = (int)Random.Range(2, 5);
                playerStatsArray[3] = (int)Random.Range(2, 5);
                playerStatsArray[4] = (int)Random.Range(-5, 5);
                break;
            case "Peacekeeper":
                playerStatsArray[0] = (int)Random.Range(2, 5);
                playerStatsArray[1] = (int)Random.Range(-3, -1);
                playerStatsArray[2] = (int)Random.Range(-3, -1);
                playerStatsArray[3] = (int)Random.Range(-3, -1);
                playerStatsArray[4] = (int)Random.Range(4, 8);
                break;
            case "Chaos":
                playerStatsArray[0] = (int)Random.Range(-2, 2);
                playerStatsArray[1] = (int)Random.Range(-2, 2);
                playerStatsArray[2] = (int)Random.Range(-2, 2);
                playerStatsArray[3] = (int)Random.Range(-2, 2);
                playerStatsArray[4] = (int)Random.Range(-2, 2);
                break;
        }
        return playerStatsArray;
    }

}
