using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Scripts.ClientManagers.Game;
using MonoMonarchNetworkFramework.Game.Character;
using MonoMonarchNetworkFramework;
using Newtonsoft.Json;
using UnityEngine.Networking;
using MonoMonarchNetworkFramework.Game.Armoury;
using Assets.Scripts.ClientManagers.User;
using UnityEngine;

namespace Assets.Scripts.ClientManagers.Armoury
{
    /// <summary>
    /// ARMOURY SERVICE == CONTROLLER
    /// </summary>
    public class ArmouryService : IArmouryService
    {
        public async Task<IArmouryLoadResponse> ArmouryLoadAsync()
        {

            string url = $"{NetworkConstants.GetServerURLPrefix()}/armoury/loadarmoury";  //http://localhost:5223/authentication/register
            UnityWebRequest webRequest = new UnityWebRequest(url, "GET");
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Authorization", $"Bearer {UserManager.Instance.UserLoginResponse.AuthToken}");
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            await webRequest.SendWebRequest();
            IArmouryLoadResponse response = null;
            JsonSerializer serialiser = new JsonSerializer();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                if (webRequest.responseCode == 200)
                {
                    Debug.Log("Web request result: " + webRequest.downloadHandler.text);

                    using (StringReader sr = new StringReader(webRequest.downloadHandler.text))
                    {
                        using (JsonReader reader = new JsonTextReader(sr)) response = serialiser.Deserialize<ArmouryLoadResponse>(reader);
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
                await ArmouryManager.Instance.ArmouryLoadAsync();
            }
            else //Unknown error code 
            {
                Debug.LogError("Unexpected response code: " + webRequest.responseCode);
                response = new ErrorResponse($"Unexpected response: {webRequest.responseCode}");
            }
            return response;
        }
    }
}
