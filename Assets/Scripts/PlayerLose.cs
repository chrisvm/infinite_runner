using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour {

    public string GameOverSceneName;
    public Transform CameraToFollow;
    private Transform _playerLoseArea;

    private void Start()
    {
        _playerLoseArea = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        _playerLoseArea.position = new Vector3(CameraToFollow.position.x,-30);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(GameOverSceneName);
    }
}
