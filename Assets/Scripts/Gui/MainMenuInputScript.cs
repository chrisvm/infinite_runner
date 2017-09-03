
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInputScript : MonoBehaviour {

    public GameObject startButton;
    public string GameSceneName;

    private void OnMouseDown()
    {
        if (this.tag.Equals(startButton.tag))
        {
            SceneManager.LoadScene(GameSceneName);
        }
    }

}
