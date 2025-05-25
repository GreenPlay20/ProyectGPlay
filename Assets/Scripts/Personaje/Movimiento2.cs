using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movimiento2 : MonoBehaviour
{
    [SerializeField] private float velMov = 5f;
    [SerializeField] private float velRot = 5f;

    [SerializeField] private PlayerInput inputAct;
    [SerializeField] private Vector2 inputVector = new Vector2(0, 0);

    [Header("camaraBase")]
    [SerializeField] private GameObject camBase;
    [SerializeField] private Transform transforCam;
    [SerializeField] private Vector3 vecCam = new Vector3(0f, 0f, 0f);

    private CharacterController chrControl;
    // Start is called before the first frame update
    void Start()
    {
        chrControl = GetComponent<CharacterController>();
        inputAct = GetComponent<PlayerInput>();
        transforCam = camBase.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //toma los valores del vector de entrada en (x,y) normalizados
        inputVector = inputAct.actions["Moverse"].ReadValue<Vector2>();
        //se crea un vector para rotar en la direccion de esos vectores
        Vector3 rot = new Vector3(inputVector.x, 0f, inputVector.y);       
        
        Vector3 mov = new Vector3(inputVector.x, 0f, inputVector.y)*-1;

        //agregando direccion de la camara
        vecCam = new Vector3(transforCam.forward.x-transform.position.x, 0f,
            transforCam.forward.z-transform.position.z);
        if (inputVector.x!=0||inputVector.y!=0)
        {
            vecCam = vecCam * -1;
        }else
        {
            vecCam = vecCam * 0;
        }
        mov = mov + vecCam;
        mov = mov.normalized;

        //se independiza del numero de frames los vectores de entrada y se
        //multiplica por una velocidad dada
        //inputVector = inputVector * Time.deltaTime * velMov;
        mov = mov * Time.deltaTime * velMov;

        //se le brinda al controlador el vector a moverse desde la posicion base del
        //mundo (coordenadas locales) y el se mueve alli
        chrControl.Move(mov);

        transform.forward = Vector3.Slerp(transform.forward, mov, Time.deltaTime * velRot);
        /*Debug.Log("grado rotacion: "+transform.rotation.eulerAngles+" apunta forward: "+
            transform.forward*-1);
    */
    }
    
}
