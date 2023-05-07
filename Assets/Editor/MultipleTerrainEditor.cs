using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MultipleTerrainGenerator))]
public class MultipleTerrainEditor : Editor
{

    public override void OnInspectorGUI(){
        MultipleTerrainGenerator terrainScript = (MultipleTerrainGenerator) target;

        

        
        if( DrawDefaultInspector()){
            if(terrainScript.simultaneousMode){
                terrainScript.GenerateTerrains();
            }
            EditorGUILayout.HelpBox(" Terrain Properties ", MessageType.Info);

            


        }
        if(GUILayout.Button("Generate Terrain")){

            terrainScript.GenerateTerrains();


            }


        


    }
    



}
