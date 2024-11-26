using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;

//using SharedAuthLibrary.Firebase.Register;
//using SharedAuthLibrary.Firebase.SignIn;
//using SharedAuthLibrary.PSQL.SignOut;
using MonoMonarchGameFramework;
using MonoMonarchNetworkFramework.Authentication.Register;
using UnityEngine;
using Assets.Scripts.NEW.ClientServices;
//using SharedAuthLibrary.Firebase.RefreshToken;

namespace Assets.Scripts.NEW.ClientManagers.User
{
    //public class UserService : IUserService
    //{
    //    private readonly string MM_API_URL_DEV_HTTP = "http://localhost:5223";
    //    private readonly string MM_API_URL_DEV_HTTPS = "https://localhost:7061"; //certs? auto handled?
    //    private readonly string MM_API_URL_PROD = "";
    //    //    httpClient.DefaultRequestHeaders.Authorization =
    //    //new AuthenticationHeaderValue("Bearer", "Your Oauth token");
    //    //webRequest.SetRequestHeader("Bearer", "");
    //    public async Task<IRegistrationResponse> RegisterAsync(string email, string password)
    //    {
    //        Debug.LogError("reachedregisterservice");
    //        string url = $"{MM_API_URL_DEV_HTTP}/authentication/register";  //http://localhost:5223/authentication/register

    //        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");

    //        webRequest.SetRequestHeader("Content-Type", "application/json");

    //        RegistrationPayload payload = new RegistrationPayload()
    //        {
    //            Email = email,
    //            Password = password,
                
    //        };

    //        string jsonData = JsonConvert.SerializeObject(payload); //(,jsonObjSettings)
    //        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);
    //        webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
    //        webRequest.downloadHandler = new DownloadHandlerBuffer();

    //        await webRequest.SendWebRequest();

    //        if (webRequest.result == UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log("Web request result: " + webRequest.downloadHandler.text);
    //            Debug.Log("Completed Phase 3");
    //            return JsonConvert.DeserializeObject<RegistrationResponse>(webRequest.downloadHandler.text); ;
               
    //        }
    //        else
    //        {
                
    //            Debug.LogError("Web request error: " + webRequest.error);
    //            throw new Exception(webRequest.error);
    //        }

    //    }
    //    public async Task<SignInResponse> LoginAsync(string email, string password)
    //    {
    //        string url = $"{MM_API_URL_DEV_HTTP}/Authentication/login";

    //        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");

    //        webRequest.SetRequestHeader("Content-Type", "application/json");

    //        SignInPayload payload = new SignInPayload()
    //        {
    //            Email = email,
    //            Password = password,
    //            ReturnSecureToken = true
    //        };

    //        string jsonData = JsonConvert.SerializeObject(payload); //(,jsonObjSettings)
    //        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);
    //        webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
    //        webRequest.downloadHandler = new DownloadHandlerBuffer();

    //        await webRequest.SendWebRequest();

    //        if (webRequest.result == UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log("Web request result: " + webRequest.downloadHandler.text);
    //            Debug.Log("Completed Phase 3");
    //            return JsonConvert.DeserializeObject<SignInResponse>(webRequest.downloadHandler.text); ;

    //        }
    //        else
    //        {
    //            Debug.LogError("Web request error: " + webRequest.error);
    //            throw new Exception(webRequest.error);
    //        }

    //    }
    //    public async Task<bool> LogoutAsync(string authToken, string refreshToken, string localId)
    //    {
    //        Debug.Log("Clearing user cache");
    //        string url = $"{MM_API_URL_DEV_HTTP}/Authentication/logout";

    //        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");

    //        webRequest.SetRequestHeader("Content-Type", "application/json");

    //        SignOutPayload payload = new SignOutPayload()
    //        {
    //            AuthToken = authToken,
    //            RefreshToken = refreshToken,
    //            LocalId = localId
    //        };

    //        string jsonData = JsonConvert.SerializeObject(payload); //(,jsonObjSettings)
    //        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);
    //        webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
    //        webRequest.downloadHandler = new DownloadHandlerBuffer();

    //        await webRequest.SendWebRequest();

    //        if (webRequest.result == UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log("Web request result: " + webRequest.downloadHandler.text);
    //            Debug.Log("Completed Phase 3");
    //            return true;

    //        }
    //        else
    //        {
    //            Debug.LogError("Web request error: " + webRequest.error);
    //            throw new Exception(webRequest.error);
    //        }
    //    }
    //    public async Task<RefreshTokenResponse> RefreshToken(string refreshToken)
    //    {
    //        string url = $"{MM_API_URL_DEV_HTTP}/Authentication/refresh";

    //        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");

    //        webRequest.SetRequestHeader("Content-Type", "application/json");

    //        RefreshTokenPayload payload = new RefreshTokenPayload()
    //        {
    //            GrantType = "refresh_token",
    //            RefreshToken = refreshToken,
    //        };

    //        string jsonData = JsonConvert.SerializeObject(payload); //(,jsonObjSettings)
    //        byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);
    //        webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
    //        webRequest.downloadHandler = new DownloadHandlerBuffer();

    //        await webRequest.SendWebRequest();

    //        if (webRequest.result == UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log("Web request result: " + webRequest.downloadHandler.text);
    //            return JsonConvert.DeserializeObject<RefreshTokenResponse>(webRequest.downloadHandler.text);

    //        }
    //        else
    //        {
    //            Debug.LogError("Web request error: " + webRequest.error);
    //            throw new Exception(webRequest.error);
    //        }
    //    }

    //}


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





