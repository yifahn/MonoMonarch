using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent : MonoBehaviour
{
    public GameObject plane,btnTransition1,btnTransition2,attacker,player,graph;
    Vector3 startVec3,endVec3;

    public void Start()
    {
        plane = GameObject.Find("Plane");
        btnTransition2 = GameObject.Find("ExitBattle");
        btnTransition2.SetActive(false);
        btnTransition1 = GameObject.Find("StartBattle");
        graph = this.gameObject;


    }
    public void TransitionBattleUI1()
    {
        btnTransition1.SetActive(false);
        btnTransition2.SetActive(true);

        BeginBattleEvent();
    }
    public void TransitionBattleUI2()
    {
        btnTransition1.SetActive(true);
        btnTransition2.SetActive(false);

        ExitBattleEvent();
    }
    public void BeginBattleEvent()
    {
        if (CellState.opponentSpawnBool == true && CellState.playerSpawnBool == true)
        {
            int iIterator = 0;
        
        foreach (GameObject cell in plane.GetComponent<Map>().mapListL1) //prop up y pos of each grassland to match buildings y pos for the duration of the battle anim.
        {
            if (cell.transform.localPosition.y != 1.2f)
            {
                    Debug.Log("cell height lifted");
                cell.transform.localPosition.Set(cell.transform.position.x, 1.2f, cell.transform.position.z);
            }
            if (cell.transform.localScale.x != 3)
            {
                cell.transform.localScale.Set(3f, 1f, 3f);
            }
            //---
           //MAYBE NEED TO SET POSITION WITH ALGO TO ITTERATE IN 3'S?
           //---

            /*  if (cell.name.Contains("Grassland"))
              {
                  Debug.Log("Setting " + cell.name + " height to match other buildings height " + i + " times");
                  Debug.Log(cell.transform.position.y);
                  float xPos = cell.transform.position.x;
                  float yPos = cell.transform.position.y + 1.2f;
                  float zPos = cell.transform.position.z;
                  float xScale = cell.transform.localScale.x + 1;
                  float yScale = cell.transform.localScale.y;
                  float zScale = cell.transform.localScale.z + 1;
                  cell.transform.position = new Vector3(xPos, yPos, zPos);
                  cell.transform.localScale = new Vector3(xScale, yScale, zScale);
                  if (i == 1)
                  {
                      Debug.Log(xPos + " " + yPos + " " + zPos + " x,y,z");//ss
                  }

                  i++;
              }*/
            iIterator++;
        }

        iIterator = 0;
       

      
            Debug.Log(int.Parse(CellState.playerSpawn));
            float x1, y1, z1, x2, y2, z2;//ss
            x1 = plane.GetComponent<Map>().mapListL1[int.Parse(CellState.opponentSpawn)].transform.position.x;
            y1 = plane.GetComponent<Map>().mapListL1[int.Parse(CellState.opponentSpawn)].transform.position.y + 2f;
            z1 = plane.GetComponent<Map>().mapListL1[int.Parse(CellState.opponentSpawn)].transform.position.z;
            x2 = plane.GetComponent<Map>().mapListL1[int.Parse(CellState.playerSpawn)].transform.position.x;
            y2 = plane.GetComponent<Map>().mapListL1[int.Parse(CellState.playerSpawn)].transform.position.y + 2f;
            z2 = plane.GetComponent<Map>().mapListL1[int.Parse(CellState.playerSpawn)].transform.position.z;
            startVec3 = new Vector3(x1, y1, z1);
            endVec3 = new Vector3(x2, y2, z2);
            Instantiate(player, endVec3, Quaternion.identity);
            Instantiate(attacker, startVec3, Quaternion.identity);
           // attacker.GetComponent<Attacker>().ExecuteShortestPathAlgorithm(plane.GetComponent<Map>().mapListL1[int.Parse(CellState.opponentSpawn)].GetComponent<Node>(), plane.GetComponent<Map>().mapListL1[int.Parse(CellState.playerSpawn)].GetComponent<Node>());


            Debug.Log("arrived here");
        }
        else
        {
            Debug.Log("Requires an opponent and player spawn before battle may commence");
        }
    }
    public void ExitBattleEvent()
    {
        int iIterator = 0;
      
        foreach (GameObject cell in plane.GetComponent<Map>().mapListL1) //prop up y pos of each grassland to match buildings y pos for the duration of the battle anim.
        {
            if (cell.transform.localPosition.y == 1.2f)
            {
                cell.transform.localPosition.Set(cell.transform.position.x, 0f, cell.transform.position.z);
            }
            if (cell.transform.localScale.x == 3)
            {
                cell.transform.localScale.Set(2f, 1f, 2f);
            }
            /* if (cell.name.Contains("Grassland"))
             {
                 Debug.Log("Setting " + cell.name + " height to match other buildings height " + i + " times");
                 Debug.Log(cell.transform.position.y);

                 float xPos = cell.transform.position.x;
                 float yPos = cell.transform.position.y - 1.2f;
                 float zPos = cell.transform.position.z;
                 float xScale = cell.transform.localScale.x - 1;
                 float yScale = cell.transform.localScale.y;
                 float zScale = cell.transform.localScale.z - 1;
                 cell.transform.position = new Vector3(xPos, yPos, zPos);
                 cell.transform.localScale = new Vector3(xScale, yScale, zScale);
                 if (i == 1)
                 {

                     Debug.Log(xPos + " " + yPos + " " + zPos + " x,y,z");
                 }

                 i++;
             }*/
            iIterator++;
        }
        iIterator = 0;
        
    }

}

