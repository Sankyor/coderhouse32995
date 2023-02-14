using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallState
{
    DoNothing,
    Up,
    Down
}
public class WallController : MonoBehaviour

{
    private float up = 1.027351f;//1.027351
    private float down = -1.88f;
    //[SerializeField] private Component component;
    //[SerializeField] private GameObject gameObject;
    [SerializeField] public WallState wallState;
    [SerializeField] private float speed = 1;
    private Vector3 upPosition;
    private Vector3 downPosition;

    private float journeyLength;
    private void Start()
    {
        upPosition = (new Vector3(transform.position.x, up, transform.position.z));
        downPosition = (new Vector3(transform.position.x, down, transform.position.z));

        journeyLength = Vector3.Distance(upPosition, downPosition);
    }

    private void Update()
    {
        switch (wallState)
        {
            case WallState.Up:
                if ((float)transform.position.y <= up)
                {
                    var startTime = Time.time;
                    float distCovered = (Time.time - startTime) * speed;
                    float fracJourney = distCovered / journeyLength;
                    transform.position = Vector3.Lerp(transform.position, upPosition, speed*Time.deltaTime);
                    
                }
                //wallState = WallState.DoNothing;
                break;
            case WallState.Down:
                if ((float)transform.position.y >= down)
                {
                    var startTime = Time.time;
                    float distCovered = (Time.time - startTime) * speed;
                    float fracJourney = distCovered / journeyLength;
                    transform.position = Vector3.Lerp(transform.position, downPosition, speed*Time.deltaTime);
                    
                }
                //wallState = WallState.DoNothing;
                break;
            case WallState.DoNothing:
                break;
            

        }
    }

    //public void GetDown()
    //{
     //   if ((float)transform.position.y >= down)
      //  {
       //     var startTime = Time.time;
        //    float distCovered = (Time.time - startTime) * speed;
         //   float fracJourney = distCovered / journeyLength;
          //  transform.position = Vector3.Lerp(upPosition, downPosition, speed);
            //gameObject.SetActive(false);
            //Collider collider = component.GetComponent<Collider>();
            //collider.enabled = false;
            //transform.position = new Vector3(transform.position.x, down, transform.position.z);
        //}
            
        
    //}
    //public void GetUp()
    //{
        
        
        //if ((float)transform.position.y <= up)
        //{
          //  var startTime = Time.time;
            //float distCovered = (Time.time - startTime) * speed;
            //float fracJourney = distCovered / journeyLength;
            //transform.position = Vector3.Lerp(upPosition, downPosition, speed);
            //gameObject.SetActive(true);
            //Collider collider = component.GetComponent<Collider>();
            //transform.position = new Vector3(transform.position.x, up, transform.position.z);
            //collider.enabled = true;
      //  }
            
        //
    //}
}
