using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Terrain_))]
public class TerrainEditor : Editor
{

    public override void OnInspectorGUI(){
        Terrain_ terrainScript = (Terrain_) target;

        

        
        if( DrawDefaultInspector()){
            if(terrainScript.simultaneousMode){
                terrainScript.GenerateTerrain();
            }
            EditorGUILayout.HelpBox(" Terrain Properties ", MessageType.Info);

            


        }
        if(GUILayout.Button("Generate Terrain")){

            terrainScript.GenerateTerrain();


            }


        


    }
    



}
