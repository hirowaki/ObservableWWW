using System;
using UnityEngine;
using System.Collections;
using UniRx;

public class WWWDownloadSceneController : MonoBehaviour {
    private string _message = "READY";

    // static.
    private static GUIStyle _guiStyle = new GUIStyle();
    private static Rect _guiRect = new Rect();
    private static Color _colorWhite = new Color(1, 1, 1, 1);

    void Start () {
        // https://github.com/neuecc/UniRx#network-operations

        _message = "START";
        const int constantDelay = 1000;

        Observable.Return(0)
            .SelectMany(_ => {
                return Wait(constantDelay);
            })
            .SelectMany(_ => {
                // replace IObservable => IObservable using SelectMany (map<IObservable>).
                _message = "GOOGLE";
                return ObservableWWW.Get("http://google.com/");
            })
            .SelectMany(x => {
                // replace IObservable => IObservable using SelectMany.
                // kinda (.map<IObservable>).
                Debug.Log(x.Substring(0, 100));
                return Wait(constantDelay);
            })
            .SelectMany(_ => {
                _message = "YAHOO";
                return ObservableWWW.Get("http://yahoo.com/");
            })
            .SelectMany(x => {
                Debug.Log(x.Substring(0, 100));

                return Wait(constantDelay);
            })
            .Subscribe(_ => {
                _message = "FINISH";
            });
    }

    IObservable<int> Wait(int sec) {
        return Observable.Return(0)
            .Delay(TimeSpan.FromMilliseconds(sec));
    }

    IObservable<string> WWW() {
        return ObservableWWW.Get("http://google.co.jp/");
    }

    void OnGUI() {
        _guiStyle.fontSize = 32;
        _guiStyle.normal.textColor = _colorWhite;
        _guiStyle.alignment = TextAnchor.MiddleCenter;

        _guiRect.width = 128;
        _guiRect.height = 32;
        _guiRect.x = Screen.width / 2 - _guiRect.width / 2;;
        _guiRect.y = Screen.height / 2 - _guiRect.height / 2;;

        GUI.Label(_guiRect, _message, _guiStyle);
    }
}
    