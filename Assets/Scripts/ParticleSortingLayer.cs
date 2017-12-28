using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSortingLayer : MonoBehaviour {

    private string layerName = "Player";

    void Start()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = layerName;
    }
}
