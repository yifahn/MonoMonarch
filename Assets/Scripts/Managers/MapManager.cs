using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public static class MapManager
{

    #region Constructor
    static MapManager()
    {
        MapDimensions_X = 60; //set x and y via UI as a preset later, small/medium/large?
        MapDimensions_Y = 33;
        LoadNodePrefabs();
    }
    #endregion

    #region Getters & Setters
    private static Dictionary<int, GameObject> nodeMap;
    private static int mapDimensions_X;
    private static int mapDimensions_Y;
    private static Color color;
    private static int[] altNodeArray;
    public static Dictionary<int, GameObject> NodeMap { get { return nodeMap; } set { nodeMap = value; } }
    public static int MapDimensions_X { get { return mapDimensions_X; } set { mapDimensions_X = value; } }
    public static int MapDimensions_Y { get { return mapDimensions_Y; } set { mapDimensions_Y = value; } }
    public static Color Color { get { return color; } set { color = value; } }
    public static int[] AltNodeArray { get { return altNodeArray; } set { altNodeArray = value; } }
    #endregion

    #region Map Manager Methods
    public static void FillNodeMapGrassland()//game manager - new game
    {
        InitialiseNodeMap();
        for (int y = 1; y <= MapDimensions_Y; y++)
        {
            for (int x = 1; x <= MapDimensions_X; x++)
            {
                int n_Id = CalculateNodeId(x, y);
                NodeMap.Add(n_Id, Grassland);
            }
        }
    }
    public static void InitialiseNodeMap()
    {
        NodeMap = new Dictionary<int, GameObject>();
    }
    public static void SetMapDimensions(int x, int y)
    {
        MapDimensions_X = x;
        MapDimensions_Y = y;
    }
    public static void UpdateNodeDict(int old_N_Id, int newSelectedBuilding)
    {
        NodeMap[old_N_Id] = GetSelectedBuilding(newSelectedBuilding);
    }
    public static void InstantiateNode(int n_Id)
    {
        UnityEngine.Object.Instantiate(NodeMap[n_Id]);
    }
    public static void LoadNodeMap()
    {
        //do load function
    }
    public static void SaveNodeMap()
    {
        //do save function
    }

    #endregion

    #region Map Helper Methods
    /// <summary>
    /// find id (id is 0 based) from x and y pos
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static int CalculateNodeId(int x, int y)
    {
        int n_Id = (y - 1) * MapDimensions_X + (x - 1);
        return n_Id;
    }
    /// <summary>
    /// find x,y pos from id (id is 0 based)
    /// </summary>
    /// <returns></returns>
    public static int[] CalculateNodePos(int n_Id)
    {
        int[] nodePos = new int[2];
        nodePos[0] = (n_Id % 60) + 1;
        nodePos[1] = (n_Id / 60) + 1;
        return nodePos;
    }

    /// <summary>
    /// Provide n_Id of two nodes, returns array of n_Id within the bounds of n1 and n2 as rectangle
    /// </summary>
    public static int[] PopulateNodeArray(int n_1, int n_2)
    {
        int[] nodePos1 = CalculateNodePos(n_1);
        int[] nodePos2 = CalculateNodePos(n_2);
        int node_1X = nodePos1[0];
        int node_1Y = nodePos1[1];
        int node_2X = nodePos2[0];
        int node_2Y = nodePos2[1];
        List<int> nodeList = new List<int>();
        //-----------------------------------------------------------------------------------------
        if (node_1X < node_2X) //Orientation clarification: TopLeft == node1 is north west of node2.
        {
            if (node_1Y < node_2Y) nodeList = TopLeft(nodePos1, nodePos2); 
            else if (node_1Y > node_2Y) nodeList = BottomLeft(nodePos1, nodePos2);
            else if (node_1Y == node_2Y) nodeList = Left(nodePos1, nodePos2);
        }
        else if (node_1X > node_2X)
        {
            if (node_1Y < node_2Y) nodeList = TopRight(nodePos1, nodePos2);
            else if (node_1Y > node_2Y) nodeList = BottomRight(nodePos1, nodePos2);
            else if (node_1Y == node_2Y) nodeList = Right(nodePos1, nodePos2);
        }
        else if (node_1X == node_2X)
        {
            if (node_1Y < node_2Y) nodeList = Top(nodePos1, nodePos2);
            else if (node_1Y > node_2Y) nodeList = Bottom(nodePos1, nodePos2);
            else if (node_1Y == node_2Y) nodeList = Middle(nodePos1, nodePos2);
        }
        //-----------------------------------------------------------------------------------------
        AltNodeArray = new int[nodeList.Count];
        AltNodeArray = nodeList.ToArray();
        return AltNodeArray;
    }
    /// <summary>
    /// Alters material properties of input nodes to enable a degree of visual transparency
    /// </summary>
    /// <param name="opacity"></param>
    public static void SetOpacitySelection(int[] nodeArray, float opacity)
    {
        foreach (int n_Id in nodeArray)
        {
            Color = NodeMap[n_Id].GetComponent<Material>().color;
            Color highlight = new Color(Color.r, Color.g, Color.b, opacity);
            NodeMap[n_Id].GetComponent<Material>().SetColor("AdjustColor", highlight);
        }
    }

    #endregion

    #region Load Node Helper Methods
    /// <summary>
    /// Returns building as GameObject, requires input as integer = 0:TownCentre_1:House_2:Library_3:Factory_4:MTower_5:Road_6:Blockade_7:Wonder
    /// </summary>
    /// <param name="buildingStateEnum"></param>
    /// <returns></returns>
    public static GameObject GetSelectedBuilding(int buildingStateEnum)
    {
        switch(buildingStateEnum)
        {
            case 0:
                return TownCentre;
            case 1:
                return House;
            case 2:
                return Library;
            case 3:
                return Factory;
            case 4:
                return MTower;
            case 5:
                return Road;
            case 6:
                return Blockade;
            case 7:
                return Wonder;
            default: System.Diagnostics.Debug.WriteLine("Unknown int given, only 1-7 accepted"); return null;
        }
    }
    #endregion
    #region Load Node Prefabs
    private static GameObject grassland;

    private static GameObject house;
    private static GameObject library;
    private static GameObject factory;
    private static GameObject wonder;
    private static GameObject townCentre;
    private static GameObject mTower;
    private static GameObject road;
    private static GameObject blockade;

    public static GameObject Grassland { get { return grassland; } set { grassland = value; } }

    public static GameObject House { get { return house; } set { house = value; } }
    public static GameObject Library { get { return library; } set { library = value; } }
    public static GameObject Factory { get { return factory; } set { factory = value; } }
    public static GameObject Wonder { get { return wonder; } set { wonder = value; } }
    public static GameObject TownCentre { get { return townCentre; } set { townCentre = value; } }
    public static GameObject MTower { get { return mTower; } set { mTower = value; } }
    public static GameObject Road { get { return road; } set { road = value; } }
    public static GameObject Blockade { get { return blockade; } set { blockade = value; } }

    private static void LoadNodePrefabs()
    {
        House = (GameObject)Resources.Load(@"Buildings/House", typeof(GameObject));
        Library = (GameObject)Resources.Load(@"Buildings/Library", typeof(GameObject));
        Factory = (GameObject)Resources.Load(@"Buildings/Factory", typeof(GameObject));
        Wonder = (GameObject)Resources.Load(@"Buildings/Wonder", typeof(GameObject));
        TownCentre = (GameObject)Resources.Load(@"Buildings/TownCentre", typeof(GameObject));
        Grassland = (GameObject)Resources.Load(@"Buildings/Grassland", typeof(GameObject));
        MTower = (GameObject)Resources.Load(@"Buildings/MTower", typeof(GameObject));
        Road = (GameObject)Resources.Load(@"Buildings/Road", typeof(GameObject));
        Blockade = (GameObject)Resources.Load(@"Buildings/Blockade", typeof(GameObject));
    }
    #endregion

    #region Alt Bounds Helper
    private static List<int> TopLeft(int[] nodePos1, int[] nodePos2)
    {
        List<int> nodeList = new List<int>();
        for (int y = nodePos1[1]; y <= nodePos2[1]; y++)
        {
            for (int x = nodePos1[0]; x <= nodePos2[0]; x++)
            {
                int id = CalculateNodeId(x, y);
                nodeList.Add(id);
            }
        }
        return nodeList;
    }
    private static List<int> BottomLeft(int[] nodePos1, int[] nodePos2)
    {
        List<int> nodeList = new List<int>();
        for (int y = nodePos1[1]; y >= nodePos2[1]; y++)
        {
            for (int x = nodePos1[0]; x <= nodePos2[0]; x++)
            {
                int id = CalculateNodeId(x, y);
                nodeList.Add(id);
            }
        }
        return nodeList;
    }
    private static List<int> Left(int[] nodePos1, int[] nodePos2)
    {
        List<int> nodeList = new List<int>();
        for (int y = nodePos1[1]; y == nodePos2[1]; y++)
        {
            for (int x = nodePos1[0]; x <= nodePos2[0]; x++)
            {
                int id = CalculateNodeId(x, y);
                nodeList.Add(id);
            }
        }
        return nodeList;
    }
    private static List<int> TopRight(int[] nodePos1, int[] nodePos2)
    {
        List<int> nodeList = new List<int>();
        for (int y = nodePos1[1]; y <= nodePos2[1]; y++)
        {
            for (int x = nodePos1[0]; x >= nodePos2[0]; x++)
            {
                int id = CalculateNodeId(x, y);
                nodeList.Add(id);
            }
        }
        return nodeList;
    }
    private static List<int> BottomRight(int[] nodePos1, int[] nodePos2)
    {
        List<int> nodeList = new List<int>();
        for (int y = nodePos1[1]; y >= nodePos2[1]; y++)
        {
            for (int x = nodePos1[0]; x >= nodePos2[0]; x++)
            {
                int id = CalculateNodeId(x, y);
                nodeList.Add(id);
            }
        }
        return nodeList;
    }
    private static List<int> Right(int[] nodePos1, int[] nodePos2)
    {
        List<int> nodeList = new List<int>();
        for (int y = nodePos1[1]; y == nodePos2[1]; y++)
        {
            for (int x = nodePos1[0]; x >= nodePos2[0]; x++)
            {
                int id = CalculateNodeId(x, y);
                nodeList.Add(id);
            }
        }
        return nodeList;
    }
    private static List<int> Top(int[] nodePos1, int[] nodePos2)
    {
        List<int> nodeList = new List<int>();
        for (int y = nodePos1[1]; y <= nodePos2[1]; y++)
        {
            for (int x = nodePos1[0]; x == nodePos2[0]; x++)
            {
                int id = CalculateNodeId(x, y);
                nodeList.Add(id);
            }
        }
        return nodeList;
    }
    private static List<int> Bottom(int[] nodePos1, int[] nodePos2)
    {
        List<int> nodeList = new List<int>();
        for (int y = nodePos1[1]; y >= nodePos2[1]; y++)
        {
            for (int x = nodePos1[0]; x == nodePos2[0]; x++)
            {
                int id = CalculateNodeId(x, y);
                nodeList.Add(id);
            }
        }
        return nodeList;
    }
    private static List<int> Middle(int[] nodePos1, int[] nodePos2)
    {
        List<int> nodeList = new List<int>();
        for (int y = nodePos1[1]; y == nodePos2[1]; y++)
        {
            for (int x = nodePos1[0]; x == nodePos2[0]; x++)
            {
                int id = CalculateNodeId(x, y);
                nodeList.Add(id);
            }
        }
        return nodeList;
    }

    #endregion

}
