using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    
    public static Mesh GeneratePlane(int resolution, float[,] noiseMap){

        float step  = 4f / ((float)resolution-1f);

        Vector3[] vertices = new Vector3[resolution*resolution];

        Vector2[] uvs  = new Vector2[resolution*resolution];
        
        int[] triangles  =new int[(resolution-1)*(resolution-1)*6];


        int vertexIndex = 0;
        int triangleIndex = 0;

        for(int x = 0; x< resolution;x++){
            for(int y = 0; y< resolution;y++){

                //vertices[vertexIndex] = new Vector3(x*step,noiseMap[x,y],y*step);
                vertices[vertexIndex] = new Vector3(x*step,0f,y*step);

                uvs[vertexIndex] = new Vector2((float) x /(float) resolution,(float)y/(float)resolution);


                if((x< resolution-1)&&(y < resolution-1)){
                    triangles[triangleIndex ] = vertexIndex;
                    triangles[triangleIndex + 1 ] = vertexIndex + resolution +1;
                    triangles[triangleIndex + 2 ] = vertexIndex + resolution;


                    triangles[triangleIndex + 3 ] = vertexIndex;
                    triangles[triangleIndex + 4 ] = vertexIndex +1;
                    triangles[triangleIndex + 5 ] = vertexIndex +resolution +1;
                    triangleIndex +=6;
                }
                vertexIndex +=1;

            }
        }
        
        Mesh planeMesh = new Mesh();
        planeMesh = new MeshDatas.PlaneData(vertices,uvs,triangles).GetPlaneMesh();

        return planeMesh;


    }

    public static Mesh GeneratePlane(int resolution){

        float step  = 4f / ((float)resolution-1f);

        Vector3[] vertices = new Vector3[resolution*resolution];

        Vector2[] uvs  = new Vector2[resolution*resolution];
        
        int[] triangles  =new int[(resolution-1)*(resolution-1)*6];


        int vertexIndex = 0;
        int triangleIndex = 0;

        for(int x = 0; x< resolution;x++){
            for(int y = 0; y< resolution;y++){

                //vertices[vertexIndex] = new Vector3(x*step,noiseMap[x,y],y*step);
                vertices[vertexIndex] = new Vector3(x*step,0f,y*step);

                uvs[vertexIndex] = new Vector2((float) x /(float) resolution,(float)y/(float)resolution);


                if((x< resolution-1)&&(y < resolution-1)){
                    triangles[triangleIndex ] = vertexIndex;
                    triangles[triangleIndex + 1 ] = vertexIndex + resolution +1;
                    triangles[triangleIndex + 2 ] = vertexIndex + resolution;


                    triangles[triangleIndex + 3 ] = vertexIndex;
                    triangles[triangleIndex + 4 ] = vertexIndex +1;
                    triangles[triangleIndex + 5 ] = vertexIndex +resolution +1;
                    triangleIndex +=6;
                }
                vertexIndex +=1;

            }
        }
        
        Mesh planeMesh = new Mesh();
        planeMesh = new MeshDatas.PlaneData(vertices,uvs,triangles).GetPlaneMesh();

        return planeMesh;


    }




    public static Mesh GeneratePlane(int maxResolution,int lodVal){
        int resolution = (maxResolution -1) / lodVal + 1;
       
        float step  = 4f / ((float)resolution-1f);
        
        Vector3[] vertices = new Vector3[resolution*resolution];

        Vector2[] uvs  = new Vector2[resolution*resolution];
        
        int[] triangles  =new int[(resolution-1)*(resolution-1)*6];


        int vertexIndex = 0;
        int triangleIndex = 0;

        for(int x = 0; x< resolution;x++){
            for(int y = 0; y< resolution;y++){

                //vertices[vertexIndex] = new Vector3(x*step,noiseMap[x,y],y*step);
                vertices[vertexIndex] = new Vector3(x*step,0f,y*step);

                uvs[vertexIndex] = new Vector2((float) x /(float) resolution,(float)y/(float)resolution);


                if((x< resolution-1)&&(y < resolution-1)){
                    triangles[triangleIndex ] = vertexIndex;
                    triangles[triangleIndex + 1 ] = vertexIndex + resolution +1;
                    triangles[triangleIndex + 2 ] = vertexIndex + resolution;


                    triangles[triangleIndex + 3 ] = vertexIndex;
                    triangles[triangleIndex + 4 ] = vertexIndex +1;
                    triangles[triangleIndex + 5 ] = vertexIndex +resolution +1;
                    triangleIndex +=6;
                }
                vertexIndex +=1;

            }
        }
        
        Mesh planeMesh = new MeshDatas.PlaneData(vertices,uvs,triangles).GetPlaneMesh();
       

        return planeMesh;


    }








}
