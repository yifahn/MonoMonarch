using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;


/// <summary>
/// Used by game client to send get and update requests to the server
/// </summary>
public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;
    public static string serverURL = "http://localhost:8080";
    public static string serverURLGet = serverURL + "/get";
    public static string serverURLUpdate = serverURL + "/update";
    public static string serverURLCreate = serverURL + "/create";
    public static string serverURLDelete = serverURL + "/delete";
    public static string serverURLLogin = serverURL + "/login";
    public static string serverURLRegister = serverURL + "/register";
    public static string serverURLLogout = serverURL + "/logout";
    public static string serverURLGetAll = serverURL + "/getall";
    public static string serverURLGetAllUsers = serverURL + "/getallusers";
    public static string serverURLGetAllCharacters = serverURL + "/getallcharacters";
    public static string serverURLGetAllItems = serverURL + "/getallitems";
    public static string serverURLGetAllSkills = serverURL + "/getallskills";
    public static string serverURLGetAllEnemies = serverURL + "/getallenemies";
    public static string serverURLGetAllQuests = serverURL + "/getallquests";
    public static string serverURLGetAllQuestsCompleted = serverURL + "/getallquestscompleted";
    public static string serverURLGetAllQuestsActive = serverURL + "/getallquestsactive";
    public static string serverURLGetAllQuestsInactive = serverURL + "/getallquestsinactive";
    public static string serverURLGetAllQuestsFailed = serverURL + "/getallquestsfailed";
    public static string serverURLGetAllQuestsCompletedByUser = serverURL + "/getallquestscompletedbyuser";
    public static string serverURLGetAllQuestsActiveByUser = serverURL + "/getallquestsactivebyuser";
    public static string serverURLGetAllQuestsInactiveByUser = serverURL + "/getallquestsinactivebyuser";
    public static string serverURLGetAllQuestsFailedByUser = serverURL + "/getallquestsfailedbyuser";
    public static string serverURLGetAllQuestsCompletedByCharacter = serverURL + "/getallquestscompletedbycharacter";
    public static string serverURLGetAllQuestsActiveByCharacter = serverURL + "/getallquestsactivebycharacter";
    public static string serverURLGetAllQuestsInactiveByCharacter = serverURL + "/"
}
