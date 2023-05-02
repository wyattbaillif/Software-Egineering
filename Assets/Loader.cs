using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public static class Loader
{
    private static Scene targetScene2;
    public enum Scene {
        MainMenu,
        Lobby,
        WaitingScene,
        Game
    }

    public static void LoadNetwork(Scene targetScene){
        NetworkManager.Singleton.SceneManager.LoadScene(targetScene.ToString(),LoadSceneMode.Single);
    }

    public static void Load(Scene targetScene){
        Loader.targetScene2 = targetScene;
        SceneManager.LoadScene(targetScene.ToString());
    }
}
