﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class MainSceneController : SceneBaseController {
    [SerializeField] private MainSceneViewController _view;

    // Use this for initialization
    void Start () {
        startObserving(_view);
    }

    protected override void onNotify (string eventName, string from) {
        Debug.Log(String.Format("event: {0} from: {1}", eventName, from));

        switch (eventName) {
        case "WWWDownloadScene":
            SceneManager.LoadScene("WWWDownloadScene");
            return;
        default:
            break;
        }
    }
}
