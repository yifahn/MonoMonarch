using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

namespace ScriptsByScene
{

    public class SceneManagerArmoury : MonoBehaviour
    {
#pragma warning restore format
        //_SceneManagerArmoury > Character
        public void LoadScene()
        {
            if (SceneHelper.SceneState == SceneState.Character) UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
#pragma warning restore format
    }

}
