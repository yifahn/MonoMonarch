using Assets.Scripts.NEW.ClientManagers;
using Assets.Scripts.NEW.ClientManagers.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.NEW.Interactables
{
    public class AuthenticationInteractable : MonoBehaviour//, IInteractable
    {
        //public async void Interact()
        //{
        //    Debug.Log($"INTERACT - {gameObject.name}");

        //    switch (gameObject.name)
        //    {
        //        case "BTN_REGISTER_SUBMIT_R":
        //            //register logic
        //            UserManager.Instance.Email = GameObject.Find("INPUT_EMAIL_R").GetComponentInChildren<TMP_InputField>().text;
        //            UserManager.Instance.Password = GameObject.Find("INPUT_PASSWORD_R").GetComponentInChildren<TMP_InputField>().text;
        //            UserManager.Instance.PasswordConfirm = GameObject.Find("INPUT_PASSWORD_CONFIRM_R").GetComponentInChildren<TMP_InputField>().text;

        //            if (!UserManager.Instance.Password.Equals(UserManager.Instance.PasswordConfirm))
        //            {
        //                Debug.Log(UserManager.Instance.Password + " " + UserManager.Instance.PasswordConfirm + "_password Failure: Mismatch");
        //            }
        //            else
        //            {
        //                await UserManager.Instance.RegisterUser() ; // this also logs user in on firebase - user will have updated refresh and idtoken - next step is to change scene to map and create remainder of player data as new game
        //            }
        //            return;

        //        case "BTN_LOGIN_SUBMIT_L":
        //            //login logic
        //            UserManager.Instance.Email = GameObject.Find("INPUT_EMAIL_L").GetComponentInChildren<TMP_InputField>().text;
        //            UserManager.Instance.Password = GameObject.Find("INPUT_PASSWORD_L").GetComponentInChildren<TMP_InputField>().text;

        //            UserManager.Instance.LoginUser();
        //            return;
        //            /*
        //            string email = GameObject.Find("INPUT_EMAIL_R").GetComponentInChildren<TMP_InputField>().text;
        //            string password = GameObject.Find("INPUT_PASSWORD_R").GetComponentInChildren<TMP_InputField>().text;
        //            string passwordConfirm = GameObject.Find("INPUT_PASSWORD_CONFIRM_R").GetComponentInChildren<TMP_InputField>().text;

        //            if (password.Equals(passwordConfirm)) await UserManager.Instance.RegisterUser(email, password);
        //            else
        //            {
        //                Debug.Log(password + " " + passwordConfirm);
        //                Debug.Log("Registration failed - _password mismatch");
        //            }
        //            return;*/
        //    }
        //    //UI ADJUSTMENT
        //    UserManager.Instance.NavRegisterLoginElements(gameObject);
        //}
    }
}
