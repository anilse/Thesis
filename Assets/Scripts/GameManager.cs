using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool InputTaken()
    {
        return Input.touchCount > 0 || Input.GetMouseButtonUp(0);
    }
}
