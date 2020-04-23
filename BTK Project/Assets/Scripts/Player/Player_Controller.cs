using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public GameObject Player_Cameras; 
    // Переменные под мышь
    private float x_Rot; 
    private float y_Rot; 

    public float Sensa = 5f; 
    public float smoothT = 0.1f; 

    private float XRotation; 
    private float YRotation; 
    
    private float xRotVelocity; 
    private float yRotVelocity;
    // Переменные пок клавиатуру
    public float speed = 10f;
    public float gravity = -10f;

    public float _jump_pow = 10f;
    private float _jump = 0;


    private CharacterController _Ch;

    void Start()
    {
        _Ch = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        
        // Управление камерой(мышь) 
        x_Rot -= Input.GetAxis("Mouse Y") * Sensa;
        y_Rot += Input.GetAxis("Mouse X") * Sensa;

        x_Rot = Mathf.Clamp(x_Rot, -90, 90);

        XRotation = Mathf.SmoothDamp(XRotation, x_Rot, ref xRotVelocity, smoothT);
        YRotation = Mathf.SmoothDamp(YRotation, y_Rot, ref yRotVelocity, smoothT);

        Player_Cameras.transform.rotation = Quaternion.Euler(XRotation, YRotation, 0);
        transform.rotation = Quaternion.Euler(0, YRotation, 0);
        // ------------------------------------------------------------------------------------

        // Управление персонажем (клава)
        float x_Mov = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z_Mov = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (_Ch.isGrounded)
        {
            _jump = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jump = _jump_pow;
            }
        }
        _jump += gravity * Time.deltaTime * 3; 

        Vector3 move = new Vector3(x_Mov, _jump * Time.deltaTime, z_Mov);
        move = Vector3.ClampMagnitude(move, speed);

        move = transform.TransformDirection(move);
        _Ch.Move(move);
        //---------------------------------------------------------------------------------------
        


    }
}
