using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawn : MonoBehaviour
{
    public GameObject spawnPlayer, spawnOpponent;
    public bool hasPlayerSpawn, hasOpponentSpawn;

    public GameObject plane;

    public void Start()
    {
        plane = GameObject.Find("Plane");
    }

    public void SetPlayerSpawn(GameObject cell)
    {
        if (hasPlayerSpawn)
        {
            Debug.Log("You already have a player spawn set!");
        }
        else if (!hasPlayerSpawn)
        {
            bool canSetSpawn = true;
            int z = 0;
            if (SaveAndLoad.IsLoad)
            {
                Debug.Log("isLoad playerSpawn");
                canSetSpawn = true;
            }
            else
            {
                foreach (GameObject mapListCell in plane.GetComponent<Map>().mapListL1) //check if playerspawn is being set on a opponent spawn - DO NOT ALLOW IT
                {
                    if (mapListCell == cell)
                    {
                        Debug.Log("arrived here");
                        if (z.ToString().Equals(CellState.opponentSpawn))
                        {
                            canSetSpawn = false;
                            string zString = string.Format("{0} is equal to CellState.opponentSpawn", z.ToString());
                            Debug.Log(zString);

                        }
                    }
                    z++;
                }
                z = 0;
            }
            if (canSetSpawn)
            {

                Debug.Log("Setting player spawn");

                Debug.Log("arrived here");//ss
                int h = 0;
                if (SaveAndLoad.IsLoad == false) //WORKS - LOAD == TRUE DOES NOT WORK
                {
                    Vector3 spawnPos = new Vector3(cell.transform.position.x, cell.transform.position.y + 1, cell.transform.position.z);
                    Debug.Log("arrived here");
                    foreach (GameObject mapListCell in plane.GetComponent<Map>().mapListL1)
                    {

                        if (mapListCell == cell)
                        {

                            string tempString = h.ToString();
                            // Remove all newlines from the 'example' string variable
                            string cleanedTempString = tempString.Replace("\n", "").Replace("\r", "");
                            Debug.Log(cleanedTempString);
                            CellState.playerSpawn = cleanedTempString;
                            Debug.Log(CellState.playerSpawn);
                        }
                        h++;

                    }
                    Instantiate(spawnPlayer, spawnPos, Quaternion.identity);
                    Debug.Log("arrived here");
                    Debug.Log(spawnPos.x + " " + spawnPos.z);
                    Debug.Log(cell.name);
                    hasPlayerSpawn = true;
                }
                else //FIX THIS - BROKEN
                {

                    //


                    h = 0;
                    Vector3 spawnPos = new Vector3(cell.transform.position.x, cell.transform.position.y + 1, cell.transform.position.z);
                    Debug.Log("arrived here");
                    foreach (GameObject mapListCell in plane.GetComponent<Map>().mapListL1)
                    {
                        if (mapListCell == cell)
                        {
                            string tempString = h.ToString();
                            // Remove all newlines from the 'example' string variable
                            string cleanedTempString = tempString.Replace("\n", "").Replace("\r", "");
                            Debug.Log(cleanedTempString);
                            CellState.playerSpawn = cleanedTempString;
                            Debug.Log(CellState.playerSpawn);
                        }
                        h++;
                    }
                    Instantiate(spawnPlayer, spawnPos, Quaternion.identity);
                    Debug.Log("arrived here");
                    Debug.Log(spawnPos.x + " " + spawnPos.z);
                    Debug.Log(cell.name);
                    hasPlayerSpawn = true;

                    //

                    //MAY REQUIRE REPLACEMENT
                    /*float zPosTemp = 0;
                    float xPosTemp = 0;
                    int offSet = 3;
                    Vector3 spawnPos;
                    Debug.Log("arrived here");
                    Debug.Log(CellState.playerSpawn);
                    int tempInt = int.Parse(CellState.playerSpawn); // - BREAKS HERE
                    int i2 = 0;

                    for (int xPos = 1; xPos <= 33; xPos++)
                    {

                        for (int zPos = 1; zPos <= 60; zPos++)
                        {
                            if (i2 == tempInt)
                            {
                                //    new Vector3(zPos * offSet, 0, -xPos * offSet), Quaternion.identity);
                                zPosTemp = zPos * offSet;
                                xPosTemp = -xPos * offSet;
                            }
                            i2++;
                        }
                    }
                    i2 = 0;
                    spawnPos = new Vector3(zPosTemp, 1.2f, xPosTemp);
                    Debug.Log(spawnPos.x + " " + spawnPos.z);
                    Instantiate(spawnPlayer, spawnPos, Quaternion.identity);
                    Debug.Log("arrived here");
                    Debug.Log(spawnPos.x + " " + spawnPos.z);
                    Debug.Log(cell.name);
                    hasPlayerSpawn = true;
                    */
                }
              //  h = 0;
            }
            else
            {
                Debug.Log("Cannot instantiate player spawn on same cell as opponent spawn");
            }

        }
    }
    public void SetOpponentSpawn(GameObject cell)
    {
        if (hasOpponentSpawn)
        {
            Debug.Log("You already have a player spawn set!");
        }
        else if (!hasOpponentSpawn)
        {
            bool canSetSpawn = true;
            int z = 0;
            if (SaveAndLoad.IsLoad)
            {
                Debug.Log("isLoad playerSpawn");
                canSetSpawn = true;
            }
            else
            {
                foreach (GameObject mapListCell in plane.GetComponent<Map>().mapListL1) //check if playerspawn is being set on a opponent spawn - DO NOT ALLOW IT
                {
                    if (mapListCell == cell)
                    {
                        Debug.Log("arrived here");
                        if (z.ToString().Equals(CellState.playerSpawn))
                        {
                            canSetSpawn = false;

                            Debug.Log("z.ToString() is equal to CellState.playerSpawn");

                        }
                    }
                    z++;
                }
                z = 0;
            }
            if (canSetSpawn)
            {

                Debug.Log("Setting opponent spawn");

                Debug.Log("arrived here");
                int h = 0;
                if (SaveAndLoad.IsLoad == false)
                {
                    Vector3 spawnPos = new Vector3(cell.transform.position.x, cell.transform.position.y + 1, cell.transform.position.z);
                    Debug.Log("arrived here");
                    foreach (GameObject mapListCell in plane.GetComponent<Map>().mapListL1)
                    {

                        if (mapListCell == cell)
                        {

                            string tempString = h.ToString();
                            // Remove all newlines from the 'example' string variable
                            string cleanedTempString = tempString.Replace("\n", "").Replace("\r", "");
                            Debug.Log(cleanedTempString);
                            CellState.opponentSpawn = cleanedTempString;
                            Debug.Log(CellState.opponentSpawn);
                        }
                        h++;

                    }
                    Instantiate(spawnOpponent, spawnPos, Quaternion.identity);
                    Debug.Log("arrived here");
                    Debug.Log(spawnPos.x + " " + spawnPos.z);
                    Debug.Log(cell.name);
                    hasOpponentSpawn = true;
                }
                else
                {
                    //
                    h = 0;
                    Vector3 spawnPos = new Vector3(cell.transform.position.x, cell.transform.position.y + 1, cell.transform.position.z);
                    Debug.Log("arrived here");
                    foreach (GameObject mapListCell in plane.GetComponent<Map>().mapListL1)
                    {

                        if (mapListCell == cell)
                        {

                            string tempString = h.ToString();
                            // Remove all newlines from the 'example' string variable
                            string cleanedTempString = tempString.Replace("\n", "").Replace("\r", "");
                            Debug.Log(cleanedTempString);
                            CellState.opponentSpawn = cleanedTempString;
                            Debug.Log(CellState.opponentSpawn);
                        }
                        h++;

                    }
                    Instantiate(spawnOpponent, spawnPos, Quaternion.identity);
                    Debug.Log("arrived here");
                    Debug.Log(spawnPos.x + " " + spawnPos.z);
                    Debug.Log(cell.name);
                    hasOpponentSpawn = true;

                    //
                    /*
                    float zPosTemp = 0;
                    float xPosTemp = 0;
                    int offSet = 3;
                    Vector3 spawnPos;
                    Debug.Log("arrived here");
                    int tempInt = int.Parse(CellState.opponentSpawn);
                    int i2 = 0;

                    for (int xPos = 1; xPos <= 33; xPos++)
                    {

                        for (int zPos = 1; zPos <= 60; zPos++)
                        {
                            if (i2 == tempInt)
                            {
                                //    new Vector3(zPos * offSet, 0, -xPos * offSet), Quaternion.identity);
                                zPosTemp = zPos * offSet;
                                xPosTemp = -xPos * offSet;
                            }
                            i2++;
                        }
                    }
                    i2 = 0;
                    spawnPos = new Vector3(zPosTemp, 1.2f, xPosTemp);
                    Debug.Log(spawnPos.x + " " + spawnPos.z);
                    Instantiate(spawnOpponent, spawnPos, Quaternion.identity);
                    Debug.Log("arrived here");
                    Debug.Log(spawnPos.x + " " + spawnPos.z);
                    Debug.Log(cell.name);
                    hasOpponentSpawn = true;
                    */
                }
               // h = 0;
            }
            else
            {
                Debug.Log("Cannot instantiate op spawn on same cell as opponent spawn");
            }

        }
    }
}
