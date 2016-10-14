using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;

[System.Serializable]
public class MyIntEvent : UnityEvent<string, string>
{
}

public class MainSceneViewController : MonoBehaviour {
    [SerializeField] private Button _button1;
    public MyIntEvent _event;

    // Use this for initialization
    void Start () {
        _button1.onClick.AsObservable().Subscribe(_ => {
            // observing.
            this.invokeEvent("WWWDownloadScene", _button1.name);
        });
    }

    // invoke.
    public void invokeEvent(string eventName, string from) {
        _event.Invoke(eventName, from);
    }

    // setObserver.
    public void setObserver(UnityAction<string, string> observer) {
        _event.AddListener(observer);
    }
}
