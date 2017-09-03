using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour {

    public Rigidbody prefab;
    public Vector3 position, nextPosition;
    public Quaternion rotation;
    public bool blockCreated;

    // Use this for initialization
    void Start()
    {/*
        Renderer renderer = prefab.GetComponent<Renderer>();
        Material rootMat = new Material(Shader.Find("Standard"));
        var num = Random.Range(0, 2);
        if (num == 0)
            rootMat.color = Color.red;
        else
            rootMat.color = Color.blue;
        renderer.sharedMaterial = rootMat;
        StartCoroutine(FillGrid(num, renderer, rootMat));
        */
    }

    public IEnumerator SpawnBlock()
    {
        Renderer renderer = prefab.GetComponent<Renderer>();
        Material rootMat = new Material(Shader.Find("Standard"));
        blockCreated = false;
        var num = Random.Range(0, 2);
        if (num == 0)
            rootMat.color = Color.red;
        else
            rootMat.color = Color.blue;
        renderer.sharedMaterial = rootMat;

        float startingZ = position.z;
        for (int x = 0; x < 5; x++)
        {
            position.z = startingZ;
            for (int y = 0; y < 5; y++)
            {
                yield return null;

                Instantiate(prefab.transform, position, rotation).gameObject.name = "Cube" + x.ToString() + y.ToString();
                //GameObject.Find("Cube" + x.ToString() + y.ToString()).tag = "CubesoftheBlock";
                
                GameObject.Find("Cube" + x.ToString() + y.ToString()).transform.SetParent(GameObject.Find("Cube00").transform);
                num = Random.Range(0, 2);
                renderer.sharedMaterial = new Material(rootMat);
                if (num == 0)
                    renderer.sharedMaterial.color = Color.red;
                else
                    renderer.sharedMaterial.color = Color.blue;

                position.z = position.z + 4;
            }
            position.x = position.x + 4;
        }
        if (GameObject.Find("Cube44") != null)
            blockCreated = true;

    }

    public void MoveDown() {
        nextPosition = GameObject.Find("Cube00").transform.position;
        nextPosition.y -= (float) 1.0;
        GameObject.Find("Cube00").transform.position = nextPosition;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
