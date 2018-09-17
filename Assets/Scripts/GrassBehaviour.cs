using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehaviour : MonoBehaviour
{

    [SerializeField] Renderer rend;

    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;

    GameManager gM;

    [SerializeField] Gradient color;
    bool done = false;
    Vector3 offsetX;

    Vector3 offsetZ;


    ParticleCollision pC;
   

    private void Awake()
    {
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
        gM = FindObjectOfType<GameManager>();

        pC= FindObjectOfType<ParticleCollision>();
        
       
        StartCoroutine(Hi(10f));
        
    }
    

    IEnumerator Hi(float duration)
    {
        done = false;
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            _propBlock.SetColor("_Color", color.Evaluate(t / duration));
            _renderer.SetPropertyBlock(_propBlock);
            yield return new WaitForEndOfFrame();
        }
        
        Populate();
        done = true;
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
            IntersectionX();
            IntersectionZ();
            gM.GetGrassQuad(offsetX, Quaternion.Euler(90f, 0f, 0f));
            gM.GetGrassQuad(offsetZ, Quaternion.Euler(90f, 0f, 0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }


    private void OnTriggerStay(Collider other)
    {
        // Debug.Log("hey");
        // Debug.Log(other.GetComponent<Collider>());
      
        if (other.gameObject.name == "Grass(Clone)")
        {
            Destroy(other.gameObject);
            //float randomizer = (int)Random.Range(0f,2f);
            //Debug.Log(randomizer);
            //if(randomizer == 1f)
            //{
            //    Debug.Log("hey");
            //    transform.position += new Vector3((int)Random.Range(-1.03f, 1.03f), 0f, 0f);
            //} else if (randomizer == 0f)
            //{
            //    transform.position += new Vector3(0f, 0f, (int)Random.Range(-1.03f, 1.03f));
            //}

            // transform.position += new Vector3((int)Random.Range(-2f, 2f), 0f, (int)Random.Range(-2f, 2f));
            //Debug.Log("hey");
            //Vector3 i = this.transform.position;
            //GameObject h = other.gameObject.;
            //Vector3 b = other.gameObject.transform.position;
            //b += new Vector3(Random.Range(-2.03f, 2.03f), 0f, Random.Range(-1.03f, 1.03f));
        }
    }
}
