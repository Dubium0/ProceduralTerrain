using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshDatas 
{
    public struct PlaneData{

        Vector3[] vertices;
        Vector2[] uvs;
        int[] triangles;

        public PlaneData(Vector3[] vertexData, Vector2[] uvData, int[] triangleData){
            vertices = vertexData;
            uvs = uvData;
            triangles = triangleData;
        }



        public Mesh GetPlaneMesh(){
            Mesh plane = new Mesh();

            plane.vertices = vertices;
            plane.uv = uvs;
            plane.triangles = triangles;
            plane.RecalculateNormals();
           
            return plane;
        }
    }
}
