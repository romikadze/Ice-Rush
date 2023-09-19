using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject iceCube;
    float timer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.isGameEnded)
        {
            transform.Translate(Vector3.right / 80);
            transform.LookAt(iceCube.transform);
            return;
        }

        transform.position = iceCube.transform.position + new Vector3(0, 2, -2);
    }

    public void FinishReached()
    {
        transform.Translate(Vector3.back);
    }
}
