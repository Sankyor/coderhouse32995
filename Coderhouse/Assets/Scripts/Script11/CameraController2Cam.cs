using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2Cam : MonoBehaviour
{
    [SerializeField] private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
        camera.ResetWorldToCameraMatrix();
        camera.ResetProjectionMatrix();
        camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
    }
}
