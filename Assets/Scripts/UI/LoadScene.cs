using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadScene { 
    // Start is called before the first frame update
    public enum Scene
    {
        Inicio,
        LoadStage,
        Nivel1
    }
    private static Scene EscenaCargar;
    public static void Cargar(Scene EscenaA)
    {
        LoadScene.EscenaCargar = EscenaA;
        if (EscenaCargar.Equals(LoadScene.Scene.Inicio))
        {
            SceneManager.LoadScene(EscenaCargar.ToString());
            return;
        }
        SceneManager.LoadScene(Scene.LoadStage.ToString());
        
        
    }
    public static void LoaderCallback()
    {
        SceneManager.LoadScene(EscenaCargar.ToString());
    }
}
