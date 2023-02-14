using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private MovementStates movementStates;
    [SerializeField] private Animator slimeAnimator;
    [SerializeField] private float pursuitDistance;
    [SerializeField] private float pursuitMax;
    [SerializeField] private float speed;
    private static readonly int Speed = Animator.StringToHash("Speed");
    [SerializeField] private float life;
    [SerializeField] private float lifeMax;

    void Update()
    {
        LookAtPlayer();
        SetCurrentState();

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

        if (distance > pursuitMax)
        {
            movementStates = MovementStates.Idle;
        }
        else if (distance > pursuitDistance)
        {
            var movement = (playerTransform.position - transform.position).normalized;
            transform.position += movement * Time.deltaTime;
            slimeAnimator.SetFloat(Speed, movement.magnitude);
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
    public void TakeDamage(float damageTaken)
    {
        life -= damageTaken;
        if (life <= 0)
        {
            life = 0;

        }

    }
    public void HealLife(float healTaken)
    {
        life += healTaken;
        if (life >= lifeMax)
        {
            life = lifeMax;
        }
    }
}
