using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace ScriptsByScene
{
    /*start game, no new or load game
 * idea is to allow player to have many characters but one kingdom/map
 * if player hasn't played before, load new map and new character
 * coin tied to kingdom
 * politicalpoints tied to character
 * if kingdom attacked and active character dies:
 * -character remains in in crypt of rememberence (another scene to add at later date, extends character scene like ArmouryScene)
 * -character tied politicalpoints are lost
 * -kingdom coin is unaffected
 */
    public class UIManagerMainMenu : MonoBehaviour
    {
        //LOGIN FORM
        public GameObject pnl_Form_L;
        public GameObject btn_Login_L, btn_Nav_Register_L;
        public GameObject txt_User_Email_L, txt_User_Password_L;

        //REGISTER FORM
        public GameObject pnl_Form_R;
        public GameObject btn_Register_R, btn_Nav_Login_R;
        public GameObject txt_User_Email_R, txt_User_Password_R, txt_User_Password_Confirm_R;



        public void Start()
        {
            InitialiseUI();


        }
        public void InitialiseUI()
        {

            //LOGIN
            pnl_Form_L = GameObject.Find("PANEL_MAINMENU_LOGIN");
            btn_Nav_Register_L = GameObject.Find("BTN_NAV_REGISTER_L");
            btn_Login_L = GameObject.Find("BTN_LOGIN_L");
            txt_User_Email_L = GameObject.Find("INPUT_EMAIL_L");
            txt_User_Password_L = GameObject.Find("INPUT_PASSWORD_L");

            //REGISTER
            pnl_Form_R = GameObject.Find("PANEL_MAINMENU_REGISTER");
            btn_Nav_Login_R = GameObject.Find("BTN_NAV_LOGIN_R");
            btn_Register_R = GameObject.Find("BTN_REGISTER_R");
            txt_User_Email_R = GameObject.Find("INPUT_EMAIL_R");
            txt_User_Password_R = GameObject.Find("INPUT_PASSWORD_R");
            txt_User_Password_Confirm_R = GameObject.Find("INPUT_PASSWORD_CONFIRM_R");
        }


    }
}
