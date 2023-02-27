using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    //[SerializeField] private KeyCode shootKeyCode;
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform pointOfShoot;
    [SerializeField] private float shootTime;
    private float chronometer;

    void Start()
    {
        chronometer = Time.time + shootTime;
    }

    void Update()
    {
        if (chronometer <= Time.time)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(ball, pointOfShoot);
        chronometer += shootTime;
    }
}
