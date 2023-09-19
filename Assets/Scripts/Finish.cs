using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    GameObject camera;
    [SerializeField]
    ParticleSystem finishParticles;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(Instantiate(finishParticles, transform.position, transform.rotation), 7);
            GameManager.gameManager.Win();
        }
    }
}
