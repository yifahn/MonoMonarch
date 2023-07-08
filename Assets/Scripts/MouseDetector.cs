using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDetector : MonoBehaviour
{
    public GameObject plane, overwriteToggle;
    void OnMouseEnter()//note to self - may be faster to execute if all GameObject.Find/s were executed prior to OnMouseEnter, and instead on object instantiation
    {
        if (Input.GetButton("left shift") && Input.GetMouseButton(0)) //IF ShiftBuild/Remove
        {
            plane = GameObject.Find("Plane");
            overwriteToggle = GameObject.Find("ToggleOverWrite");
            plane.GetComponent<Map>().ShiftBuildRemove(gameObject);//send this gameobject to ShiftBuildRemove method within Map.cs ssss
        }
    }

    void OnMouseDown()
    {
        if (!Input.GetButton("left alt"))
        {
            Debug.Log("Executing SingleBuild/Remove");
            plane = GameObject.Find("Plane");
            plane.GetComponent<Map>().SingleBuildRemove(gameObject);
            Debug.Log("Executed SingleBuild/Remove");
        }
        else
        {
            Debug.Log("Executing MultiBuild/Remove");
            plane = GameObject.Find("Plane");
            plane.GetComponent<Map>().MultiBuildRemove(gameObject);
            Debug.Log("Executed MultiBuild/Remove");
        }
    }
}
