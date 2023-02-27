using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cursor = UnityEngine.Cursor;
using Cinemachine;

public class PlayerController13: MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator playerAnimator;
    private static readonly int Speed = Animator.StringToHash("Speed");
    [SerializeField] private CinemachineVirtualCamera m_camera;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float life;
    [SerializeField] private float lifeMax;
    [SerializeField] private KeyCode keyCamera;
    [SerializeField] private Camera camera2;
    [SerializeField] private Camera camera1;

    private void Awake()
    {
        GameManager.Instance.SetPlayerController(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(camera1.isActiveAndEnabled)
        {
            Move(GetMovementInput(1f));
        }
        else if(camera2.isActiveAndEnabled)
        {
            Move(GetMovementInput(-1f));
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
        //Rotate(GetRotationInput());
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.None : CursorLockMode.Confined;
    }
    private void Rotate(Vector2 p_scrollDelta)
    {
        //transform.Rotate(Vector3.up, p_scrollDelta.x * rotationSpeed * Time.deltaTime, Space.Self);
    }

    private Vector2 GetRotationInput()
    {
        // var l_mouseX = Input.GetAxis("Mouse X");
        // var l_mouseY = Input.GetAxis("Mouse Y");
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");
        return new Vector2(l_horizontal, l_vertical);
    }
    private Vector3 GetMovementInput(float invert)
    {
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");
        return new Vector3(l_horizontal, 0, l_vertical).normalized*invert;
    }
    private void Move(Vector3 p_inputMovement)
    {
        //Vector3 movement = new Vector3(horizontal, 0, vertical);
        

        // transform1.position += (p_inputMovement.z * transform1.forward + p_inputMovement.x * transform1.right) *
        //                      (speed * Time.deltaTime);
        var transform1 = transform.position;
        transform.position += p_inputMovement * (speed * Time.deltaTime);
        if(transform.position != transform1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(p_inputMovement), Time.deltaTime * speed);
        }
        playerAnimator.SetFloat(Speed, p_inputMovement.magnitude);
    }
    public void TakeDamage(float damageTaken)
    {
        life -= damageTaken;
        if (life <= 0)
        { 
            life = 0;
            Debug.Log("You died");
        
        }

    }
    public void HealLife(float healTaken)
    {
        life += healTaken;
        if(life >= lifeMax)
        {
            life = lifeMax;
        }
    }
    private void TurnOnCamera(Camera camToTurnOn, Camera otherCamera)
    {
        camToTurnOn.gameObject.SetActive(true);
        otherCamera.gameObject.SetActive(false);
    }
}
