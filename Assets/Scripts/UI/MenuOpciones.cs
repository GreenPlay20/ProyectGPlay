using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuOpciones
{
    [SerializeField] private static bool isPaused = false;


   public static void Awake()
    {
        Time.timeScale = 1f;
    }
   public static void SiPausar()
    {
        if(isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
    public static void SalirInicio()
    {
        LoadScene.Cargar(LoadScene.Scene.Inicio);
        Time.timeScale = 1f;
    }
}
