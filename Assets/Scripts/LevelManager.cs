using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static void LoadLevel(int levelIndex){
        SceneManager.LoadScene(levelIndex);
    }

    public static void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
