using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public BuildEvent gameEvent;
    void Start()
    {
        // Triggers the event
        gameEvent.TriggerEvent();
    }
}

