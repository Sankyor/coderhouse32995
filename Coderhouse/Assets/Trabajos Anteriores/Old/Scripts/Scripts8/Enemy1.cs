using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }
    private void LookAtPlayer()
    {
        var vectorToLook = playerTransform.position - transform.position;
        var newRotation = Quaternion.LookRotation(vectorToLook);
        transform.rotation = Quaternion.Lerp(transform.rotation,newRotation,Time.deltaTime);
        /*Quaternion newRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = newRotation;*/
    }
}
