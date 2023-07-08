using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCharacter : MonoBehaviour
{
    public double playerHealth, playerHealthMax, playerStamina, playerStaminaMax, playerStrength, playerDefence, playerLuck,playerLevel,playerXP,playerScore;
    public int playerPP;
    public string playerName, playerClass;
    public GameObject playerLevel2, playerXP2, playerScore2, playerPP2, playerConstitution2, playerStamina2, playerStrength2, playerDefence2, playerLuck2, playerName2, playerClass2;
    
    public GameObject soupTimer;
    public float soupTimerDouble;

    public void Start()
    {
        //Find GameObjects and assign to script vars
        playerConstitution2 = GameObject.Find("ConstitutionStat");
        playerStamina2 = GameObject.Find("StaminaStat");
        playerStrength2 = GameObject.Find("StrengthStat");
        playerDefence2 = GameObject.Find("DefenceStat");
        playerLuck2 = GameObject.Find("LuckStat");
        playerClass2 = GameObject.Find("ClassStat");
        playerName2 = GameObject.Find("NameTMP");
        playerLevel2 = GameObject.Find("LevelTMP");
        playerXP2 = GameObject.Find("XPTMP");
        playerScore2 = GameObject.Find("ScorelTMP");
        playerPP2 = GameObject.Find("PoliticalPointsTMP");
        soupTimer = GameObject.Find("TimeSoupTMP");

        //get player info 
        playerHealthMax = PlayerCharacterStaticClass.PlayerHealthMax;
        playerStaminaMax = PlayerCharacterStaticClass.PlayerStaminaMax;
        playerStrength = PlayerCharacterStaticClass.PlayerStrength;
        playerDefence = PlayerCharacterStaticClass.PlayerDefence;
        playerLuck = PlayerCharacterStaticClass.PlayerLuck;
        playerName = PlayerCharacterStaticClass.PlayerName.Trim('\r', '\n');
        playerClass = PlayerCharacterStaticClass.PlayerClass.Trim('\r', '\n');
        playerLevel = PlayerCharacterStaticClass.PlayerLevel;
        playerXP = PlayerCharacterStaticClass.PlayerXP;
        playerPP = PlayerCharacterStaticClass.PlayerPP;
        
        soupTimerDouble = 3f; // 3 seconds refresh time for dev testing

        //display player info
        playerConstitution2.GetComponent<TMP_Text>().text = playerHealthMax.ToString();
        playerStamina2.GetComponent<TMP_Text>().text = playerStaminaMax.ToString();
        playerStrength2.GetComponent<TMP_Text>().text = playerStrength.ToString();
        playerDefence2.GetComponent<TMP_Text>().text = playerDefence.ToString();
        playerLuck2.GetComponent<TMP_Text>().text = playerLuck.ToString();
        playerClass2.GetComponent<TMP_Text>().text = playerClass;
        playerName2.GetComponent<TMP_Text>().text = playerName;
        playerLevel2.GetComponent<TMP_Text>().text = "Level: " +playerLevel.ToString();
        playerXP2.GetComponent<TMP_Text>().text = "Experience: " + playerXP.ToString(); 
        playerScore2.GetComponent<TMP_Text>().text = playerScore.ToString(); 
        playerPP2.GetComponent<TMP_Text>().text = "Political Points: " + playerPP.ToString();
        soupTimer.GetComponent<TMP_Text>().text = "Soup Timer: " + soupTimerDouble.ToString();
    }
    public void PopulateStatsElement()
    {
        playerHealthMax = PlayerCharacterStaticClass.PlayerHealthMax;
        playerStaminaMax = PlayerCharacterStaticClass.PlayerStaminaMax;
        playerStrength = PlayerCharacterStaticClass.PlayerStrength;
        playerDefence = PlayerCharacterStaticClass.PlayerDefence;
        playerLuck = PlayerCharacterStaticClass.PlayerLuck;
        //playerPP = PlayerCharacterStaticClass.PlayerPP;
        //playerName = PlayerCharacterStaticClass.PlayerName;
       // playerClass = PlayerCharacterStaticClass.PlayerClass;
       // playerLevel = PlayerCharacterStaticClass.PlayerLevel;
        //playerXP = PlayerCharacterStaticClass.PlayerXP;
        //soupTimerDouble = 3f; // 3 seconds refresh time for dev testing

        //display player info
        playerConstitution2.GetComponent<TMP_Text>().text = playerHealthMax.ToString();
        playerStamina2.GetComponent<TMP_Text>().text = playerStaminaMax.ToString();
        playerStrength2.GetComponent<TMP_Text>().text = playerStrength.ToString();
        playerDefence2.GetComponent<TMP_Text>().text = playerDefence.ToString();
        playerLuck2.GetComponent<TMP_Text>().text = playerLuck.ToString();
        playerClass2.GetComponent<TMP_Text>().text = playerClass;
        //playerName2.GetComponent<TMP_Text>().text = playerName;
        //playerLevel2.GetComponent<TMP_Text>().text = playerLevel.ToString();
        //playerXP2.GetComponent<TMP_Text>().text = playerXP.ToString();
        //playerScore2.GetComponent<TMP_Text>().text = playerScore.ToString();
       // playerPP2.GetComponent<TMP_Text>().text = playerPP.ToString();
        //soupTimer.GetComponent<TMP_Text>().text = "Soup Timer: " + soupTimerDouble.ToString();
    }
    public void PopulateInventoryElement()
    {

    }





}


