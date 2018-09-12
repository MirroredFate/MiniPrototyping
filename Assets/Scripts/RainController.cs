using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour {

    ParticleSystem pS;
    ParticleSystem.EmissionModule pSE;
    [SerializeField] GameObject grass;

    List<ParticleCollisionEvent> collEvents;

    private void Awake()
    {
        pS = GetComponentInChildren<ParticleSystem>();
        pS.Pause();
        pSE = pS.emission;

        collEvents = new List<ParticleCollisionEvent>();
        
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

   /* private void OnParticleCollision(GameObject other)
    {
        Debug.Log("it happened");

        int numCollEvents = pS.GetCollisionEvents(other, collEvents);
            
        for (int b = 0; b < numCollEvents; b++)
        {
                Vector3 pos = collEvents[b].intersection;
                Debug.Log(collEvents[b].intersection);
                Debug.Log(pos);
        }
           
    } */
}
