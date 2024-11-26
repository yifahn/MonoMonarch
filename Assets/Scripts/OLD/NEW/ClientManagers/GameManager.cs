using UnityEngine;

//using SharedLibrary.MM_DbSchema;ss
using Assets.Scripts.NEW.ClientServices;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Assets.Scripts.NEW.ClientManagers.User;
using Assets.Scripts.NEW.ClientManagers.Armoury;
using Assets.Scripts.NEW.ClientManagers.Battleboard;
using Assets.Scripts.NEW.ClientManagers.Character;
using Assets.Scripts.NEW.ClientManagers.Kingdom;
using Assets.Scripts.NEW.ClientManagers.Soupkitchen;
using Assets.Scripts.NEW.ClientManagers.Treasury;
//using PSQLLibrary.Game.MM_Framework.Kingdom.Map;

namespace Assets.Scripts.NEW.ClientManagers
{
    [Serializable]
    public class GameManager : MonoBehaviour
    {
        //private static GameManager _instance;

        //[SerializeField] public static IGameService _gameService { get; set; }
        //[SerializeField] public static HttpClient _httpClient { get; set; }

        //public static GameManager Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = FindFirstObjectByType<GameManager>();

        //            if (_instance == null)
        //            {
        //                GameObject singletonObject = new GameObject(typeof(GameManager).Name);
        //                _instance = singletonObject.AddComponent<GameManager>();
        //                _httpClient = new HttpClient();
        //                _gameService = new GameService();
                        
        //            }

        //            DontDestroyOnLoad(_instance.gameObject);
        //        }

        //        return _instance;
        //    }
        //}
        ////chatgpt~~~
        //private void Awake()
        //{
        //    if (_instance != null && _instance != this)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //    else
        //    {
        //        _instance = this;
        //        DontDestroyOnLoad(this.gameObject);
        //    }
        //}
        //public void NavToScene(string sceneName)
        //{
        //    SceneManager.LoadScene(_gameService.ResolveScene(sceneName));
        //}

        //public void ClearGameCache()
        //{
        //    //ArmouryManager.Instance.ClearArmouryCache();
        //    //BattleboardManager.Instance.ClearBattleboardCache();
        //    //CharacterManager.Instance.ClearCharacterChache();
        //    //KingdomManager.Instance.ClearKingdomCache();
        //    //SoupkitchenManager.Instance.ClearSoupkitchenCache();
        //    //TreasuryManager.Instance.ClearTreasuryCache();
        //    UserManager.Instance.ClearUserCache();
        //}
    }
}

