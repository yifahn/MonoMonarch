using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCharacter : MonoBehaviour
{
    public int opponentHealth, opponentHealthMax, opponentStamina, opponentStaminaMax, opponentStrength, opponentDefence, opponentLuck;

    public void Start()
    {
        
    }
    public void GetPersistentData()
    {
        opponentHealthMax = OpponentCharacterStaticClass.opponentHealthMax;
        opponentHealth = OpponentCharacterStaticClass.opponentHealth;
        opponentStamina = OpponentCharacterStaticClass.opponentStamina;
        opponentStaminaMax = OpponentCharacterStaticClass.opponentStaminaMax;
        opponentStrength = OpponentCharacterStaticClass.opponentStrength;
        opponentDefence = OpponentCharacterStaticClass.opponentDefence;
        opponentLuck = OpponentCharacterStaticClass.opponentLuck;
   
    }
 
}
