using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour {

    ParticleSystem pS;
    ParticleSystem.EmissionModule pSE;
    MeshFilter mF;

    [SerializeField]Mesh angryMesh, normalMesh;

    private void Awake()
    {
        pS = GetComponentInChildren<ParticleSystem>();
        pS.Pause();

        pSE = pS.emission;
        mF = GetComponent<MeshFilter>();

    }

    private void Update()
    {
   
        if (Input.GetKey(KeyCode.R))
        {
            pSE.rateOverTime = 10;
            mF.mesh = angryMesh;
            pS.Play();
        }
        else
        {
            mF.mesh = normalMesh;
            pSE.rateOverTime = 0;
        }

    }

}
