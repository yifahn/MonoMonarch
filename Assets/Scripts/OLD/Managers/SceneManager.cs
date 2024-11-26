using Managers;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{

    public class SceneManager : MonoBehaviour
    {
        // Static reference to the instance of the SingletonExample class
        private static SceneManager _instance;

        // Public property to access the instance
        public static SceneManager Instance
        {
            get
            {
                // If the instance is null, try to find it in the scene
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<SceneManager>();

                    // If still null, create a new GameObject with the SingletonExample script attached
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject("SceneManager");
                        _instance = obj.AddComponent<SceneManager>();
                    }
                }

                // Return the instance
                return _instance;
            }
        }

        // Optional: Your other class members and methods can go here

        private void Awake()
        {
            // Ensure there is only one instance of this class
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }

            // Set the instance to this GameObject
            _instance = this;

            // Optional: Make sure the GameObject persists between scenes
            DontDestroyOnLoad(gameObject);
        }

        // Optional: Your other MonoBehaviour methods can go here
        public void SceneSelector(int NavToScene)
        {
            if (NavToScene == 7) { Console.WriteLine("NULL Scene Transition error"); return; }
            UnityEngine.SceneManagement.SceneManager.LoadScene(NavToScene);
        }
    }
}
    /// <summary>
    /// Updates SceneState and loads specified scene
    /// </summary>
    /// <param name="NavToScene"></param>
   
    

