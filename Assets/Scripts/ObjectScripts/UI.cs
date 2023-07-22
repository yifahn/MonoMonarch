using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour, IInteractable
{
    public GameObject button;

    public void Interact()
    {
        Debug.Log("WORKING!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        if (Input.GetMouseButtonDown(0))
        {
           
            SceneManager.SceneState = SceneManager.SceneTransition(gameObject.name);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //other functionality
        }
    }
    //UIManager.GetScene(x) - when UIManager is written, required to check if this button is used in a particular scene
}
