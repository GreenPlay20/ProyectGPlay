using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    [SerializeField] private bool isLoading=true;
    // Update is called once per frame
    void Update()
    {
        if (isLoading)
        {
            isLoading = false;
            LoadScene.LoaderCallback();
        }
    }
}
