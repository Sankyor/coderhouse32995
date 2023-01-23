using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float damage;
    [SerializeField] private float lifetime;
    void Start()
    {
        lifetime += Time.time;
    }
    // Update is called once per frame 
    void Update()
    {
        Move();
        if (lifetime <= Time.time)
        {
            Destroy(gameObject); 
        }
    }
    private void Move()
    {
        if (direction.x != 0 || direction.z != 0)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}



