using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        MainMenu,
        GameScene,
        Loading,
        CurrentScene,
        Map1,
        Map2,
    }

    private static Scene targetScene;

    public static void Load(Scene targetScene)
    {
        if (targetScene == Scene.CurrentScene)
        {
            Enum.TryParse<Scene>(SceneManager.GetActiveScene().name, out targetScene);
        }

        Loader.targetScene=targetScene;

        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void LoaderCallback()
    {
       
        SceneManager.LoadScene(targetScene.ToString());
    }

}
