using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TreasuryManager
{


    #region Constant Variables
    public const int VALUE_TOWNCENTRE = 15;      //0
    public const int VALUE_HOUSE = 125;     //1
    public const int VALUE_LIBRARY = 775;     //2
    public const int VALUE_FACTORY = 775;     //3
    public const int VALUE_MTOWER = 1450;    //4
    public const int VALUE_ROAD = 65;      //5
    public const int VALUE_BLOCKADE = 125;     //6
    public const int VALUE_WONDER = 125000;  //7
    public const int VALUE_GRASSLAND = 0;       //8 (default)
    #endregion

    #region Getters & Setters
    //-----------------------------------
    private static int p_Coin;
    private static int p_politicalPoints;
    //
    private static int gainRate_TownCentre;
    private static int gainRate_House;
    private static int gainRate_Library;
    private static int gainRate_Factory;
    private static int gainRate_MTower;
    private static int gainRate_Road;
    private static int gainRate_Blockade;
    private static int gainRate_Wonder;
    private static int gainRate_Grassland;
    //
    private static int multiplier_TownCentre;
    private static int multiplier_House;
    private static int multiplier_Library;
    private static int multiplier_Factory;
    private static int multiplier_MTower;
    private static int multiplier_Road;
    private static int multiplier_Blockade;
    private static int multiplier_Wonder;
    private static int multiplier_Grassland;
    //-----------------------------------

    //--------------------------------------------------------------------------------------------------------------
    public static int P_Coin { get { return p_Coin; } set { p_Coin = value; } }
    public static int P_PoliticalPoints { get { return p_politicalPoints; } set { p_politicalPoints = value; } }
    //
    public static int GainRate_TownCentre { get { return gainRate_TownCentre; } set { gainRate_TownCentre = value; } }     
    public static int GainRate_House { get { return gainRate_House; } set { gainRate_House = value; } }		
    public static int GainRate_Library { get { return gainRate_Library; } set { gainRate_Library = value; } }		
    public static int GainRate_Factory { get { return gainRate_Factory; } set { gainRate_Factory = value; } }		
    public static int GainRate_MTower { get { return gainRate_MTower; } set { gainRate_MTower = value; } }	
    public static int GainRate_Road { get { return gainRate_Road; } set { gainRate_Road = value; } }		
    public static int GainRate_Blockade { get { return gainRate_Blockade; } set { gainRate_Blockade = value; } }		
    public static int GainRate_Wonder { get { return gainRate_Wonder; } set { gainRate_Wonder = value; } }      
    public static int GainRate_Grassland { get { return gainRate_Grassland; } set { gainRate_Grassland = value; } }
    //
    public static int Multiplier_TownCentre { get { return multiplier_TownCentre; } set { multiplier_TownCentre = value; } }
    public static int Multiplier_House { get { return multiplier_House; } set { multiplier_House = value; } }
    public static int Multiplier_Library { get { return multiplier_Library; } set { multiplier_Library = value; } }
    public static int Multiplier_Factory { get { return multiplier_Factory; } set { multiplier_Factory = value; } }
    public static int Multiplier_MTower { get { return multiplier_MTower; } set { multiplier_MTower = value; } }
    public static int Multiplier_Road { get { return multiplier_Road; } set { multiplier_Road = value; } }
    public static int Multiplier_Blockade { get { return multiplier_Blockade; } set { multiplier_Blockade = value; } }
    public static int Multiplier_Wonder { get { return multiplier_Wonder; } set { multiplier_Wonder = value; } }
    public static int Multiplier_Grassland { get { return multiplier_Grassland; } set { multiplier_Grassland = value; } }
    //
    public static void InitialiseBuildingValues()
    {

    }
    //--------------------------------------------------------------------------------------------------------------






    #endregion
#pragma warning disable format
    #region Helper Methods
    public static int SellBuilding(string building)
	{
		int building_Id = 111;
			 if    (building.Contains("TownCentre"))   building_Id = 0;
		else if    (building.Contains("House"))        building_Id = 1;
		else if    (building.Contains("Library"))      building_Id = 2;
		else if    (building.Contains("Factory"))      building_Id = 3;
		else if    (building.Contains("MTower"))       building_Id = 4;
		else if    (building.Contains("Road"))         building_Id = 5;
		else if    (building.Contains("Blockade"))     building_Id = 6;
		else if    (building.Contains("Wonder"))       building_Id = 7;
		   else if (building.Contains("Grassland"))    building_Id = 8;

	 const int SELLRATE = 3;//add public accessor and move this if i setup difficulty levels for single player mode?
		switch (building_Id)
		{
			case 0:     return   VALUE_TOWNCENTRE  /   SELLRATE;
			case 1:     return   VALUE_HOUSE       /   SELLRATE;
			case 2:     return   VALUE_LIBRARY     /   SELLRATE;
			case 3:     return   VALUE_FACTORY     /   SELLRATE;
			case 4:     return   VALUE_MTOWER      /   SELLRATE;
			case 5:     return   VALUE_ROAD        /   SELLRATE;
			case 6:     return   VALUE_BLOCKADE    /   SELLRATE;
			case 7:     return   VALUE_WONDER      /   SELLRATE;
			   default: return   VALUE_GRASSLAND   /   SELLRATE;
		}
	}
	public static int BuyBuilding(string building)
	{
		int building_Id = 0;
			 if     (building.Contains("TownCentre"))    building_Id = 0;
		else if     (building.Contains("House"))         building_Id = 1;
		else if     (building.Contains("Library"))       building_Id = 2;
		else if     (building.Contains("Factory"))       building_Id = 3;
		else if     (building.Contains("MTower"))        building_Id = 4;
		else if     (building.Contains("Road"))          building_Id = 5;
		else if     (building.Contains("Blockade"))      building_Id = 6;
		else if     (building.Contains("Wonder"))        building_Id = 7;
			else if (building.Contains("Grassland"))     building_Id = 8;

		switch (building_Id)
		{
			case 0:         return VALUE_TOWNCENTRE;
			case 1:         return VALUE_HOUSE;
			case 2:         return VALUE_LIBRARY;
			case 3:         return VALUE_FACTORY;
			case 4:         return VALUE_MTOWER;
			case 5:         return VALUE_ROAD;
			case 6:         return VALUE_BLOCKADE;
			case 7:         return VALUE_WONDER;
				default:    return VALUE_GRASSLAND;
		}
	}
    #endregion
#pragma warning restore format

    #region Executor Methods
    public static void NewGame()
    {

    }
    /// <summary>
    /// Input: operation == 0 or 1; subtract or add.
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="coin"></param>
    /// <returns></returns>
    public static void UpdateCoin(int operation, int coin)
    {
        switch (operation)
        {
            case 0: P_Coin -= coin; break;
            case 1: P_Coin += coin; break;
        }
    }

    /// <summary>
    /// Input: operation == 0 or 1; subtract or add.
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="coin"></param>
    /// <returns></returns>
    public static void UpdatePoliticalPoints(int operation, int politicalPoints)
    {
        switch (operation)
        {
            case 0: P_PoliticalPoints -= politicalPoints; break;
            case 1: P_PoliticalPoints += politicalPoints; break;
        }
    }
    #endregion


}
