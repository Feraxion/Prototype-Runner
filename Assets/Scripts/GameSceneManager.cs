using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneManager {

    public enum Scene {
        MainMenuS,
        Level1,
        Level2,
        Level3,
        Level4

    }

    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }

}