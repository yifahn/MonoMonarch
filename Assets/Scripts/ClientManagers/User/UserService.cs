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



namespace Assets.Scripts.ClientManagers.User
{
    public class UserService : IUserService  //Debug.LogError("reachedregisterservice");
    {

        public async Task<IRegistrationResponse> RegisterAsync(RegistrationPayload registrationPayload)
        {

            string url = $"{NetworkConstants.GetServerURLPrefix()}/authentication/register";  //http://localhost:5223/authentication/register
            UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
            webRequest.SetRequestHeader("Content-Type", "application/json");

            JsonSerializer serialiser = new JsonSerializer();
            string serialisedPayload = string.Empty;
            using (StringWriter sw = new StringWriter())
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serialiser.Serialize(writer, registrationPayload);
                    serialisedPayload = sw.ToString();
                    sw.GetStringBuilder().Clear();
                }
            }

            byte[] jsonBytes = Encoding.UTF8.GetBytes(serialisedPayload);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            await webRequest.SendWebRequest();
            IRegistrationResponse response = null;
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                if (webRequest.responseCode == 200)
                {
                    Debug.Log("Web request result: " + webRequest.downloadHandler.text);

                    using (StringReader sr = new StringReader(webRequest.downloadHandler.text))
                    {
                        using (JsonReader reader = new JsonTextReader(sr)) response = serialiser.Deserialize<RegistrationResponse>(reader);
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
            else //Unknown error code 
            {
                Debug.LogError("Unexpected response code: " + webRequest.responseCode);
                response = new ErrorResponse($"Unexpected response: {webRequest.responseCode}");
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginPayload"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ILoginResponse> LoginAsync(LoginPayload loginPayload)
        {
            string url = $"{NetworkConstants.GetServerURLPrefix()}/authentication/login";  //http://localhost:5223/authentication/login
            UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
            webRequest.SetRequestHeader("Content-Type", "application/json");

            JsonSerializer serialiser = new JsonSerializer();
            string serialisedPayload = string.Empty;
            using (StringWriter sw = new StringWriter())
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serialiser.Serialize(writer, loginPayload);
                    serialisedPayload = sw.ToString();
                    sw.GetStringBuilder().Clear();
                }
            }

            byte[] jsonBytes = Encoding.UTF8.GetBytes(serialisedPayload);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            await webRequest.SendWebRequest();
            ILoginResponse response = null;
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                if (webRequest.responseCode == 200)
                {
                    Debug.Log("Web request result: " + webRequest.downloadHandler.text);
                    using (StringReader sr = new StringReader(webRequest.downloadHandler.text))
                    {
                        using (JsonReader reader = new JsonTextReader(sr)) response = serialiser.Deserialize<LoginResponse>(reader);
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
            else //Unknown error code 
            {
                Debug.LogError("Unexpected response code: " + webRequest.responseCode);
                response = new ErrorResponse($"Unexpected response: {webRequest.responseCode}");
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logoutPayload"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ILogoutResponse> LogoutAsync(LogoutPayload logoutPayload)
        {
            Debug.Log("Clearing user cache");
            string url = $"{NetworkConstants.GetServerURLPrefix()}/authentication/logout";

            UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Authorization", $"Bearer {logoutPayload.AuthToken}");

            JsonSerializer serialiser = new JsonSerializer();
            string serialisedPayload = string.Empty;
            using (StringWriter sw = new StringWriter())
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serialiser.Serialize(writer, logoutPayload);
                    serialisedPayload = sw.ToString();
                    sw.GetStringBuilder().Clear();
                }
            }

            byte[] jsonBytes = Encoding.UTF8.GetBytes(serialisedPayload);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            await webRequest.SendWebRequest(); //401 UNAUTHORIZED?????????????????????????????????????????????
            ILogoutResponse response = null;
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                if (webRequest.responseCode == 200)
                {
                    Debug.Log("Web request result: " + webRequest.downloadHandler.text);
                    using (StringReader sr = new StringReader(webRequest.downloadHandler.text))
                    {
                        using (JsonReader reader = new JsonTextReader(sr)) response = serialiser.Deserialize<LogoutResponse>(reader);
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
                await UserManager.Instance.LogoutAsync();
            }
            else //Unknown error code 
            {
                Debug.LogError("Unexpected response code: " + webRequest.responseCode);
                response = new ErrorResponse($"Unexpected response: {webRequest.responseCode}");
            }
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshTokenPayload"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IRefreshTokenResponse> RefreshTokenAsync(RefreshTokenPayload refreshTokenPayload)
        {
            string url = $"{NetworkConstants.GetServerURLPrefix()}/authentication/refresh";

            UnityWebRequest webRequest = new UnityWebRequest(url, "POST");

            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Authorization", $"Bearer {refreshTokenPayload.AuthToken}");

            JsonSerializer serialiser = new JsonSerializer();
            string serialisedPayload = string.Empty;
            using (StringWriter sw = new StringWriter())
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serialiser.Serialize(writer, refreshTokenPayload);
                    serialisedPayload = sw.ToString();
                    sw.GetStringBuilder().Clear();
                }
            }
            byte[] jsonBytes = Encoding.UTF8.GetBytes(serialisedPayload);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            await webRequest.SendWebRequest();
            IRefreshTokenResponse response = null;
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                if (webRequest.responseCode == 200)
                {
                    Debug.Log("Web request result: " + webRequest.downloadHandler.text);
                    using (StringReader sr = new StringReader(webRequest.downloadHandler.text))
                    {
                        using (JsonReader reader = new JsonTextReader(sr)) response = serialiser.Deserialize<RefreshTokenResponse>(reader);
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
            {
                UserManager.RefreshTokenAttempts++;
                response = new ErrorResponse("Expired refresh token.");
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


////
//try
//{
//    string fb_uri = $"{FB_URL}{FB_URL_AUTH}:signUp{FB_URL_APIKEY}";
//    var payload = new
//    {
//        email = credModel.UserEmail,
//        password = credModel.UserPassword,
//        returnSecureToken = true
//    };
//    string jsonPayload = JsonConvert.SerializeObject(payload);
//    using (var client = new HttpClient())
//    {

//        var response = await client.PostAsync(fb_uri, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));

//        if (response.IsSuccessStatusCode)
//        {
//            string responseBody = await response.Content.ReadAsStringAsync();
//            var userRecord = JsonConvert.DeserializeObject<TDO.FirebaseDataStructs.FirebaseRegStruct>(responseBody);
//            var handler = new JwtSecurityTokenHandler();
//            var jsonToken = handler.ReadToken(userRecord.AuthToken) as JwtSecurityToken;
//            if (jsonToken == null)
//            {
//                throw new InvalidOperationException("Invalid JWT token");
//            }
//            //var localId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "user_id")?.Value;
//            t_User user = new t_User
//            {
//                user_name = credModel.UserEmail.Substring(0, credModel.UserEmail.IndexOf('@')),
//                user_fb_uuid = userRecord.LocalId
//            };

//            t_Session session = new t_Session()
//            {
//                user = user,
//                session_authtoken = userRecord.AuthToken,
//                session_refreshtoken = userRecord.RefreshToken,
//                session_loggedin = DateTimeOffset.UtcNow.UtcDateTime,
//                session_sessiontoken = "0"
//                //session_loggedout = DateTimeOffset.UtcNow.UtcDateTime
//            };

//            await _dbContext.AddAsync(user);
//            await _dbContext.AddAsync(session);
//            await _dbContext.SaveChangesAsync();

//            //should instead return idtoken / authtoken to unity client so client can send idtoken alonside logout request
//            return userRecord.AuthToken;
//        }
//        else
//        {
//            string errorResponse = await response.Content.ReadAsStringAsync();
//            throw new Exception($"Registration failed: {errorResponse}");
//        }
//    }
//}
//catch (Exception ex)
//{
//    System.Diagnostics.Debug.WriteLine($"Registration failed: {ex.Message}");
//    throw;
//}
//namespace Assets.Scripts.NEW.ClientManagers.User.Firebase
//{
//    /*          -REGISTRATION & SIGNIN

//                  -Response Payload

//             idToken             string 
//             email               string
//             refreshToken        string 
//             expiresIn           string 
//             localId             string 
//    */
//    public class RegistrationResponse
//    {
//        [JsonProperty("idToken")] public string AuthToken { get; set; }

//        [JsonProperty("email")] public string _email { get; set; }

//        [JsonProperty("refreshToken")] public string RefreshToken { get; set; }

//        [JsonProperty("expiresIn")] public int ExpiresIn { get; set; }

//        [JsonProperty("localId")] public string LocalId { get; set; }
//    }
//    public class RegistrationPayload
//    {
//        /*     REGISTRATION & SIGNIN

//                 -Request Body Payload

//              email               string
//              password            string
//              returnSecureToken   boolean
//        */

//        [JsonProperty("email")] public string _email { get; set; }

//        [JsonProperty("password")] public string _password { get; set; }

//        [JsonProperty("returnSecureToken")] public bool ReturnSecureToken { get; set; }
//    }
//    //Endpoint - https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=[API_KEY]
//    /*
//                     -SIGN IN

//                -Response Payload

//            idToken	            string	                
//            email	            string	                
//            refreshToken	    string            
//            expiresIn	        string	            
//            localId	            string
//            registered	        boolean
//    */
//    public class SignInResponse
//    {
//        [JsonProperty("idToken")] public string AuthToken { get; set; }

//        [JsonProperty("email")] public string _email { get; set; }

//        [JsonProperty("refreshToken")] public string RefreshToken { get; set; }

//        [JsonProperty("expiresIn")] public int ExpiresIn { get; set; }

//        [JsonProperty("localId")] public string LocalId { get; set; }

//        [JsonProperty("registered")] public bool Registered { get; set; }
//    } 
//    /*                    
//                  -SIGN IN

//               -Request Body Payload

//            email	            string	                
//            password	        string	            
//            returnSecureToken	boolean  
//    */
//    public class SignInPayload
//    {
//        [JsonProperty("email")] public string _email { get; set; }

//        [JsonProperty("password")] public string _password { get; set; }

//        [JsonProperty("returnSecureToken")] public bool ReturnSecureToken { get; set; }
//    }

//}

//namespace Assets.Scripts.NEW.ClientManagers.User.MM_API
//{
//    /// <summary>
//    /// review this, may not be required
//    /// </summary>
//    public class UserCredentials
//    {
//        public string _email { get; set; }
//        public string _password { get; set; }
//    }
//    public class UserAuthentication
//    {
//        public string AuthToken { get; set; }
//        //public string SessionToken { get; set; }// == "0" - requires modding PSQL to remove sessiontoken, not required to save
//        public string RefreshToken { get; set; }

//        //add cancellationtoken? requires PSQL DB update

//        //public DateTimeOffset LoggedIn { get; set; }
//        //public DateTimeOffset LoggedOut { get; set; }
//    }
//}





