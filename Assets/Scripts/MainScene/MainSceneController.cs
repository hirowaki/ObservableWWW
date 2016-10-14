using UnityEngine;
using System.Collections;

public class MainSceneController : MonoBehaviour {
    [SerializeField] private MainSceneViewController _view;

    // Use this for initialization
    void Start () {
        _view.setObserver(() => {
            Application.LoadLevel ("WWWDownloadScene");
        });
    }

    // Update is called once per frame
    void Update () {

    }
}
