using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Networking;

using Newtonsoft.Json;

using Assets.Scripts.ClientManagers.Game;

using MonoMonarchNetworkFramework;
using MonoMonarchNetworkFramework.Authentication.Register;
using MonoMonarchNetworkFramework.Authentication.Login;
using MonoMonarchNetworkFramework.Authentication.Logout;
using MonoMonarchNetworkFramework.Authentication.RefreshToken;

using MonoMonarchGameFramework.Game.Soupkitchen;
using MonoMonarchGameFramework.Game;
using MonoMonarchNetworkFramework.Game.Treasury;
using Assets.Scripts.ClientManagers.User;



namespace Assets.Scripts.ClientManagers.Treasury
{
    public class TreasuryService : ITreasuryService  //Debug.LogError("reachedregisterservice");
    {
        public async Task<ITreasuryLoadResponse> TreasuryLoadAsync()
        {

            string url = $"{NetworkConstants.GetServerURLPrefix()}/treasury/loadtreasury";  //http://localhost:5223/authentication/register
            UnityWebRequest webRequest = new UnityWebRequest(url, "GET");
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Authorization", $"Bearer {UserManager.Instance.UserLoginResponse.AuthToken}");
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            await webRequest.SendWebRequest();
            ITreasuryLoadResponse response = null;
            JsonSerializer serialiser = new JsonSerializer();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                if (webRequest.responseCode == 200)
                {
                    Debug.Log("Web request result: " + webRequest.downloadHandler.text);

                    using (StringReader sr = new StringReader(webRequest.downloadHandler.text))
                    {
                        using (JsonReader reader = new JsonTextReader(sr)) response = serialiser.Deserialize<TreasuryLoadResponse>(reader);
                    }
                }
                else response = new ErrorResponse("Web request is Ok but is not StatusCode 200");
            }
            else if (webRequest.responseCode == 400)
            {
                Debug.LogWarning("Web request error (400): " + webRequest.downloadHandler.text);

                using (StringReader sr = new StringReader(webRequest.downloadHandler.text))
                {
                    using (JsonReader reader = new JsonTextReader(sr)) response = serialiser.Deserialize<ErrorResponse>(reader);
                }
            }
            else if (webRequest.responseCode == 500)
            {
                Debug.LogError("Server error (500).");
                response = new ErrorResponse("Internal server error.");
            }
            else if (webRequest.responseCode == 401)
            {//potential endless loop if untested and turns out to always produce unauthorized error
                await UserManager.Instance.RefreshTokenAsync();
                await TreasuryManager.Instance.TreasuryLoadAsync();
            }
            else //Unknown error code 
            {
                Debug.LogError("Unexpected response code: " + webRequest.responseCode);
                response = new ErrorResponse($"Unexpected response: {webRequest.responseCode}");
            }
            if (response == null)
                return new ErrorResponse("Unexpected result");
            return response;
        }
    }
}