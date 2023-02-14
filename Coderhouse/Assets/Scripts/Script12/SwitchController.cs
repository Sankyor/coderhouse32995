using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfMovement
{
    Pair,
    Odd
}
public class SwitchController : MonoBehaviour
{

    [SerializeField] private PlayerController player;
    [SerializeField] private float coefficient;
    [SerializeField] private List<WallController> walls;
    [SerializeField] private TypeOfMovement typeOfMovement;
    private bool turnedOn = false;
    private float timeToSleep = 3;
    private float chronometer;

    private void Start()
    {
        chronometer = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (chronometer <= Time.time)
        {
            if (other.tag == "Player")
            {
                var playerController = other.GetComponent(typeof(PlayerController));

                if (playerController)
                {
                    switch (typeOfMovement)
                    {
                        case TypeOfMovement.Pair:
                            Pair();
                            break;
                        case TypeOfMovement.Odd:
                            Odd();
                            break;
                    }
                }
            }
            chronometer = Time.time + timeToSleep;
        }

    }
    private void Odd()
    {
        if (!turnedOn)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (i % 2 == 0)
                    walls[i].wallState = WallState.Up;
                else
                    walls[i].wallState = WallState.Down;
            }
            turnedOn = true;
        }
        else
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (i % 2 == 0)
                    walls[i].wallState = WallState.Down;
                else
                    walls[i].wallState = WallState.Up;
            }
            turnedOn = false;
        }

    }
    private void Pair()
    {
        if (!turnedOn)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (i % 2 == 0)
                    walls[i].wallState = WallState.Down;
                else
                    walls[i].wallState = WallState.Up;
            }
            turnedOn = true;
        }
        else
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (i % 2 == 0)
                    walls[i].wallState = WallState.Up;
                else
                    walls[i].wallState = WallState.Down;
            }
            turnedOn = false;
        }

    }
}


