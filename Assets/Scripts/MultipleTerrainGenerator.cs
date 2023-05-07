using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class MultipleTerrainGenerator : MonoBehaviour
{
    
    [SerializeField]
    Material commonMaterial;

    [SerializeField, Range(0,maxTerrainDimension)]
    int terrainDimension;

    
    const int maxTerrainDimension = 4;

    const int maxVertexNumber = 241;

    int[] LOD = {1,2,3,4,5,6,8,16};

    [SerializeField,Range(0,7)]
    int lodSlider;


    public bool simultaneousMode;

    [SerializeField]
    GameObject[] gameObjects;
     [SerializeField,HideInInspector]
    MeshRenderer[] meshRenderers;
     [SerializeField,HideInInspector]
    MeshFilter[] meshFilters;
   

    private void OnEnable() {
        DestroyAllGameObjects();
        InitializeObjects();
    }

    private void OnDisable() {
        DestroyAllGameObjects();
    }

    public void GenerateTerrains(){

        Mesh mesh = MeshGenerator.GeneratePlane(maxVertexNumber,LOD[lodSlider]);

        
        CleanGameObjects();

        for( int x = 0  ; x  < terrainDimension ; x++){
            for( int y = 0  ; y  < terrainDimension ; y++){

                int index  = y + x*terrainDimension;
                if(gameObjects[index]== null ){
                    gameObjects[index] = new GameObject(index + ". terrain");
                    if(transform.localScale.x == 1f && transform.localScale.z == 1f && transform.localScale.y ==1f)
                    {
                        gameObjects[index].transform.parent = transform;
                    }else
                    {
                        Vector3 prev  = transform.localScale;
                        transform.localScale  =new Vector3( 1f, 1f,1f);
                        gameObjects[index].transform.parent = transform;
                        transform.localScale = prev;
                    }
                    
                    gameObjects[index].transform.localPosition = new Vector3( x * 4f , 0f , y *4f );
                    
                    
                    meshFilters[index] = gameObjects[index].AddComponent<MeshFilter>();
                    meshRenderers[index] = gameObjects[index].AddComponent<MeshRenderer>();
                    meshRenderers[index].sharedMaterial = commonMaterial;
                }else{
                    
                    gameObjects[index].transform.localPosition = new Vector3( x * 4f , 0f , y *4f );
                   
                }
                
                meshFilters[index].sharedMesh = mesh;
                

  
            
            }

        }
        


         
    }


    void InitializeObjects(){
        
        
           
            gameObjects = new GameObject[maxTerrainDimension * maxTerrainDimension];
    
            
        
       
            meshRenderers = new MeshRenderer[maxTerrainDimension * maxTerrainDimension];
        
       
            meshFilters = new MeshFilter[maxTerrainDimension * maxTerrainDimension];
       
        
    }

    void CleanGameObjects(){
        for(int i =gameObjects.Length-1  ; i>= terrainDimension;i--){
            if(gameObjects[i] != null){
                DestroyImmediate(gameObjects[i]);
                //gameObjects[i] = null;
            }
        }
    }
    void DestroyAllGameObjects(){
        if( gameObjects !=null){
            for(int i =0  ; i< gameObjects.Length;i++){
            if(gameObjects[i] != null){
                DestroyImmediate(gameObjects[i]);
                gameObjects[i] = null;
            }
        }

        }
        
        gameObjects = null;
        meshRenderers = null;
        meshFilters = null;
    }






}
