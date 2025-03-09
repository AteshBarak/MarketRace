using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [Header("Speed")]
    public float speed;

    private Material mat;
    private float y = 0;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        SeaFunction();
    }

    private void SeaFunction()
    {
        y += Time.deltaTime / speed;

        mat.SetTextureOffset("_MainTex", new Vector2(0, y));
    }
}
