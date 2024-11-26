using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class MenuTransition : MonoBehaviour
{
    public GameObject btnLoad, btnNew, btnOK, fileSelect, panelLoad;
    public GameObject playerCreate, btnOK2, dropDown2, playerName;
    public bool isLoadBtnSelected,isNewGameSelected;

    public void Start()
    {
        btnNew = GameObject.Find("BtnNewGame"); //declare and set 
        btnLoad = GameObject.Find("BtnLoadGame");
        panelLoad = GameObject.Find("PanelLoad");
        fileSelect = GameObject.Find("Dropdown");
        btnOK = GameObject.Find("BtnOK");

        playerCreate = GameObject.Find("PanelPlayerCreate");
        btnOK2 = GameObject.Find("BtnOK2");
        dropDown2 = GameObject.Find("Dropdown2");
        playerName = GameObject.Find("UsernameTMP");

        isNewGameSelected = false;
        playerCreate.SetActive(false);

        isLoadBtnSelected = false;
        panelLoad.SetActive(false);
       
    }
    public void ShowNewPlayerElement()
    {
        if (isNewGameSelected)
        {
            Debug.Log("isNewGameSelected == true");
            if (!playerCreate.activeSelf)
            {
                Debug.Log("activating playerCreate panel");
                playerCreate.SetActive(true);
                dropDown2.GetComponent<TMP_Dropdown>().ClearOptions();
                List<string> classList = new List<string>
                {
                    "Assassin",
                    "Tank",
                    "Grunt",
                    "Commander",
                    "Peacekeeper",
                    "Chaos"
                };
                dropDown2.GetComponent<TMP_Dropdown>().AddOptions(classList);
            }
        }
    }

    public void ShowLoadElement() //on load btn click 
    {
        if (isLoadBtnSelected)
        {
            if (!panelLoad.activeSelf)
            {
                panelLoad.SetActive(true);
                fileSelect.GetComponent<TMP_Dropdown>().ClearOptions();
                if (Directory.Exists(@"c:\saves\"))
                {
                    SaveAndLoad.saveFileDir = @"c:\saves\";
                    Debug.Log("dir does exist");
                }
                else
                {
                    Debug.Log("dir does NOT exist");
                    Directory.CreateDirectory(@"c:\saves\");
                    SaveAndLoad.saveFileDir = @"c:\saves\";
                }
                string[] files = Directory.GetFiles(SaveAndLoad.saveFileDir, "*.txt", 0);
                foreach (string dir in files)
                {
                    Debug.Log(dir);
                }
               
                int i = 0;
                List<string> tempList = new List<string>();
                foreach (string dir in files)
                {
                    i++;
                    tempList.Add(dir);
                    if (i == 1)
                    {
                        fileSelect.GetComponent<TMP_Dropdown>().value = 1;
                    }
                }
                fileSelect.GetComponent<TMP_Dropdown>().AddOptions(tempList);
            }
        }
    }
    public void SetFileRef()
    {
        SaveAndLoad.AssignSaveFileDirAndFileNameOnLoad(fileSelect.GetComponent<TMP_Dropdown>().captionText.@text.TrimEnd('\r', '\n'));
        Debug.Log(SaveAndLoad.SaveFileSelected);
        
    }
    public bool IsLoadDropdownPopulated()
    {
        bool tempbool = true;
        if (fileSelect.GetComponent<TMP_Dropdown>().captionText.@text == string.Empty || fileSelect.GetComponent<TMP_Dropdown>().captionText.@text == "")
        {
            tempbool = true;
        }
        else
        {
            tempbool = false;
        }

        return tempbool;
    }
}
