using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    public string GameScreen;

    public float GameOverTextVerticalCoord = 250;

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 40, GameOverTextVerticalCoord, 70, 50), "Game Over");
        if(GUI.Button(new Rect(Screen.width/2-30,350,60,30), "Retry"))
        {
            SceneManager.LoadScene(GameScreen);
        }
    }

}
