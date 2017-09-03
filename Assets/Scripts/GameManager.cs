using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    CreateBlock block;

    void initGame()
    {
        block = FindObjectOfType<CreateBlock>();

    }
	// Use this for initialization
	void Start () {
        this.initGame();
        StartCoroutine(block.SpawnBlock());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (InputTaken() && block.blockCreated)
            block.MoveDown();
	}

    private bool InputTaken()
    {
        return Input.touchCount > 0 || Input.GetMouseButtonUp(0);
    }
}
