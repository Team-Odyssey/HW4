using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera thirdPersonCam;
    public Camera overheadCam;
    void Start()
    {
        thirdPersonCam.enabled = true;
        overheadCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            thirdPersonCam.enabled = !thirdPersonCam.enabled;
            overheadCam.enabled = !overheadCam.enabled;
        }
    }
}
