using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderStats : MonoBehaviour
{
    public GameObject  plane,inventoryPanelLeft,inventoryPanelRight,statisticsPanelLeft,statisticsPanelRight,gameKeeper;
    public void Start()
    {
        plane = this.gameObject;
        inventoryPanelLeft = GameObject.Find("MidLeftPanelInventory");
        inventoryPanelRight = GameObject.Find("MidRightPanelInventory");
        statisticsPanelLeft = GameObject.Find("MidLeftPanelStats");
        statisticsPanelRight = GameObject.Find("MidRightPanelStats");
        gameKeeper = GameObject.Find("GameKeeper");
    }

    public void LoadCity()
    {
        SaveAndLoad.SaveScoreOnReturnToCityScene(ScoreState.Score);//ss
        SaveAndLoad.IsReadyPlay = false;
        SaveAndLoad.IsReadyLoadFunction = false;
        SaveAndLoad.IsLoad = true;
        SceneManager.LoadScene(1);
    }
    public void ShowStatisticsElement()
    {
        statisticsPanelLeft.SetActive(true);
        statisticsPanelRight.SetActive(true);
        inventoryPanelRight.SetActive(false);
        inventoryPanelLeft.SetActive(false);
        gameKeeper.GetComponent<PlayerCharacter>().PopulateStatsElement();//s
    }
    public void ShowInventoryElement()
    {
        statisticsPanelLeft.SetActive(false);
        statisticsPanelRight.SetActive(false);
        inventoryPanelRight.SetActive(true);
        inventoryPanelLeft.SetActive(true);

    }
    /*
   // public void NewGame()
   // {
       // CellState.MapListL1Allocate();
       // CellState.MapListL1Allocate();
       //CellState.MapListL1.Clear();
       // CellState.MapListL2.Clear();
        PlayerCharacterStaticClass.NewGame();
        ScoreState.IsLoad = false;
        SaveAndLoad.IsReadyLoadFunction = true;
        SaveAndLoad.IsReadyPlay = true;
        SaveAndLoad.IsReadyDrawMap = true;
        SceneManager.LoadScene(1);
    }
    public void LoadGameViaOK()
    {
        CellState.MapListL1Allocate();
        CellState.MapListL2Allocate();
        ScoreState.IsLoad = true;
        menuKeeper.GetComponent<MenuTransition>().SetFileRef();
        SaveAndLoad.IsReadyDrawMap = false;
        SaveAndLoad.IsReadyPlay = false;
        SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
        menuKeeper.GetComponent<MenuTransition>().isLoadBtnSelected = true;
        menuKeeper.GetComponent<MenuTransition>().ShowLoadElement();
    }
    public void MainMenuSave()
    {
        CellState.MapListL1Allocate();
        CellState.MapListL2Allocate();

        plane.GetComponent<Map>().SaveBoard();
        SaveAndLoad.IsReadyDrawMap = false;
        SaveAndLoad.IsReadyPlay = false;
        SaveAndLoad.IsReadyLoadFunction = false;
        // ScoreState.isLoad = false;


        SaveAndLoad.SaveGame();

        ScoreState.RenewGame();
        plane.GetComponent<Map>().mapListL1.Clear();

        SceneManager.LoadScene(0);
    }
    public void MainMenuExit()
    {
        SaveAndLoad.IsReadyDrawMap = false;
        SaveAndLoad.IsReadyPlay = false;
        SaveAndLoad.IsReadyLoadFunction = false;
        // ScoreState.IsLoad = false; EDIT1ss
        plane.GetComponent<Map>().mapListL1.Clear();

       //CellState.MapListL1.Clear();
       // CellState.MapListL2.Clear();
       //
        CellState.MapListL1Allocate();
        CellState.MapListL1Allocate();

        ScoreState.RenewGame();
        SceneManager.LoadScene(0);
    }
*/
}
