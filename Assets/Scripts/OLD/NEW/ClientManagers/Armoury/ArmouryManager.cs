using UnityEngine;
using Assets.Scripts.NEW.ClientServices;

namespace Assets.Scripts.NEW.ClientManagers.Armoury
{
    /// <summary>
    /// SINGLETON MANAGER == DATA MODEL
    /// </summary>
    public class ArmouryManager : MonoBehaviour
    {

        // Singleton instance
        private static ArmouryManager _instance;

        // Public accessor for the instance

        public static new ArmouryManager Instance
        {
            get
            {
                // If the instance is null, find the existing instance in the scene
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<ArmouryManager>();

                    // If no instance is found, create a new GameObject and attach the script
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(ArmouryManager).Name);
                        _instance = singletonObject.AddComponent<ArmouryManager>();
                    }

                    // Make sure the object persists across scenes
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }

        // Your manager's methods and variables go here
        // For example:
        // public void YourMethod() { /* Your implementation here */ }

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            // Ensure there's only one instance of the manager
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        // Add other necessary methods and variables for your manager here
    }
}
