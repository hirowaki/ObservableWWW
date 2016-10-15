using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;

public class MainSceneViewController : ViewBaseController {
    [SerializeField] private Button _button1;

    // Use this for initialization
    void Start () {
        _button1.onClick.AsObservable().Subscribe(_ => {
            // observing.
            this.InvokeEvent("WWWDownloadScene", _button1.name);
        });
    }
}
