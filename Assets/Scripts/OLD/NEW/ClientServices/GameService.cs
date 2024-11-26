
using UnityEngine;
using System.Threading.Tasks;
using MonoMonarchNetworkFramework.Authentication.Register;
using MonoMonarchNetworkFramework.Authentication.Login;
using MonoMonarchNetworkFramework.Authentication.Logout;

namespace Assets.Scripts.NEW.ClientServices
{
    //SYSTEM.NET LIBRARY IS NOT SUPPORTED BY WEBGL DUE TO JAVA CONVERSION NOT SUPPORTING NETWORK SOCKETS... OR SOMETHING LIKE THAT - DONT USE SYSTEM.NET NAMESPACE!!!!!!!! - UnityWebRequest ONLY!!!!
    #region Interface Definitions
    public interface IGameService
    {
        int ResolveScene(string sceneName);
    }
    public interface IUserService
    {
        Task<IRegistrationResponse> RegisterAsync(string email, string password);
        Task<ILoginResponse> LoginAsync(string email, string password);
        Task<ILogoutResponse> LogoutAsync(string authToken, string refreshToken, string localId);

    }
    public interface IKingdomService
    {
    }
    public interface IArmouryService
    {
    }
    public interface ITreasuryService
    {
    }
    public interface ICharacterService
    {
    }
    public interface ISoupkitchenService
    {
    }
    public interface IBattleboardService
    {
    }
    #endregion

    public class GameService : IGameService
    {
        public int ResolveScene(string sceneName)
        {
            switch (sceneName)
            {
                //bottom canvas
                case "btn_MainMenu_Scene":
                    return 0;

                //left canvas
                case "btn_Map_Scene":
                    return 1;

                case "btn_Character_Scene":
                    return 2;

                case "btn_Armoury_Scene":
                    return 3;

                case "btn_Soup_Scene":
                    return 4;

                case "btn_Bazaar_Scene":
                    return 5;

                case "btn_Battle_Scene":
                    return 6;


                //login button on main menu
                case "BTN_LOGIN_SUBMIT_L":
                    return 1; //register directs to tutorial scene? - login directs to map scene?

                case "BTN_REGISTER_SUBMIT_R":
                    return 1; //register directs to tutorial scene? - login directs to map scene?

            }
            //default
            return 0;
        }
    }
}
