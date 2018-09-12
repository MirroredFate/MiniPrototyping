using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehaviour : MonoBehaviour {

    [SerializeField] Renderer rend;
    Color init;
    float r = 0;
    float b = 0;
    float duration = 10f;
    float t = 0f;
    float tt = 0f;
    bool once = true;

    private void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
        init = rend.material.color;
        Debug.Log(init);
        

    } 
    private void FixedUpdate()
    {
        StartCoroutine(Cycle());
         
        
    }
    IEnumerator Cycle()
    {
        StartCoroutine(Life());
        if (once)
        {
            StopCoroutine(Life());
            StartCoroutine(Death());
        }

        yield return new WaitForSeconds(1f);
    }
    IEnumerator Life()
    {
        if(rend.material.color != Color.green) { 

        rend.material.color = Color.Lerp(init,Color.green,t);
           
        }
        else
        {
            print("it happened");
            StopCoroutine(Life());
            once = false;
            StartCoroutine(Death());
        }
        if(t < 1)
        {
            t += Time.deltaTime / duration;
        }
        yield return new WaitForSeconds(duration);
    }

    IEnumerator Death()
    {
        if (rend.material.color != Color.black)
        {
            rend.material.color = Color.Lerp(Color.green, Color.black, tt);
            
        }
        else
        {
            print("death happened");
            StopCoroutine(Death());
        }
        if (tt < 1)
        {
            tt += Time.deltaTime / duration;
        }
        
        yield return new WaitForSeconds(duration);
    }
}
