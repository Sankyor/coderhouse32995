using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Tank7 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform pointOfShoot;
    [SerializeField] private float shootTime;
    [SerializeField] private float speed;
    [SerializeField] private KeyCode key;
    [SerializeField] private KeyCode keyCamera;
    [SerializeField] private CinemachineVirtualCamera camera1;
    [SerializeField] private CinemachineVirtualCamera camera2;

    private float chronometer;
    private Vector3 movement;
    private void Movement(float moveX, float moveY)
    {
        movement.Set(moveX, 0, moveY);
        transform.position += movement * speed * Time.deltaTime;
    }

    void Start()
    {
        chronometer = Time.time;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Movement(moveX, moveY);
        if (Input.GetKeyDown(key))
        { 
             if(chronometer <= Time.time)
             { 
                Shoot(); 
             }
            
        }
        
        if (Input.GetKeyDown(keyCamera))
        {
            if (!camera1.isActiveAndEnabled)
            {
                TurnOnCamera(camera1, camera2);
            }
            else
            { 
                TurnOnCamera(camera2, camera1); 
            }
        }
    }
    private void TurnOnCamera(CinemachineVirtualCamera camToTurnOn, CinemachineVirtualCamera otherCamera)
    {
        camToTurnOn.gameObject.SetActive(true);
        otherCamera.gameObject.SetActive(false); 
    }

    private void Shoot()
    {
        Instantiate(ball, pointOfShoot);
        chronometer = Time.time + shootTime;        
    }
}
