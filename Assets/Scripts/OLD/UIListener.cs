using Managers;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIListener : MonoBehaviour, IInteractable
{

    public void Interact()
    {

        Managers.SceneManager.Instance.SceneSelector(Helpers.SceneHelper.SceneStateUpdate(gameObject.name));

    }
}
