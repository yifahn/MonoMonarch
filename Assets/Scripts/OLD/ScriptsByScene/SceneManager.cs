using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

namespace ScriptsByScene
{
    public class SceneManager : MonoBehaviour
    {
        //_SceneManager > MainMenu - Map - Character - SoupKitchen - Battleboard - Bazaar 
        #pragma warning disable format
        public void LoadScene()
        {


                 if (SceneHelper.SceneState == SceneState.MainMenu)     UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            else if (SceneHelper.SceneState == SceneState.Map)          UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            else if (SceneHelper.SceneState == SceneState.Character)    UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            else if (SceneHelper.SceneState == SceneState.Armoury)      UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            else if (SceneHelper.SceneState == SceneState.SoupKitchen)  UnityEngine.SceneManagement.SceneManager.LoadScene(4);
            else if (SceneHelper.SceneState == SceneState.Bazaar)       UnityEngine.SceneManagement.SceneManager.LoadScene(5);
            else if (SceneHelper.SceneState == SceneState.Battleboard)  UnityEngine.SceneManagement.SceneManager.LoadScene(6);

        }
        #pragma warning restore format
    }
}
