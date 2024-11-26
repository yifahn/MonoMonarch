using UnityEngine;
using Assets.Scripts.NEW.ClientServices;
using Assets.Scripts.NEW.ClientManagers.Treasury;

namespace Assets.Scripts.NEW.ClientManagers.Soupkitchen
{
    public class SoupkitchenManager : MonoBehaviour
    {


        // Singleton instance
        private static SoupkitchenManager _instance;

        // Public accessor for the instance
        public static new SoupkitchenManager Instance
        {
            get
            {
                // If the instance is null, find the existing instance in the scene
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<SoupkitchenManager>();

                    // If no instance is found, create a new GameObject and attach the script
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(SoupkitchenManager).Name);
                        _instance = singletonObject.AddComponent<SoupkitchenManager>();
                    }

                    // Make sure the object persists across scenes
                    DontDestroyOnLoad(_instance.gameObject);
                    TreasuryService t = new TreasuryService();
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
