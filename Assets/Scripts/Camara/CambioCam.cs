using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CambioCam : MonoBehaviour
{
    [SerializeField] private GameObject personaje;
    [SerializeField] private CinemachineVirtualCamera camA;
    [SerializeField] private CinemachineVirtualCamera camB;
    [SerializeField] private bool isFollowCamB=false;
    [SerializeField] private float prioCambio = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("en contacto");
        if(!isFollowCamB)
        {
            prioCambio = camB.Priority;
            camB.Priority = camA.Priority; 
            camB.MoveToTopOfPrioritySubqueue();
            camA.Priority = (int)prioCambio;
            isFollowCamB = true;
            this.gameObject.SetActive(false);
        }
        else
        {
            camA.MoveToTopOfPrioritySubqueue();
            isFollowCamB = false;
        }
    }
}
