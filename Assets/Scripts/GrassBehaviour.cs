using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehaviour : MonoBehaviour
{
    #region Fields
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private GameManager gM;
    private ParticleCollision pC;

    [SerializeField] Gradient color;

    private bool done = false;
    private int donecounter = 0;

    private Vector3 offsetX;
    private Vector3 offsetZ;
    private float randomizer;
    #endregion

    private void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
        gM = FindObjectOfType<GameManager>();

        pC= FindObjectOfType<ParticleCollision>();
        randomizer = Random.Range(-3f, 3f);

        StartCoroutine(Hi(10f));
        
    }
    

    IEnumerator Hi(float duration)
    {
        
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            _propBlock.SetColor("_Color", color.Evaluate(t / duration));
            _renderer.SetPropertyBlock(_propBlock);
            yield return new WaitForEndOfFrame();
        }
        donecounter++;
        Populate();
        Done();
        yield break;
    }


    Vector3 IntersectionX()
    {
        
        if (pC.collEvents.Count == 0)
        {
            offsetX = new Vector3(transform.position.x + 2.2f, transform.position.y, transform.position.z);
         
        }
        else 
        {
            offsetX = pC.collEvents[0].intersection;
            offsetX = new Vector3(offsetX.x + 2.2f, offsetX.y, offsetX.z);
            pC.collEvents.RemoveAt(0);
           
        }
       
        return offsetX;
    }

    
    Vector3 IntersectionZ()
    {
    
        if (pC.collEvents.Count == 0)
        {
            offsetZ = new Vector3(transform.position.x, transform.position.y, transform.position.z +2.2f);

        }
        else 
        {

            offsetZ = pC.collEvents[0].intersection;
            offsetZ = new Vector3(offsetZ.x, offsetZ.y, offsetZ.z + 2.2f);
            pC.collEvents.RemoveAt(0);
        }

        return  offsetZ;
    }
    
    void Populate()
    {
        
        if (!done)
        {
            if(randomizer <= 0f)
            {
            IntersectionX();
            gM.GetGrassQuad(offsetX, Quaternion.Euler(90f, 0f, 0f));

            } else if(randomizer > 0f)
            {
            IntersectionZ();
            gM.GetGrassQuad(offsetZ, Quaternion.Euler(90f, 0f, 0f));

            }
        }
    }

     bool Done()
    {
        if(donecounter == 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
