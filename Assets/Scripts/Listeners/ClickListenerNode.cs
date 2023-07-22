using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ClickListenerNode : MonoBehaviour, IInteractable
{
    void OnMouseDown()
    {
        AltStateCondition();
        Interact();
    }
    public void Interact()
    {

        switch (BuilderManager.BuildState)
        {
            case BuildStateEnum.Build:
                BuilderManager.Build(IsAltPressed(), MapManager.CalculateNodeId((int)transform.position.x,(int)transform.position.y));
                break;

            case BuildStateEnum.Bulldoze:
                BuilderManager.Bulldoze(IsAltPressed(), MapManager.CalculateNodeId((int)transform.position.x,(int)transform.position.y));
                break;
        }

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
            BuilderManager.NavigateAltState(0);
            System.Diagnostics.Debug.WriteLine("Alt Not Detected");
            return;
        }

        if (Input.GetKeyDown("left alt") && BuilderManager.AltState == AltStateEnum.False) BuilderManager.NavigateAltState(1);
        if (Input.GetKeyDown("left alt") && BuilderManager.AltState == AltStateEnum.FirstSelected) BuilderManager.NavigateAltState(2);
        if (Input.GetKeyDown("left alt") && BuilderManager.AltState == AltStateEnum.SecondSelected) BuilderManager.NavigateAltState(3);
        if (Input.GetKeyDown("left alt") && BuilderManager.AltState == AltStateEnum.Confirmed) BuilderManager.NavigateAltState(0);
        System.Diagnostics.Debug.WriteLine("Alt Detected - AltState After Click: {0}", BuilderManager.AltState);
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}

