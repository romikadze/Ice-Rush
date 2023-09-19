using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameEnded;
    [SerializeField]
    CameraController cameraController;
    public static GameManager gameManager;

    void Start()
    {
        gameManager = this;
    }

    public void Win()
    {
        cameraController.FinishReached();
        isGameEnded = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
