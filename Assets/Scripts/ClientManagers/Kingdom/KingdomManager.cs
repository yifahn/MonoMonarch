using System;
using System.IO;
using System.Threading.Tasks;

using UnityEngine;

using Newtonsoft.Json;

using Assets.Scripts.ClientManagers.Game;

using MonoMonarchNetworkFramework;
using MonoMonarchNetworkFramework.Game.Kingdom;
using MonoMonarchNetworkFramework.Game.Soupkitchen;
using MonoMonarchGameFramework.Game.Soupkitchen;
using MonoMonarchGameFramework.Game.Treasury;
using MonoMonarchGameFramework.Game.Kingdom.Map.BaseNode;
using MonoMonarchGameFramework.Game;
using MonoMonarchGameFramework.Game.Kingdom.Map;


namespace Assets.Scripts.ClientManagers.Kingdom
{
    public class KingdomManager : MonoBehaviour
    {
        #region Kingdom Singleton
        private static IKingdomService _kingdomService { get; set; }
        private static KingdomManager _instance;
        public static KingdomManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<KingdomManager>();
                    if (_instance == null)
                    {
                        GameObject singletonInstance = new GameObject(typeof(KingdomManager).Name);
                        _instance = singletonInstance.AddComponent<KingdomManager>();
                        _kingdomService = new KingdomService();
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

        #region Kingdom Properties
        public KingdomLoadResponse KingdomLoadResponse { get; set; }
        public ErrorResponse KingdomErrorResponse { get; set; }
        public MonoMonarchGameFramework.Game.Kingdom.Map
        public MonoMonarchGameFramework.Game.Kingdom.Map.Map Map { get => map; set => map = value; }
        private BaseNode[] DeserialiseMap(string serialisedMap)
        {
            JsonSerializer serialiser = new JsonSerializer();
            serialiser.Converters.Add(new DeserialisationSupport());
            using (StringReader sr = new StringReader(serialisedMap))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    return serialiser.Deserialize<BaseNode[]>(reader);
                }
            }
        }
        [SerializeField] private MonoMonarchGameFramework.Game.Kingdom.Map.Map map;
        public async Task<bool> KingdomLoadAsync()
        {
            try
            {
                var response = await _kingdomService.KingdomLoadAsync();
                if (response is KingdomLoadResponse kingdomLoadResponse)
                {
                    KingdomLoadResponse = kingdomLoadResponse;
                    Map.NodeArray = DeserialiseMap(KingdomLoadResponse.KingdomMap);
                    
                    //TreasuryCoinBag = SoupkitchenLoadResponse.CoinbagArray;
                    //TreasuryTotalCoin = SoupkitchenLoadResponse.TotalCoin;
                }
                else if (response is ErrorResponse errorResponse)
                {
                    KingdomErrorResponse = errorResponse;
                    GameManager.Instance.ClearGameCache();
                    GameManager.Instance.NavToScene("btn_MainMenu_Scene");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.Log("ERROR-RESPONSE FAILURE");
                Debug.Log(ex);
                GameManager.Instance.ClearGameCache();
                GameManager.Instance.NavToScene("btn_MainMenu_Scene");
                return false;
            }
        }


        public void ClearKingdomCache()
        {
            KingdomLoadResponse = null;
        }
    }
}
