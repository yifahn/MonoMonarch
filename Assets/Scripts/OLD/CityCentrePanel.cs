using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCentrePanel : MonoBehaviour
{
    public GameObject panel,plane, panelCityCentre;
    void Start()
    {
       // panel = this.gameObject;
        panelCityCentre = GameObject.Find("RightPanel");
        panelCityCentre.SetActive(false);
        plane = GameObject.Find("Plane");

    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(1))//sss
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500.0f))
            {
                string tempString = hit.collider.name;
                Debug.Log(tempString);
                if (hit.collider.name.Contains("City Centre"))
                {
                    panelCityCentre.SetActive(true);
                }

            }
        }
    }
    public void CloseParentUI()
    {
        panelCityCentre.SetActive(false);
    }


}
