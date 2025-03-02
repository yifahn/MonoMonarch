using System;
using System.Threading.Tasks;

using UnityEngine;
using Unity.VisualScripting;

using Newtonsoft.Json;

using MonoMonarchNetworkFramework;
using MonoMonarchNetworkFramework.Authentication.Register;
using MonoMonarchNetworkFramework.Authentication.Login;
using MonoMonarchNetworkFramework.Authentication.Logout;
using MonoMonarchNetworkFramework.Authentication.RefreshToken;

using Assets.Scripts.ClientManagers.Game;
using System.Text.RegularExpressions;
using UnityEditor.PackageManager;
using MonoMonarchNetworkFramework.Game.Treasury;
using Assets.Scripts.ClientManagers.User;
using MonoMonarchGameFramework.Game.Treasury.GoldBag;
using MonoMonarchGameFramework.Game.Treasury;
using static System.Collections.Specialized.BitVector32;
using System.IO;
using System.Numerics;
using System.Collections.Generic;
using MonoMonarchGameFramework.Game.Kingdom.Nodes;

namespace Assets.Scripts.ClientManagers.Treasury
{
    public class TreasuryManager : MonoBehaviour
    {
        #region Treasury Singleton
        private static ITreasuryService _treasuryService { get; set; }
        private static TreasuryManager _instance;
        public static TreasuryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<TreasuryManager>();
                    if (_instance == null)
                    {
                        GameObject singletonInstance = new GameObject(typeof(TreasuryManager).Name);
                        _instance = singletonInstance.AddComponent<TreasuryManager>();
                        _treasuryService = new TreasuryService();
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


        #region Treasury Properties
        public TreasuryLoadResponse TreasuryLoadResponse { get; set; }
        public ErrorResponse TreasuryErrorResponse { get; set; }

        public TreasuryState TreasuryState { get => _treasuryState; set => _treasuryState = value; }
        private TreasuryState DeserialiseTreasuryState(string serialisedTreasuryState)
        {
            using (StringReader sr = new StringReader(serialisedTreasuryState))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                    return new JsonSerializer().Deserialize<TreasuryState>(reader);
            }
        }
        [SerializeField] private TreasuryState _treasuryState;
        #endregion


        public async Task<bool> TreasuryLoadAsync()
        {
            try
            {
                var response = await _treasuryService.TreasuryLoadAsync();
                if (response is TreasuryLoadResponse treasuryLoadResponse)
                {
                    TreasuryLoadResponse = treasuryLoadResponse;

                    TreasuryState = DeserialiseTreasuryState(TreasuryLoadResponse.TreasuryState);

                    // TreasuryCoinBag = TreasuryLoadResponse.TreasuryState;
                    //TreasuryTotalCoin = TreasuryLoadResponse.TotalCoin;
                }
                else if (response is ErrorResponse errorResponse)
                {
                    TreasuryErrorResponse = errorResponse;
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

        public void ClearTreasuryCache()
        {
            TreasuryLoadResponse = null;
            TreasuryState = null;
        }


        #region Treasury Zoning
        [SerializeField] private BigInteger zoningCost;
        public BigInteger ZoningCost { get { return zoningCost; } set { zoningCost = value; } }
        public void AddZoningCost(List<BaseNode> nodeList)
        {
            foreach (BaseNode node in nodeList)
                ZoningCost += node.NodeCost;
        }
        public void SubtractZoningCost(List<BaseNode> nodeList)
        {
            foreach (BaseNode node in nodeList)
                ZoningCost -= node.NodeCost;
        }
        public void ZoningTextColourRed(MeshRenderer mr)
        {

        }
        #endregion


        #region Treasury Tools
        public bool IsSufficientCoin(List<BaseNode> nodeList)
        {
            BigInteger total = 0;
            foreach (BaseNode node in nodeList)
                total += node.NodeCost;

            return true ? total < TreasuryState.GetTotalCoin() : false;
        }
        #endregion


    }
}
