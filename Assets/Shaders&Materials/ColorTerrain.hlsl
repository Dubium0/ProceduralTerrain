#ifndef COLORTERRAIN_HLSL
#define COLORTERRAIN_HLSL

#include "Noise.hlsl"








float3 LerpColors(float3 left, float3 right , float a ){

    

    float r = left.r  + ( right.r - left.r) * a; 
    float g = left.g  + ( right.g - left.g) * a; 
    float b = left.b  + ( right.b - left.b) * a; 

    return float3(r,g,b);
}

float LerpVal ( float min ,float max , float val) {
    return (val - min) / ( max - min);
}













void ColorTerrain_float(
        //inputs -----------
        float vertexHeight,
        //------------
        float deepWaterLevel,
        float waterLevel,
        float seaCostLevel,
        float grassLevel,
        float forestLevel,
        float rocklevel,
        float upperRockLevel,
        float snowLevel,
        //------
        float3 deepWaterColor,
        float3 waterColor,
        float3 seaCostColor,
        float3 grassColor,
        float3 forestColor,
        float3 rockColor,
        float3 upperRockColor,
        float3 snowColor,
        // ----------------
       
        //output----
        out float3 Out
        //---------
        ){
            
 
            if( vertexHeight <= deepWaterLevel){
                
                Out =  deepWaterColor;

            }else if( vertexHeight <= waterLevel){
                
                float lerpedHeight = LerpVal(deepWaterLevel , waterLevel,vertexHeight ); 
                float3 lerpedColor = LerpColors(deepWaterColor,waterColor, lerpedHeight);
                

                Out =  lerpedColor;
 
            }else if( vertexHeight <= seaCostLevel){
                
                float seaCostStrength = step((seaCostLevel -waterLevel)/2.0 + waterLevel,vertexHeight);
                float3 lerpedColor = seaCostStrength*seaCostColor + (1-seaCostStrength)*waterColor;

                Out =  lerpedColor;

            }else if( vertexHeight <= grassLevel){
                float lerpedHeight = LerpVal(seaCostLevel , grassLevel,vertexHeight); 
                float3 lerpedColor = LerpColors(seaCostColor,grassColor, lerpedHeight);


                Out =  lerpedColor;

            }else if( vertexHeight <= forestLevel){
                float lerpedHeight = LerpVal(grassLevel , forestLevel,vertexHeight ); 
                float3 lerpedColor = LerpColors(grassColor,forestColor, lerpedHeight);


                Out =  lerpedColor;

            }else if( vertexHeight <= rocklevel){
                float lerpedHeight = LerpVal(forestLevel , rocklevel,vertexHeight ); 
                float3 lerpedColor = LerpColors(forestColor,rockColor, lerpedHeight);


                Out =  lerpedColor;

            }else if( vertexHeight <= upperRockLevel){
                float lerpedHeight = LerpVal(rocklevel , upperRockLevel,vertexHeight ); 
                float3 lerpedColor = LerpColors(rockColor,upperRockColor, lerpedHeight);


                Out =  lerpedColor;

            }else if( vertexHeight <= snowLevel){
                float lerpedHeight = LerpVal(upperRockLevel , snowLevel,vertexHeight ); 
                float3 lerpedColor = LerpColors(upperRockColor,snowColor, lerpedHeight);


                Out =  lerpedColor;
            }else{
                Out =  snowColor;
            }


           
         

    
       
   
}









#endif
