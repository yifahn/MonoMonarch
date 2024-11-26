using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Helpers
{
    public enum SceneState
    {
        MainMenu,       //0
        Map,            //1
        Character,      //2
        Armoury,        //3
        Bazaar,         //4
        SoupKitchen,    //5
        Battleboard     //6
    }
    public static class SceneHelper
    {
        static SceneHelper()
        {
            SceneState = SceneState.MainMenu;
        }
        private static SceneState sceneState;
        public static SceneState SceneState { get { return sceneState; } set { sceneState = value; } }
        /// <summary>
        /// Prepares Scene Transition
        /// </summary>
        /// <returns>Returns an integer representation of the interacted scene navigator of type Button </returns>
        public static int SceneStateUpdate(string ui_Object)
        {
            switch (ui_Object)
            {
                case "btn_Main_Scene":
                    SceneState = SceneState.MainMenu;
                    return 0;
                case "btn_Map_Scene":
                    SceneState = SceneState.Map;
                    return 1;
                case "btn_Character_Scene":
                    SceneState = SceneState.Character;
                    return 2;
                case "btn_Armoury_Scene":
                    SceneState = SceneState.Armoury;
                    return 3;
                case "btn_Bazaar_Scene":
                    SceneState = SceneState.Bazaar;
                    return 4;
                case "btn_Soup_Scene":
                    SceneState = SceneState.SoupKitchen;
                    return 5;
                case "btn_Battle_Scene":
                    SceneState = SceneState.Battleboard;
                    return 6;
            }
            return 7; // 7 == NULL

        }

    }
}
