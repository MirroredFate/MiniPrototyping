using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Fields
    public Stack<GameObject> grassStack;
    [SerializeField] Transform tP;
    [SerializeField]GameObject grass;
    [SerializeField] int grassStackCount = 2000;
    #endregion

    private void Awake()
    {
        grassStack = new Stack<GameObject>();

        for (int i = 1; i <= grassStackCount; i++)
        {
            GameObject newGrassQuad = Instantiate(grass, transform.position, Quaternion.Euler(Vector3.zero), tP);
            newGrassQuad.SetActive(false);
            grassStack.Push(newGrassQuad);

        }
        
    }

    public GameObject GetGrassQuad(Vector3 pos, Quaternion quat)
    {
        if(grassStack.Count > 0)
        {
        GameObject grass = grassStack.Pop();
        grass.SetActive(true);
        grass.transform.position = pos;
        grass.transform.rotation = quat;
        return grass;

        }
        else
        {
            return null;
        }
    } 


}
