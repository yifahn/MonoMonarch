using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedNode : MonoBehaviour
{
    public GameObject node,building;

    public void Start()
    {
        node = GameObject.Find("SelectedNode");
        building = GameObject.Find("LeftPanel");
    }
    public void UpdateSelectedNode()
    {
       // string tempString = building.GetComponent<Building>().buildingKeeper.SelectedCell.name;
      //  node.GetComponent<Text>().text = string.Format("Selected Node: {0}",tempString);
    }

}
