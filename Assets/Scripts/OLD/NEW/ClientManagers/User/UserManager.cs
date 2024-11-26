
using UnityEngine;
using Assets.Scripts.NEW.ClientServices;
using Unity.VisualScripting;
using System;
using System.Threading.Tasks;
using Assets.Scripts.NEW.ClientManagers.Armoury;
using MonoMonarchNetworkFramework.Authentication.Register;
using MonoMonarchNetworkFramework.Authentication.Login;

namespace Assets.Scripts.NEW.ClientManagers.User
{
    public class UserManager : MonoBehaviour
    {
        //    #region Authentication Properties
        //    public IRegistrationResponse RegistrationResponse {  get; set; }
        //    public ILoginResponse SignInResponse { get; set; }


        //    public string Email { get; set; }
        //    public string Password { get; set; }
        //    public string PasswordConfirm { get; set; }
        //    private static IUserService _userService { get; set; }
        //    #endregion

        //    // Singleton instance
        //    private static UserManager _instance;
        //    public static UserManager Instance
        //    {
        //        get
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = FindFirstObjectByType<UserManager>();
        //                if (_instance == null)
        //                {
        //                    GameObject singletonObject = new GameObject(typeof(UserManager).Name);
        //                    _instance = singletonObject.AddComponent<UserManager>();
        //                    _userService = new UserService();

        //                }

        //                DontDestroyOnLoad(_instance.gameObject);
        //            }

        //            return _instance;
        //        }
        //    }
        //    private void Awake()
        //    {
        //        if (_instance != null && _instance != this)
        //        {
        //            Destroy(this.gameObject);
        //        }
        //        else
        //        {
        //            _instance = this;
        //            DontDestroyOnLoad(this.gameObject);
        //        }
        //    }

        //    public async Task RegisterUser()
        //    {
        //        try
        //        {
        //            RegistrationResponse = await _userService.RegisterAsync(Email, Password);
        //        }
        //        catch (Exception ex)
        //        {
        //            //if register fails
        //            Debug.Log(ex);
        //        }


        //    }
        //   // public async Task
        //    public async Task LoginUser()//string authToken
        //    {
        //        try
        //        {
        //            SignInResponse = await _userService.LoginAsync(Email, Password);
        //        }
        //        catch (Exception ex)
        //        {
        //            //if login fails 
        //            Debug.Log(ex);
        //        }
        //    }
        //    public async Task<bool> LogoutUser()//string authToken
        //    {
        //        try
        //        {
        //            GameManager.Instance.ClearGameCache();
        //            await _userService.LogoutAsync(SignInResponse.AuthToken, SignInResponse.RefreshToken, SignInResponse.LocalId);
        //        }
        //        catch (Exception ex)
        //        {
        //            //if logout fails 
        //            Debug.Log(ex);
        //        }

        //        return false;
        //    }
        //    public void ClearUserCache()
        //    {
        //        Email = string.Empty;
        //        Password = string.Empty;
        //        PasswordConfirm = string.Empty;
        //        RegistrationResponse = null;
        //        SignInResponse = null;
        //    }


        //    public void NavRegisterLoginElements(GameObject obj)
        //    {
        //        switch (obj.name)
        //        {
        //            case "BTN_NAV_REGISTER_L":
        //                obj.transform.parent.parent.Find("PANEL_MAINMENU_REGISTER").transform.localScale = new Vector3(1, 1, 1);
        //                obj.transform.parent.parent.Find("PANEL_MAINMENU_LOGIN").transform.localScale = new Vector3(0, 0, 0);
        //                break;
        //            case "BTN_NAV_LOGIN_R":
        //                obj.transform.parent.parent.Find("PANEL_MAINMENU_LOGIN").transform.localScale = new Vector3(1, 1, 1);
        //                obj.transform.parent.parent.Find("PANEL_MAINMENU_REGISTER").transform.localScale = new Vector3(0, 0, 0);
        //                break;//s
        //        }
        //    }

        }

    
}
