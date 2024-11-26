using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

namespace ScriptsByScene
{
    public class SceneManagerMainMenu : MonoBehaviour
    {

#pragma warning restore format
        //_SceneManagerMainMenu > Map
        public void LoadScene()
        {
            if (Helpers.SceneHelper.SceneState == Helpers.SceneState.Map) UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
#pragma warning restore format

    }
}
