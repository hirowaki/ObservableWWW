using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SceneBaseController : MonoBehaviour {
    private ViewEvent _event;

    protected void startObserving(ViewBaseController viewController) {
        viewController.setObserver(onNotify);
    }
        
    protected virtual void onNotify (string eventName, string from) {}
}
