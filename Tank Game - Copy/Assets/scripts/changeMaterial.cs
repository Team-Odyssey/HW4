using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] materials;
    public MeshRenderer meshRenderer;
    int index = 0;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            index++;
            index = index % 2;
            meshRenderer.material = materials[index];
        }
    }
}
