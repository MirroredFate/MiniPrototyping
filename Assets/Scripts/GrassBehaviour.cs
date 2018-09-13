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

    public Color Color1 = Color.yellow, Color2 = Color.green;
    public float speed = 1f;
    public float offset;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    Color hey;

    private void Awake()
    {
        //rend = gameObject.GetComponent<Renderer>();
        

        // Debug.Log(init);
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        init = new Color();
        init = _renderer.material.color;
        init.r = 0f;
        init.g = 1f;
        init.b = 0.068f;
        init.a = 0f;

        offset = Random.Range(1, 5);

        hey = _propBlock.GetColor("_Color");
        Debug.Log(_propBlock.GetColor("_Color"));
    } 
    private void FixedUpdate()
    {
        //StartCoroutine(Cycle());
        StartCoroutine(Hi());
        
    }
    private void Update()
    {
       
    }

    IEnumerator Hi()
    {
        

        if(_propBlock.GetColor("_Color") != init)
        {
            Debug.Log("hey");
            _renderer.GetPropertyBlock(_propBlock);
            _propBlock.SetColor("_Color", Color.Lerp(Color1, Color2, t));
           _renderer.SetPropertyBlock(_propBlock);
          
        }
        else
        {
            print("hey");
        }
        
       // Debug.Log(t);
        if (t <= 1)
        {

        t += Time.deltaTime / duration;
        }
        else {
            t = 0;
        }
        yield return new WaitForSeconds(duration);
    }
    /* IEnumerator Cycle()
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
     }*/
}
