using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayBtn()
    {
        Loader.Load(Loader.Scene.Map1);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
