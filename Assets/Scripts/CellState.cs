using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public static class CellState
{


    public static bool createGrasslandBool, createForestBool, createFarmBool, createAATowerBool, createMTowerBool, createRoadBool, createBlockadeBool, createHouseBool, createCityCentreBool, createLibraryBool, createFactoryBool, createWonderBool;
    public static string playerSpawn, opponentSpawn;
    public static bool playerSpawnBool, opponentSpawnBool;
    public static List<string> mapListL1, mapListL2;


    public static List<string> MapListL1
    {
        get { return mapListL1; }
        set { mapListL1 = value; }
    }
    public static List<string> MapListL2
    {
        get { return mapListL2; }
        set { mapListL2 = value; }
    }
    public static void MapListL1Allocate()
    {
        mapListL1 = new List<string>();//ss
    }
    public static void MapListL2Allocate()
    {
        mapListL2 = new List<string>();
    }

    public static bool PlayerSpawnBool
    {
        get { return playerSpawnBool; }
        set { playerSpawnBool = value; }
    }
    public static bool OpponentSpawnBool
    {
        get { return opponentSpawnBool; }
        set { opponentSpawnBool = value; }
    }

    public static string PlayerSpawn
    {
        get { return playerSpawn; }
        set { playerSpawn = value; }
    }
    public static string OpponentSpawn
    {
        get { return opponentSpawn; }
        set { opponentSpawn = value; }
    }

    public static bool CreateGrasslandBool
    {
        get { return createGrasslandBool; }
        set { createGrasslandBool = value; }
    }
    public static bool CreateFarmBool
    {
        get { return createFarmBool; }
        set { createFarmBool = value; }
    }
    public static bool CreateForestBool
    {
        get { return createForestBool; }
        set { createForestBool = value; }
    }
    public static bool CreateAATowerBool
    {
        get { return createAATowerBool; }
        set { createAATowerBool = value; }
    }
    public static bool CreateMTowerBool
    {
        get { return createMTowerBool; }
        set { createMTowerBool = value; }
    }
    public static bool CreateRoadBool
    {
        get { return createRoadBool; }
        set { createRoadBool = value; }
    }
    public static bool CreateBlockadeBool
    {
        get { return createBlockadeBool; }
        set { createBlockadeBool = value; }
    }
    public static bool CreateHouseBool
    {
        get { return createWonderBool; }
        set { createWonderBool = value; }
    }
    public static bool CreateCityCentreBool
    {
        get { return createCityCentreBool; }
        set { createCityCentreBool = value; }
    }
    public static bool CreateLibraryBool
    {
        get { return createLibraryBool; }
        set { createLibraryBool = value; }
    }
    public static bool CreateFactoryBool
    {
        get { return createFactoryBool; }
        set { createFactoryBool = value; }
    }
    public static bool CreateWonderBool
    {
        get { return createWonderBool; }
        set { createWonderBool = value; }
    }




}
