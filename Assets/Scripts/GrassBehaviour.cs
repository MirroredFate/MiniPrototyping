using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehaviour : MonoBehaviour {

    [SerializeField] Renderer rend;
    Color init;
    //float t = 0f;
    bool done = false;
    bool donee = false;

    public Color Color1 = Color.yellow, Color2 = Color.green;
    public float speed = 1f;
    public float offset;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    Color hey;

    [SerializeField] Gradient color;

    private void Awake()
    {
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
        yield break;   
    }
  
}
