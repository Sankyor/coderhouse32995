using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] private Transform slimeTransform;
    [SerializeField] private MovementStates movementStates;
    [SerializeField] private Animator slimeAnimator;
    [SerializeField] private float pursuitDistance;
    [SerializeField] private float pursuitMax;
    [SerializeField] private float speed;
    private static readonly int Speed = Animator.StringToHash("Speed");
    [SerializeField] private float life;
    [SerializeField] private float lifeMax;
    [SerializeField] private LayerMask playerLayer;
    private Transform player;

    void Update()
    {
        //LookAtPlayer();
        SetCurrentState();

    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        var vectorToLook = player.position - transform.position;
        var newRotation = Quaternion.LookRotation(vectorToLook);
        transform.rotation = newRotation;
        /*Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = newRotation;*/
    }
    private void MoveTowardsPlayer()
    {
        var vectorToPlayer = player.position - transform.position;
        var distance = vectorToPlayer.magnitude;

        if (distance > pursuitMax)
        {
            movementStates = MovementStates.Idle;
        }
        else if (distance > pursuitDistance)
        {
            // Raycast to check if the player is visible
            RaycastHit hit;
            Vector3 direction = player.position - slimeTransform.position;
            var l_hasCollided = Physics.SphereCast(slimeTransform.position,life,direction.normalized, out hit, pursuitMax, playerLayer);
            if (l_hasCollided)
            {
                
                if (hit.collider.CompareTag("Player"))
                {
                    // Move towards the player
                    Debug.DrawRay(transform.position, direction, Color.red);
                    transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                    slimeAnimator.SetFloat(Speed, direction.magnitude);
                }

            }
            
        else movementStates = MovementStates.Idle;
       }
        else movementStates = MovementStates.Idle;

        //transform.position += Vector3.MoveTowards(transform.position,playerTransform.position, Time.deltaTime* speed);
    }
    private void ExecuteIdle()
    {
        var vectorToPlayer = player.position - transform.position;
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
