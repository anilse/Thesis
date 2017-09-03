using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour {

    public Rigidbody prefab;
    public Vector3 position;
    public Quaternion rotation;

    // Use this for initialization
    void Start()
    {
        Renderer renderer = prefab.GetComponent<Renderer>();
        Material rootMat = new Material(Shader.Find("Standard"));
        var num = Random.Range(0, 2);
        if (num == 0)
            rootMat.color = Color.red;
        else
            rootMat.color = Color.blue;
        renderer.sharedMaterial = rootMat;
        StartCoroutine(FillGrid(num, renderer, rootMat));
    }

    IEnumerator FillGrid(int num, Renderer renderer, Material rootMat)
    {

        float startingZ = position.z;
        for (int x = 0; x < 5; x++)
        {
            position.z = startingZ;
            for (int y = 0; y < 5; y++)
            {
                yield return null;

                Instantiate(prefab.transform, position, rotation);
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

    }

    // Update is called once per frame
    void Update () {
		
	}
}
