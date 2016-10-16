using UnityEngine;
using System.Collections;

public class SceneBaseController : MonoBehaviour {
    protected void StartObserving(ViewBaseController viewController) {
        viewController.SetObserver(OnNotify);
    }
        
    protected virtual void OnNotify (string eventName, string from) {}
}
