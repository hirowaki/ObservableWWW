using System;
using UnityEngine;
using System.Collections;

public class ViewBaseController : MonoBehaviour {
    public event Action<string, string> _action;

    // invoke.
    protected void InvokeEvent(string eventName, string from) {
        if (_action != null) {
            _action(eventName, from);
        }
    }

    // SetObserver.
    public void SetObserver(Action<string, string> handler) {
        _action += handler;
    }
}
