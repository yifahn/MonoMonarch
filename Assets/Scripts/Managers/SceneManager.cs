using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Managers
{
    #pragma warning disable format
    public enum SceneStateEnum
    {
        MainMenu,       //0
        Map,            //1
        Character,      //2
        SoupKitchen,    //5
        Armoury,        //3
        Bazaar,         //4
        Battleboard     //6
    }
    public static class SceneManager
    {
        static SceneManager()
        {
            SceneState = SceneStateEnum.MainMenu;
        }
        private static SceneStateEnum sceneState;
        public static SceneStateEnum SceneState { get { return sceneState; } set { sceneState = value; } }
        /// <summary>
        /// Transitions to given scene
        /// </summary>
        /// <returns>Returns a SceneStateEnum by representation of the input as an integer </returns>
        public static SceneStateEnum SceneTransition(string s_ButtonName)
        {
                 if (s_ButtonName.Contains("MainMenu"))     { SceneState = SceneStateEnum.MainMenu;     return SceneState; }
            else if (s_ButtonName.Contains("Map"))          { SceneState = SceneStateEnum.Map;          return SceneState; }
            else if (s_ButtonName.Contains("Character"))    { SceneState = SceneStateEnum.Character;    return SceneState; }
            else if (s_ButtonName.Contains("SoupKitchen"))  { SceneState = SceneStateEnum.SoupKitchen;  return SceneState; }
            else if (s_ButtonName.Contains("Armoury"))      { SceneState = SceneStateEnum.Armoury;      return SceneState; }
            else if (s_ButtonName.Contains("Bazaar"))       { SceneState = SceneStateEnum.Bazaar;       return SceneState; }
            else if (s_ButtonName.Contains("Battleboard"))  { SceneState = SceneStateEnum.Battleboard;  return SceneState; }
            return SceneStateEnum.MainMenu;//default/required, will never reach this
        }
    }
#pragma warning restore format
}
