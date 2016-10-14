using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WWWDownloadViewController : MonoBehaviour {
    [SerializeField] private Text _text1;

	// Use this for initialization
	void Start () {
        SetText("");
	}

    public void SetText(string text) {
        _text1.text = text;
    } 
}
