using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectorToque : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Touchscreen.current.primaryTouch.press.isPressed )
        { return;
        }
        Vector2 posicionToque = Touchscreen.current.primaryTouch.position.ReadValue();
        Debug.Log(posicionToque);
    }
}
