using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Tank8 : MonoBehaviour
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
    [SerializeField] private Vector3 initialRotation;
    [SerializeField] private float rotationSpeed;
    private float chronometer;

    void Start()
    {
        chronometer = Time.time;
    }

    void Update()
    {
        Movement(GetMoveVector());
        if (Input.GetKey(KeyCode.Mouse1))
            TankRotation(GetRotationAmount());
        if (Input.GetKeyDown(key))
        {
            if (chronometer <= Time.time)
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

    private void Movement(Vector3 moveDir)
    {
        var transform1 = transform;
        transform1.position +=
            //Vector3.MoveTowards(transform.position, (moveDir.x * transform1.right + moveDir.z * transform.forward), Time.deltaTime);
            (moveDir.x * transform1.right + moveDir.z * transform.forward) * (speed * Time.deltaTime);

    }
    private Vector3 GetMoveVector()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal,0, vertical).normalized;
    }
    private void TankRotation(float rotateAmount)
    {

        transform.Rotate(Vector3.up, rotateAmount * Time.deltaTime * rotationSpeed, Space.Self);
    }
    private float GetRotationAmount()
    {
        return Input.GetAxis("Mouse X");
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
