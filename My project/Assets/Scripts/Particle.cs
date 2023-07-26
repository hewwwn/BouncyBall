using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }
    
    void Update()
    {
        if (particle.isPlaying == false)
        {
            gameObject.SetActive(false);
        }
    }
}
