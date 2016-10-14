using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;

public class MainSceneViewController : MonoBehaviour {
    [SerializeField] private Button _button1;
    public UnityEvent _event;

    // Use this for initialization
    void Start () {
        _button1.onClick.AsObservable().Subscribe(_ => {
            // observing.
            this.triggerEvent("CLICKED", _button1.name);
        });
    }

    // Update is called once per frame
    void Update () {

    }

    public void triggerEvent(string eventName, string from) {
        _event.Invoke();
    }

    // setObserver.
    public void setObserver(UnityAction observer) {
        _event.AddListener(observer);
    }
}
