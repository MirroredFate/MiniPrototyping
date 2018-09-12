using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehaviour : MonoBehaviour {

    [SerializeField] Renderer rend;
    Color init;
    float r = 0;
    float b = 0;
    float duration = 5f;
    float t = 0f;

    private void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
        init = rend.material.color;
        Debug.Log(init);
       
       
    } 
    private void FixedUpdate()
    {
        StartCoroutine(Life());

    }
    IEnumerator Life()
    {
        if(rend.material.color != Color.green) { 

        rend.material.color = Color.Lerp(init,Color.green,t);
        }
        if(t < 1)
        {
            t += Time.deltaTime / duration;
        }
        yield return new WaitForSeconds(2f);
    }
}
