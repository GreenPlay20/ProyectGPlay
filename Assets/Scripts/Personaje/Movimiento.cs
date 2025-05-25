using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Movimiento : MonoBehaviour
{

    // Start is called before the first frame update
    [Header("Movimiento horizontal")]
    [Tooltip("velocidad de movimiento")]
    [SerializeField] private float velMovimiento = 7f;

    [Header("Movimiento vertical")]
    [Tooltip("velocidad de salto")]
    [SerializeField] private float jumpSpeed = 20.0f;
    [SerializeField] private float gravity= -9.8f;
    [SerializeField] private float terminalVelocity= -10.0f;
    [SerializeField] private float minFall = -1.5f;
    [Tooltip("Velocidad vertical")]
    [SerializeField] private float vertSpeed;

    [Header("Entrada")]
    [SerializeField] private PlayerInput InputAct;
    [SerializeField] private Vector2 inputVector = new Vector2(0, 0);

    private CharacterController charController;
   
   
    void Start()
    {
        charController = GetComponent<CharacterController>();
        vertSpeed = minFall;
        InputAct = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }
        */
        inputVector = InputAct.actions["Moverse"].ReadValue<Vector2>();
        inputVector=inputVector.normalized;
         
        if(charController.isGrounded)
        {
            //if(Input.GetKeyDown(KeyCode.Space))
            if (InputAct.actions["Saltar"].WasPressedThisFrame())
            {
                vertSpeed = jumpSpeed;
            }
            else
            {
                vertSpeed = minFall;
            }
        }
        else
        {
            vertSpeed += gravity * 5 * Time.deltaTime;
            if (vertSpeed < terminalVelocity)
            {
                vertSpeed = terminalVelocity;
            }
        }

        Vector3 pos = new Vector3(inputVector.y*velMovimiento*-1, vertSpeed, inputVector.x * velMovimiento);
        //transform.position += pos * Time.deltaTime * velMovimiento;
        charController.Move(pos * Time.deltaTime );
        float velocidadRot = 5f;
        Vector3 rot = new Vector3(inputVector.y*-1, 0, inputVector.x);
        transform.forward = Vector3.Slerp(transform.forward, rot , Time.deltaTime * velocidadRot);
        //para pausar
        if(InputAct.actions["EstaPausado"].WasPressedThisFrame())
        {
            MenuOpciones.SiPausar();
        }
    }
}
