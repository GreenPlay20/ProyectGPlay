using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 puntoContacto;
    [SerializeField] private float velEmpuje=20f;
    [SerializeField] private float velVistaMov = 1f;
    [SerializeField] private Vector3 RestaVector;

    [SerializeField] private Vector3 RestaVectorXZ;
    [SerializeField] private bool isContacted=false;
    [SerializeField] private Rigidbody ObjRigid;

    void Start()
    {
        puntoContacto = transform.position;
        ObjRigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isContacted)
        {
            transform.position =
               Vector3.Lerp(transform.position, transform.position+
               RestaVectorXZ.normalized  ,velEmpuje * Time.deltaTime);
            isContacted = false;
        }
        */
    }
    private void FixedUpdate()
    {
        if (isContacted)
        {
            ObjRigid.MovePosition(transform.position + RestaVectorXZ.normalized 
                * velEmpuje * Time.fixedDeltaTime);
            /*ObjRigid.MovePosition(RestaVectorXZ.normalized
                * velEmpuje * Time.fixedDeltaTime);*/ 
            isContacted = false;
            Debug.Log("se mueve?: "+ transform.position + RestaVectorXZ.normalized
                * velEmpuje * Time.fixedDeltaTime);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoContacto, 0.2f);
        Gizmos.color = Color.red;        
        Gizmos.DrawCube(transform.position+RestaVector*2,new Vector3(0.5f, 0.5f, 0.5f));
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position + RestaVectorXZ * 2, new Vector3(0.5f, 0.5f, 0.5f));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(7))
        {
            //Debug.Log("en contacto");

            isContacted = true;
            puntoContacto = collision.GetContact(0).point;
            Debug.DrawLine(puntoContacto, transform.position, Color.green, 1f);
            Debug.DrawLine(new Vector3(puntoContacto.x, transform.position.y, puntoContacto.z),
                transform.position, Color.magenta, 1f);
            RestaVector = new Vector3(transform.position.x - puntoContacto.x,
                transform.position.y - puntoContacto.y, transform.position.z - puntoContacto.z
                );
            RestaVectorXZ = new Vector3(transform.position.x - puntoContacto.x,
                0f, transform.position.z - puntoContacto.z
                );
            Debug.DrawRay(transform.position, RestaVector, Color.black, 2f);
            Debug.DrawRay(transform.position, RestaVectorXZ, Color.cyan, 2f);
        }
    }
}
