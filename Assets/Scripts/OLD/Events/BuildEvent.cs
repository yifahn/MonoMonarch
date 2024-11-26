using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Game Event/Build")]
public class BuildEvent : ScriptableObject
{
    private List<BuilderListener> listeners = new List<BuilderListener>();
    public void TriggerEvent()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
    }
    public void AddListener(BuilderListener listener)
    {
        listeners.Add(listener);
    }
    public void RemoveListener(BuilderListener listener)
    {
        listeners.Remove(listener);
    }
}