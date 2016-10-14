using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;

public class WWWDownloadSceneController : MonoBehaviour {
    [SerializeField] private WWWDownloadViewController _view;

    void Start () {
        // https://github.com/neuecc/UniRx#network-operations


        SetText("START");
        const int constantDelay = 1000;

        Observable.Return(0)
            .SelectMany(_ => {
                return Wait(constantDelay);
            })
            .SelectMany(_ => {
                // replace IObservable => IObservable using SelectMany (map<IObservable>).
                SetText("GOOGLE");
                return ObservableWWW.Get("http://google.com/");
            })
            .SelectMany(x => {
                // replace IObservable => IObservable using SelectMany.
                // kinda (.map<IObservable>).
                Debug.Log(x.Substring(0, 100));
                return Wait(constantDelay);
            })
            .SelectMany(_ => {
                SetText("YAHOO");
                return ObservableWWW.Get("http://yahoo.com/");
            })
            .SelectMany(x => {
                Debug.Log(x.Substring(0, 100));

                return Wait(constantDelay);
            })
            .Subscribe(_ => {
                SetText("FINISH");
            });
    }

    IObservable<int> Wait(int sec) {
        return Observable.Return(0)
            .Delay(TimeSpan.FromMilliseconds(sec));
    }

    IObservable<string> WWW() {
        return ObservableWWW.Get("http://google.co.jp/");
    }

    private void SetText (string text) { 
        _view.SetText(text);
    }
}
    