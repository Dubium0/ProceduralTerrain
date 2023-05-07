using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_ : MonoBehaviour
{

    [SerializeField,Range(4,256)]
    int mapResolution;

    [SerializeField,Min(1)]

    int octave;

    [SerializeField]

    float lacunarity;

    [SerializeField, Range(0f,1f)]

    float persistance;

    [SerializeField,Min(float.MinValue)]

    float scale;

    [SerializeField, Range(0f,10f)]
    float flatten;

    [SerializeField, Range(0f,4f)]
    float fudgeFactor;
    
    // ----------------------------

    public bool simultaneousMode= false;

    // ----------------------------


   
    [SerializeField]

    MeshFilter meshFilter;

    [SerializeField]
    MeshRenderer meshRenderer;

    [SerializeField]
    Material material;

   


    public void GenerateTerrain(){
        //float[,] noiseMap = Noise.GenerateNoiseMap(mapResolution,octave,scale,lacunarity,persistance, flatten,fudgeFactor);

        Mesh mesh = MeshGenerator.GeneratePlane(mapResolution);

        meshFilter.sharedMesh = mesh;
        meshRenderer.sharedMaterial = material;

        
    }

   


    




}
