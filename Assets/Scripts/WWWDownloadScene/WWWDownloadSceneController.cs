using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UniRx;

public class WWWDownloadSceneController : SceneBaseController {
    [SerializeField] private WWWDownloadViewController _view;

    void Start () {
        SetText("START");
        PauseSpinner();

        StartObserving(_view);

        // Kick job.
        DownloadJob();
    }

    protected override void OnNotify (string eventName, string from) {
        Debug.Log(String.Format("event: {0} from: {1}", eventName, from));

        switch (eventName) {
        case "MainScene":
            SceneManager.LoadScene("MainScene");
            return;
        default:
            break;
        }
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

    private void StartSpinner () { 
        _view.StartLoading();
    }

    private void PauseSpinner () { 
        _view.PauseLoading();
    }

    private void HideSpinner () { 
        _view.EndLoading();
    }

    private void ShowBackButton () { 
        _view.ShowBackButton();
    }

    private void DownloadJob() {
        // https://github.com/neuecc/UniRx#network-operations

        const int constantDelay = 1000;

        Observable.Return(0)
            .SelectMany(_ => {
                return Wait(constantDelay);
            })
            .SelectMany(_ => {
                StartSpinner();

                // replace IObservable<> => IObservable<> using SelectMany (map<IObservable>).
                SetText("GOOGLE");
                return ObservableWWW.Get("http://google.com/");
            })
            .SelectMany(x => {
                // replace IObservable<> => IObservable<> using SelectMany.
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
                HideSpinner();
                ShowBackButton();
                SetText("FINISH");
            })
            .AddTo(this);
    }        
}
    