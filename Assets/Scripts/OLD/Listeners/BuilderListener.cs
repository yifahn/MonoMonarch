using UnityEngine;
using UnityEngine.Events;

public class BuilderListener : MonoBehaviour
{
    public BuildEvent buildEvent;
    public UnityEvent onBuildEventTriggered;

    private void OnEnable()
    {
        // Subscribe to the Build event when the GameObject becomes active/enabled.
        buildEvent.AddListener(this);
    }

    private void OnDisable()
    {
        // Unsubscribe from the Build event when the GameObject becomes inactive/disabled.
        buildEvent.RemoveListener(this);
    }

    public void OnEventTriggered()
    {
        // This method will be called when the Build event is triggered.
        onBuildEventTriggered.Invoke();
        
    }
}