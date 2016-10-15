using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class ViewEvent : UnityEvent<string, string>
{
}


public class ViewBaseController : MonoBehaviour {
    private ViewEvent _event;

    // invoke.
    protected void InvokeEvent(string eventName, string from) {
        if (_event != null) {
            _event.Invoke(eventName, from);
        }
    }

    // SetObserver.
    public void SetObserver(UnityAction<string, string> observer) {
        if (_event == null) {
            _event = new ViewEvent ();
        }

        _event.AddListener(observer);
    }
}
