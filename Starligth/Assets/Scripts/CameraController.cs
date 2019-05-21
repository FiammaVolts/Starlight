using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;

    private void Start()
    {
        camera.SetActive(false);
    }

    void Update()
    {
        ChangeCamera();
    }

    private void ChangeCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            camera.SetActive(true);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            camera.SetActive(false);
        }
    }
}
