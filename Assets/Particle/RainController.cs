using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour {

    ParticleSystem pS;
    ParticleSystem.EmissionModule pSE;
    


    private void Awake()
    {
        pS = GetComponentInChildren<ParticleSystem>();
        pS.Pause();
        pSE = pS.emission;
        
    }

    private void Update()
    {
   
        if (Input.GetKey(KeyCode.R))
        {
            pSE.rateOverTime = 10;
            pS.Play();
        }
        else
        {
            pSE.rateOverTime = 0;
        }
        

        
    }
}
