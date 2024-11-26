using UnityEngine;

using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;

using Assets.Scripts.ClientManagers.User;
using Assets.Scripts.ClientManagers.Treasury;
using Assets.Scripts.ClientManagers.Soupkitchen;
using Assets.Scripts.ClientManagers.Battleboard;
using Assets.Scripts.ClientManagers.Character;
using Assets.Scripts.ClientManagers.Kingdom;
using Assets.Scripts.ClientManagers.Armoury;

namespace Assets.Scripts.ClientManagers.Game
{
    [Serializable]
    public class GameManager : MonoBehaviour
    {
        #region Game Singleton
        private static GameManager _instance;
        [SerializeField] private static IGameService _gameService { get; set; }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<GameManager>();
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                        _instance = singletonObject.AddComponent<GameManager>();
                        _gameService = new GameService();
                    }
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }
        private void Awake()
        {
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
        #endregion

        #region Game Properties

        #endregion
        public async Task<bool> LoadGameState()
        {
            if (!await TreasuryManager.Instance.TreasuryLoadAsync()) return false; 
            if (!await SoupkitchenManager.Instance.SoupkitchenLoadAsync()) return false; 
            if (!await CharacterManager.Instance.CharacterLoadAsync()) return false; 
            if (!await KingdomManager.Instance.KingdomLoadAsync()) return false; 
            if (!await ArmouryManager.Instance.ArmouryLoadAsync()) return false; 
            // Uncomment if needed:
            // if (!await BattleboardManager.Instance.BattleboardLoadAsync()) return;

            Debug.Log("Game state loaded successfully");
            return true;
        }
        public void NavToScene(string sceneName)
        {
            SceneManager.LoadScene(_gameService.ResolveScene(sceneName));
        }

        public void ClearGameCache()
        {
            //ArmouryManager.Instance.ClearArmouryCache();
            //BattleboardManager.Instance.ClearBattleboardCache();
            //CharacterManager.Instance.ClearCharacterChache();
            //KingdomManager.Instance.ClearKingdomCache();
            //SoupkitchenManager.Instance.ClearSoupkitchenCache();
            TreasuryManager.Instance.ClearTreasuryCache();
            UserManager.Instance.ClearUserCache();
        }
    }
    public static class NetworkConstants
    {
        private static readonly string MM_API_URL_DEV_HTTP = "http://localhost:5223";
        private static readonly string MM_API_URL_DEV_HTTPS = "https://localhost:7061"; // certs?
        private static readonly string MM_API_URL_PROD = "";

        public static string GetServerURLPrefix()
        {
            return MM_API_URL_DEV_HTTP;
        }
    }
}

