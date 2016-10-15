using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SceneBaseController : MonoBehaviour {
    private ViewEvent _event;

    protected void StartObserving(ViewBaseController viewController) {
        viewController.SetObserver(OnNotify);
    }
        
    protected virtual void OnNotify (string eventName, string from) {}
}
