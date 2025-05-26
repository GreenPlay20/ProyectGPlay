using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isRunning = false;
    [SerializeField] private bool isAttack = false;
    [SerializeField] private Animator AnimatorChin;
    void Start()
    {
        AnimatorChin = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning)
        {
            AnimatorChin.SetBool("run",true);
        }
        if (isAttack)
        {
            AnimatorChin.SetBool("atq", true);
        }
    }
}
