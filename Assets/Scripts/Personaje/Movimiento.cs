using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private float velMovimiento = 7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = new Vector2(0,0);
        if (Input.GetKey(KeyCode.W)) {
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
        inputVector=inputVector.normalized;
        Vector3 pos = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += pos * Time.deltaTime * velMovimiento;
        float velocidadRot = 5f;
        transform.forward = Vector3.Slerp(transform.forward, pos, Time.deltaTime*velocidadRot);
        
    }
}
