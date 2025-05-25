using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizacion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool takeForward = false;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (takeForward)
        {
            Debug.Log(transform.forward-transform.position);
            takeForward = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(
            transform.forward.x,0f, transform.forward.z));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(
            transform.forward.x , 0f, transform.forward.z) * -1);
    }
}
