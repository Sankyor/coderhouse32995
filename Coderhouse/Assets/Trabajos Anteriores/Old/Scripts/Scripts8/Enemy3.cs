using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CaseStates
{
    Look,
    Follow
}
public class Enemy3 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private MovementStates movementStates;
    [SerializeField] private CaseStates caseStates;
    [SerializeField] private float pursuitDistance;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        SetCurrentAction();


    }
    private void SetCurrentAction()
    {
        switch (caseStates)
        {
            case CaseStates.Look:
                LookAtPlayer();
                break;
            case CaseStates.Follow:
                LookAtPlayer();
                SetCurrentState();
                break;
            default:
                Debug.LogError("current state is invalid");
                break;
        }
    }
    private void SetCurrentState()
    {
        switch (movementStates)
        {
            case MovementStates.Idle:
                ExecuteIdle();
                break;
            case MovementStates.Run:
                MoveTowardsPlayer();
                break;
            default:
                Debug.LogError("current state is invalid");
                break;
        }
    }
    private void LookAtPlayer()
    {
        var vectorToLook = playerTransform.position - transform.position;
        var newRotation = Quaternion.LookRotation(vectorToLook);
        transform.rotation = newRotation;
        /*Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = newRotation;*/
    }
    private void MoveTowardsPlayer()
    {
        var vectorToPlayer = playerTransform.position - transform.position;
        var distance = vectorToPlayer.magnitude;

        if (distance > pursuitDistance)
        {
            transform.position += (playerTransform.position - transform.position).normalized * Time.deltaTime;
        }
        else movementStates = MovementStates.Idle;

        //transform.position += Vector3.MoveTowards(transform.position,playerTransform.position, Time.deltaTime* speed);
    }
    private void ExecuteIdle()
    {
        Debug.Log("Idlee state");
        var vectorToPlayer = playerTransform.position - transform.position;
        var distance = vectorToPlayer.magnitude;

        if (distance > pursuitDistance)
        {
            movementStates = MovementStates.Run;
        }
    }
}
