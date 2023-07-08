using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    public int playerHealth, playerHealthMax, playerStamina, playerStaminaMax, playerStrength, playerDefence, playerLuck;
    public string playerName;
    public string playerClass;
    public GameObject playerCreate, btnOK2, dropDown2, playerName2;
    public List<string> classList;
    public GameObject menuKeeper;

    public void Start()
    {
        menuKeeper = GameObject.Find("MenuKeeper");
    }

    public void InitiatePlayerCreation()
    {
        playerCreate = GameObject.Find("PanelPlayerCreate");
        btnOK2 = GameObject.Find("BtnOK2");
        dropDown2 = GameObject.Find("Dropdown2");
        playerName2 = GameObject.Find("TextUsername");
        CreatePlayerConfirm();
        menuKeeper.GetComponent<SceneLoader>().NewGame();
    }
    public void CreatePlayerConfirm()
    {


        PlayerCharacterStaticClass.PlayerName = playerName2.GetComponent<TMP_Text>().text.Trim('\r', '\n');
        CreateStatsOffClass();

    }
    public void CreateStatsOffClass()
    {
        // Debug.Log("chosen " + dropDown2.GetComponent<TMP_Dropdown>().captionText.@text + " class");//Debug.Log("chosen " + dropDown2.GetComponent<TMP_Dropdown>().captionText.@text + " class");
        PlayerCharacterStaticClass.PlayerClass = dropDown2.GetComponent<TMP_Dropdown>().captionText.@text;
        playerClass = PlayerCharacterStaticClass.playerClass;
        Debug.Log(playerClass);//ss
        Debug.Log(dropDown2.GetComponent<TMP_Dropdown>().captionText.@text);
        Debug.Log(dropDown2.GetComponentInChildren<TMP_Text>().text);
        int[] statArray = PlayerCharacterStaticClass.CalculatedClass(playerClass);
        //Dropdown.options[Dropdown.value].text);
        PlayerCharacterStaticClass.PlayerHealthMax += (10 + statArray[0]);
        PlayerCharacterStaticClass.PlayerStaminaMax += (10 + statArray[1]);
        PlayerCharacterStaticClass.PlayerStrength += (10 + statArray[2]);
        PlayerCharacterStaticClass.PlayerDefence += (10 + statArray[3]);
        PlayerCharacterStaticClass.PlayerLuck += (10 + statArray[4]);
        Debug.Log(PlayerCharacterStaticClass.PlayerHealthMax);
        Debug.Log(PlayerCharacterStaticClass.PlayerStaminaMax);
        Debug.Log(PlayerCharacterStaticClass.PlayerStrength);
        Debug.Log(PlayerCharacterStaticClass.PlayerDefence);
        Debug.Log(PlayerCharacterStaticClass.PlayerLuck);



    }

}
