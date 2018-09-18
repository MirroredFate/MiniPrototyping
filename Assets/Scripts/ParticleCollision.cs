using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour {

    ParticleSystem pS;
    GameManager gM;
  
    public List<ParticleCollisionEvent> collEvents;

    private void Awake()
    {
        pS = GetComponent<ParticleSystem>();
        gM = FindObjectOfType<GameManager>();

        collEvents = new List<ParticleCollisionEvent>(); 
    }

    private void OnParticleCollision(GameObject other)
    {
        int numCollEvents = pS.GetCollisionEvents(other, collEvents);

        if (other.gameObject.tag != "Gras")
        {
            for (int b = 0; b < numCollEvents; b++)
            {
                Vector3 pos = collEvents[b].intersection;
                gM.GetGrassQuad(pos, Quaternion.Euler(90f, 0f, 0f));
            }

        }
        else
        {
            Debug.Log("hit gras");
        }

    }
}
