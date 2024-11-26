using MonoMonarchNetworkFramework.Game.Kingdom;
using MonoMonarchNetworkFramework;
using System;
using UnityEngine;
using Assets.Scripts.ClientManagers.Game;
using MonoMonarchNetworkFramework.Game.Character;
using System.Threading.Tasks;


namespace Assets.Scripts.ClientManagers.Character
{
    public class CharacterManager : MonoBehaviour
    {

        #region Character Singleton
        private static ICharacterService _characterService { get; set; }
        private static CharacterManager _instance;
        public static CharacterManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<CharacterManager>();
                    if (_instance == null)
                    {
                        GameObject singletonInstance = new GameObject(typeof(CharacterManager).Name);
                        _instance = singletonInstance.AddComponent<CharacterManager>();
                        _characterService = new CharacterService();
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

        #region Character Properties
        public CharacterLoadResponse CharacterLoadResponse { get; set; }
        public ErrorResponse CharacterErrorResponse { get; set; }

        // [SerializeField] private string _soupkitchenC_;
        //public string SoupkitchenC_ { get => _soupkitchenC_; set => _soupkitchenC_ = value; }

        #endregion

        public async Task<bool> CharacterLoadAsync()
        {
            try
            {
                var response = await _characterService.CharacterLoadAsync();
                if (response is CharacterLoadResponse characterLoadResponse)
                {
                    CharacterLoadResponse = characterLoadResponse;

                    //TreasuryCoinBag = SoupkitchenLoadResponse.CoinbagArray;
                    //TreasuryTotalCoin = SoupkitchenLoadResponse.TotalCoin;
                }
                else if (response is ErrorResponse errorResponse)
                {
                    CharacterErrorResponse = errorResponse;
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


        public void ClearCharacterCache()
        {
            CharacterLoadResponse = null;
        }
    }
}
