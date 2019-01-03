using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
    public Button b1;
    public Button b2;
    public Button b3;
    public GameObject cube;

	// Use this for initialization
	void Start () {
        b1.onClick.AddListener(print);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void print()
    {
        cube.SetActive(false);
    }
}
