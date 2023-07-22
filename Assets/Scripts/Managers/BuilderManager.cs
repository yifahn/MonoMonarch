using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


namespace Managers 
{
    #pragma warning disable format
    #region State Enums
    public enum BuildStateEnum
    {
        Build,           //0
        Bulldoze         //1
    }
    public enum OverwriteStateEnum
    {
        True,            //0
        False            //1
    }
    public enum AltStateEnum
    {
        False,           //0
        FirstSelected,   //1
        SecondSelected,  //2
        Confirmed        //3
    }
    public enum SelectedBuildingEnum
    {
        TownCentre,      //0
        House,           //1
        Library,         //2
        Factory,         //3
        MTower,          //4
        Road,            //5
        Blockade,        //6
        Wonder,          //7
        Grassland        //8
    }
    #endregion
    #pragma warning restore format

    public static class BuilderManager
    {

        #region Constructor

        static BuilderManager() //hard code intialise for dev testing - playerprefs.ini
        {
            BuildState = BuildStateEnum.Build;
            OverwriteState = OverwriteStateEnum.False;
            AltState = AltStateEnum.False;
            //ensure overwrite checkbox defaults to false
        }

        #endregion

        #region Actions

        private static int n_Id_1_Alt;
        private static int n_Id_2_Alt;
        private static int[] nodeArray;
        public static int N_Id_1_Alt { get { return n_Id_1_Alt; } set { n_Id_1_Alt = value; } }
        public static int N_Id_2_Alt { get { return n_Id_2_Alt; } set { n_Id_2_Alt = value; } }
        public static int[] AltPopulatedNodeArray { get { return nodeArray; } set { nodeArray = value; } }

        public static void Build(bool altPressed, int n_Id)
        {
            if (altPressed)//evalute this if and switch
            {
                switch (GetAltState())//get state of alt key
                {
                    case 1://get first alt node
                        N_Id_1_Alt = n_Id;
                        return; //give player opportunity to select second node

                    case 2://get second alt node
                        N_Id_2_Alt = n_Id;
                        AltPopulatedNodeArray = MapManager.PopulateNodeArray(N_Id_1_Alt, N_Id_2_Alt);
                        MapManager.SetOpacitySelection(MapManager.AltNodeArray, 0.75f); //toggle highlight on
                        return;//give player opportunity to confirm selection

                    case 3://alt build
                        AltState = AltStateEnum.False; //reset 
                        MapManager.SetOpacitySelection(MapManager.AltNodeArray, 1f);
                        break; //continue
                }
            }
            else { AltPopulatedNodeArray = new int[1]; } //singular build
            Action();
        }

        public static void Bulldoze(bool altPressed, int n_Id)
        {
            if (altPressed)
            {
                switch (GetAltState())//get state of alt key
                {
                    case 1://get first alt node
                        N_Id_1_Alt = n_Id;
                        return; //give player opportunity to select second node

                    case 2://get second alt node
                        N_Id_2_Alt = n_Id;
                        AltPopulatedNodeArray = MapManager.PopulateNodeArray(N_Id_1_Alt, N_Id_2_Alt);
                        MapManager.SetOpacitySelection(MapManager.AltNodeArray, 0.75f); //toggle highlight on
                        return;//give player opportunity to confirm selection

                    case 3://alt build
                        AltState = AltStateEnum.False; //reset 
                        MapManager.SetOpacitySelection(MapManager.AltNodeArray, 1f);
                        break; //continue
                }
            }
            else { AltPopulatedNodeArray = new int[1]; } //singular bulldoze 
            Action();
        }
        public static void Action()
        {
            for (int i = 0; i < AltPopulatedNodeArray.Length; i++)
            {
                int n_Id = AltPopulatedNodeArray[i];
                switch (BuildState)
                {
                    case BuildStateEnum.Build:
                        if (!InvalidOverwrite(n_Id))
                        {
                            if (!InvalidBuild(n_Id)) 
                            {   
                                if (IsOverwrite()) ActionBulldoze(n_Id);
                                ActionBuild(n_Id);
                            }
                        }
                        break;
                    case BuildStateEnum.Bulldoze:
                        ActionBulldoze(n_Id);
                        break;
                }
            }
        }//TreasuryManager.UpdateCoin(0, TreasuryManager.SellBuilding(gameObject.name));
        public static void ActionBuild(int n_Id)
        {
            TreasuryManager.UpdateCoin(0,TreasuryManager.BuyBuilding(nameof(SelectedBuildingState)));
            MapManager.UpdateNodeDict(n_Id, GetSelectedBuildingState());
            MapManager.InstantiateNode(n_Id); //replace with new method that should exist on non static GameManager script attached to GameManager object
        }
        public static void ActionBulldoze(int n_Id)
        {
            TreasuryManager.UpdateCoin(1,TreasuryManager.SellBuilding(MapManager.NodeMap[n_Id].name));
            MapManager.NodeMap[n_Id].GetComponent<ClickListenerNode>().DestroyMe();
            MapManager.UpdateNodeDict(n_Id, 8);
            MapManager.InstantiateNode(n_Id); //replace with new method that should exist on non static GameManager script attached to GameManager object
        }
        /// <summary>
        /// Returns True if current action is an Overwrite action
        /// </summary>
        /// <returns></returns>
        private static bool IsOverwrite()
        {
            bool isOverwrite = false;
            if (OverwriteState == OverwriteStateEnum.True)
            {
                isOverwrite = true;
            }
            return isOverwrite;
        }
        /// <summary>
        /// Returns False if building on existing building while OverwriteStateEnum == False
        /// </summary>
        /// <param name="n_Id"></param>
        /// <returns>Boolean</returns>
        private static bool InvalidOverwrite(int n_Id)
        {
            bool invalid = false;

            if (!MapManager.NodeMap[n_Id].gameObject.name.Contains("Grassland") && OverwriteState == OverwriteStateEnum.False && BuildState == BuildStateEnum.Build)
            {
                invalid = true; 
            }
            return invalid;
        }
        /// <summary>
        /// Returns True if Node selected == SelectedBuildingState
        /// </summary>
        /// <param name="n_Id"></param>
        /// <returns>Boolean</returns>
        private static bool InvalidBuild(int n_Id)
        {
            bool invalid = false;
            if (MapManager.NodeMap[n_Id].name.Contains(nameof(SelectedBuildingState)))
            {
                invalid = true;
            }
            return invalid;
        }
        #endregion

        #region State Navigator

        private static BuildStateEnum buildState;
        private static OverwriteStateEnum overwriteState;
        private static AltStateEnum altState;
        private static SelectedBuildingEnum selectedBuildingState;
        public static SelectedBuildingEnum SelectedBuildingState { get { return selectedBuildingState; } set { selectedBuildingState = value; } }
        public static BuildStateEnum BuildState { get { return buildState; } set { buildState = value; } }
        public static OverwriteStateEnum OverwriteState { get { return overwriteState; } set { overwriteState = value; } }
        public static AltStateEnum AltState { get { return altState; } set { altState = value; } }

        /// <summary>
        /// state controller for build/bulldoze 
        /// </summary>
        /// <param name="UI_ObjName"></param>
        public static void NavigateBuildState(string UI_ObjName)
        {
            switch (UI_ObjName)
            {
                case "Build":
                    if (BuildState != BuildStateEnum.Build) BuildState = BuildStateEnum.Build;
                    break;

                case "Bulldoze":
                    if (BuildState != BuildStateEnum.Bulldoze) BuildState = BuildStateEnum.Bulldoze;
                    break;
            }
        }

        /// <summary>
        /// State Controller for alt key press detection. 
        /// 0 == no alt key pressed, 1 == first node, 2== second node, 3 == confirm and reset to false
        /// </summary>
        /// <param name="state"></param>
        public static void NavigateAltState(int state)
        {
            switch (state)
            {
                case 0: //no alt key pressed
                    AltState = AltStateEnum.False;
                    break;
                case 1: // recording first node
                    AltState = AltStateEnum.FirstSelected;
                    break;
                case 2: // recorded both nodes, set to false on confirmation
                    AltState = AltStateEnum.SecondSelected;
                    break;
                case 3: //after confirmation of second node, set to false
                    AltState = AltStateEnum.Confirmed;
                    break;
            }
        }

        /// <summary>
        /// State Controller for overwrite toggler
        /// </summary>
        /// <param name="UI_ObjState"></param>
        public static void NavigateOverwriteState() //ensure checkbox defaults to false
        {
            switch (OverwriteState)
            {
                case OverwriteStateEnum.False:
                    OverwriteState = OverwriteStateEnum.True;
                    break;
                case OverwriteStateEnum.True:
                    OverwriteState = OverwriteStateEnum.False;
                    break;
                    /*
                    * If parameters are ever eventually required for Overwrite; Overwrite.House would only overwrite houses. 
                    * Add these conditions to this method.
                    */
            }
        }
        #endregion
        #region State Helper Methods
        public static int GetAltState()
        {
            int altState = (int)AltState;
            return altState;
        }
        public static int GetBuildState()
        {
            int buildState = (int)BuildState;
            return buildState;
        }
        public static int GetOverWriteState()
        {
            int overwriteState = (int)OverwriteState;
            return overwriteState;
        }
        public static int GetSelectedBuildingState()
        {
            int selectedBuildingState = (int)SelectedBuildingState;
            return selectedBuildingState;
        }
        public static void SetSelectedBuildState(int buildState)
        {
            BuildState = (BuildStateEnum)buildState;
        }
        public static void SetSelectedAltState(int altState)
        {
            AltState = (AltStateEnum)altState;
        }
        public static void SetSelectedOverwriteState(int overwriteState)
        {
            OverwriteState = (OverwriteStateEnum)overwriteState;
        }
        public static void SetSelectedBuildingState(int buildingState)
        {
            SelectedBuildingState = (SelectedBuildingEnum)buildingState;
        }
        #endregion

    }
}

