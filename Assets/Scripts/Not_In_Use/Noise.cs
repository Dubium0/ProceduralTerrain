using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{

    public static float[,] GenerateNoiseMap(int mapResolution, int octave , float scale,float lacunarity, float persistance, float toThePower , float fudgeFactor){

        float[,] noiseMap = new float[mapResolution,mapResolution];
        


        for(int x = 0; x< mapResolution;x++){
            for(int y= 0 ; y< mapResolution; y++){
                float initialNoiseVal = GetNoiseVal(x,y,octave,scale,lacunarity,persistance);
                
                noiseMap[x,y] =   Mathf.Pow(initialNoiseVal * fudgeFactor , toThePower) ;

            }
        }
        

        return noiseMap;

    }
    static float GetNoiseVal(float xVal, float yVal,int octave ,float scale,float lacunarity, float persistance){

        float frequency = 1f;
        float weigth = 1f;
        float noiseVal = 0f;

        float divisonVal = 0f;


        for(int i = 0 ; i< octave; i++){

            float xCoord =  xVal /scale * frequency;
            float yCoord =  yVal /scale * frequency;

            float temp = Mathf.PerlinNoise(xCoord,yCoord) *2f -1f;
            noiseVal += temp * weigth;
            divisonVal += weigth;
            frequency *= lacunarity;
            weigth*= persistance;
            
            
        }
        
        // using curve
        //noiseVal = curve.Evaluate(noiseVal/divisonVal);
        noiseVal = noiseVal /divisonVal;
        return 1f -Mathf.Abs( noiseVal);

    }


    
}
