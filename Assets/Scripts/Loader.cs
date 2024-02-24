using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        MainMenuScene,
        GameScene,
        LoadingScene,
        CurrentScene,
        Map1,
        Map2,
    }


    public static void Load(Scene targetScene)
    {
        if (targetScene == Scene.CurrentScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }
        SceneManager.LoadScene(targetScene.ToString());

    }

}
