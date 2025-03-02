using Managers;
using UnityEngine;

public class ClickListenerNode : MonoBehaviour, IInteractable
{

    public void OnStart()//unity event - start game / new or load - add to list of triggerable functions
    {
        //when server implemented do
        //GetNodeState();
    }

    public void Interact()
    {
        /* switch (BuilderHelper.BuildState)
         {
             case BuildState.Build:

                 break;

             case BuildState.Bulldoze:
                 Bulldoze(IsAltPressed(), MapHelper.CalculateNodeId((int)transform.position.x, (int)transform.position.y));
                 break;
         }*/
        Action(IsAltPressed(), Helpers.MapHelper.CalculateNodeId((int)transform.position.x, (int)transform.position.y));
    }
    private bool IsAltPressed()
    {
        bool isAltPressed = false;
        if (Input.GetKeyDown("left alt"))
        {
            isAltPressed = true;
        }
        return isAltPressed;
    }
    /// <summary>
    /// Checks state of AltState and alters it based on certain conditions
    /// </summary>
    private void AltStateCondition()
    {
        if (!Input.GetKeyDown("left alt"))
        {
            Helpers.BuilderHelper.NavigateAltState(0);
            System.Diagnostics.Debug.WriteLine("Alt Not Detected");
            return;
        }

        if (Input.GetKeyDown("left alt") && Helpers.BuilderHelper.AltState == Helpers.AltState.False) Helpers.BuilderHelper.NavigateAltState(1);
        if (Input.GetKeyDown("left alt") && Helpers.BuilderHelper.AltState == Helpers.AltState.FirstSelected) Helpers.BuilderHelper.NavigateAltState(2);
        if (Input.GetKeyDown("left alt") && Helpers.BuilderHelper.AltState == Helpers.AltState.SecondSelected) Helpers.BuilderHelper.NavigateAltState(3);
        if (Input.GetKeyDown("left alt") && Helpers.BuilderHelper.AltState == Helpers.AltState.Confirmed) Helpers.BuilderHelper.NavigateAltState(0);
        System.Diagnostics.Debug.WriteLine("Alt Detected - AltState After Click: {0}", Helpers.BuilderHelper.AltState);
    }
    private GameObject gameManager,mapManager;
    private void Action(bool altPressed, int n_Id)
    {
        if (mapManager == null) mapManager = GameObject.Find("MapManager");
        AltStateCondition();
        if (altPressed)//evalute this if and switch
        {
            switch (Helpers.BuilderHelper.GetAltState())//get state of alt key
            {
                case 1://get first alt node
                    Helpers.BuilderHelper.N_Id_1_Alt = n_Id;
                    if (gameManager == null) gameManager = GameObject.Find("GameManager");
                    //gameManager = GameObject.Find("GameManager");
                    //gameManager.GetComponent<Game>().UpdateAltBuild_UIElements();
                    return; //give player opportunity to select second node

                case 2://get second alt node
                    Helpers.BuilderHelper.N_Id_2_Alt = n_Id;
                    //gameManager = GameObject.Find("GameManager");
                    //gameManager.GetComponent<Game>().UpdateAltBuild_UIElements();
                    Helpers.BuilderHelper.AltPopulatedNodeArray = Helpers.MapHelper.PopulateNodeArray(Helpers.BuilderHelper.N_Id_1_Alt, Helpers.BuilderHelper.N_Id_2_Alt);
                    mapManager.GetComponent<Managers.Map>().SetOpacitySelection(Helpers.MapHelper.AltNodeArray, 0.75f); //toggle highlight on
                    return;//give player opportunity to confirm selection

                case 3://alt build
                    Helpers.BuilderHelper.AltState = Helpers.AltState.False; //reset 
                    //gameManager = GameObject.Find("GameManager");
                    //gameManager.GetComponent<Game>().UpdateAltBuild_UIElements();
                    mapManager.GetComponent<Managers.Map>().SetOpacitySelection(Helpers.MapHelper.AltNodeArray, 1f); //toggle highlight off
                    break; //continue
            }
        }
        else { Helpers.BuilderHelper.AltPopulatedNodeArray = new int[1]; } //singular build
        mapManager.GetComponent<Managers.Map>().Action();
    }
   /* private void Bulldoze(bool altPressed, int n_Id)
    {
        if (mapManager == null) mapManager = GameObject.Find("MapManager");
        AltStateCondition();
        if (altPressed)
        {
            switch (BuilderHelper.GetAltState())//get state of alt key
            {
                case 1://get first alt node
                    BuilderHelper.N_Id_1_Alt = n_Id;
                    if (gameManager == null) gameManager = GameObject.Find("GameManager");
                    //gameManager = GameObject.Find("GameManager");
                    gameManager.GetComponent<Game>().UpdateAltBuild_UIElements();
                    return; //give player opportunity to select second node

                case 2://get second alt node
                    BuilderHelper.N_Id_2_Alt = n_Id;
                    //gameManager = GameObject.Find("GameManager");
                    gameManager.GetComponent<Game>().UpdateAltBuild_UIElements();
                    BuilderHelper.NodeIdAltArray = MapHelper.PopulateNodeArray(BuilderHelper.N_Id_1_Alt, BuilderHelper.N_Id_2_Alt);
                    mapManager.GetComponent<Managers.Map>().SetOpacitySelection(MapHelper.AltNodeArray, 0.75f); //toggle highlight on
                    return;//give player opportunity to confirm selection

                case 3://alt build
                    BuilderHelper.AltState = AltState.False; //reset 
                    //gameManager = GameObject.Find("GameManager");
                    gameManager.GetComponent<Game>().UpdateAltBuild_UIElements();
                    mapManager.GetComponent<Managers.Map>().SetOpacitySelection(MapHelper.AltNodeArray, 1f); //toggle highlight off
                    break; //continue
            }
        }
        else { BuilderHelper.NodeIdAltArray = new int[1]; } //singular bulldoze 
        mapManager.GetComponent<Managers.Map>().Action();
    }*/ //no longer required due to buildstate checks done on Map.cs / MapManager
}

