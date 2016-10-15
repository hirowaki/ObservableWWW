using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;

public class WWWDownloadViewController : ViewBaseController {
    [SerializeField] private Text _text1;
    [SerializeField] private RawImage _spinner;
    [SerializeField] private Button _back;

    enum Loading { NONE, LOADING, PAUSE };

    private float _rotateDegree;
    private Loading _loading = Loading.NONE;

    // Use this for initialization
	void Start () {
        SetText("");
        ShowSpinner(false);
        ShowBackButton(false);

        _back.onClick.AsObservable().Subscribe(_ => {
            // observing.
            this.InvokeEvent("MainScene", _back.name);
        });
    }

    void Update () {
        if (this.ShowSpinner(_loading != Loading.NONE)) {
            if (_loading == Loading.LOADING) {
                _rotateDegree += Time.deltaTime * 90;
                _spinner.transform.rotation = Quaternion.Euler(0, 0, _rotateDegree);
            }
        }
    }

    public void SetText(string text) {
        _text1.text = text;
    }

    public void StartLoading() {
        _loading = Loading.LOADING;
    }

    public void PauseLoading() {
        _loading = Loading.PAUSE;
    }

    public void EndLoading() {
        _loading = Loading.NONE;
    }

    public void ShowBackButton() {
        ShowBackButton(true);
    }

    private bool ShowSpinner(bool visible) {
        return ToggleShowGameObject(_spinner.gameObject, visible);
    }

    private bool ShowBackButton(bool visible) {
        return ToggleShowGameObject(_back.gameObject, visible);
    }

    private bool ToggleShowGameObject(GameObject gameObject, bool visible) {
        bool active = gameObject.activeSelf;
        if (active != visible) {
            gameObject.SetActive(!active);
        }
        return gameObject.activeSelf;
    }
}
