#ifndef APPLYNOISE_HLSL
#define APPLYNOISE_HLSL

#define lacunarity 2.0
#define persistance 0.5


#include "Noise.hlsl"


float RawNoise(float x, float y , float scale,float frequency, float weigth, float2 offSet){

    return (snoise(float2(x / scale * frequency + offSet.x , y / scale * frequency + offSet.y)))*weigth;
}
float RigidNoise(float x, float y , float scale,float frequency, float weigth){

    return (abs(snoise(float2(x / scale * frequency  , y / scale * frequency ))))*weigth;
}
/*
float RadianNoise(float x, float y , float scale , float frequency, float weigth , float offSet){

    float noiseValue  = snoise(float2(x / scale * frequency  , y / scale * frequency )) // noise val -1, 1

    float degree  = 



}*/

float ApplyOctave_Raw(float x, float y, float octave, float scale, float2 offSet ){

        float frequency = 1.0;
        float weigth = 1.0;
        float noiseVal = 0.0;

        float divisonVal = 0.0;


        for(int i = 0 ; i< octave; i++){

            noiseVal+=RawNoise( x,y ,scale,frequency,weigth , offSet);

            divisonVal += weigth;
            frequency *= lacunarity;
            weigth*= persistance;
    
        }

        noiseVal = (noiseVal + divisonVal)/ (1.0 + 2.0*divisonVal); // 0-1 scale
        return noiseVal;

}
float ApplyOctave_Rigid(float x, float y, float octave, float scale){

        float frequency = 1.0;
        float weigth = 1.0;
        float noiseVal = 0.0;

        float divisonVal = 0.0;


        for(int i = 0 ; i< octave; i++){

            noiseVal+=RigidNoise( x,y ,scale,frequency,weigth);

            divisonVal += weigth;
            frequency *= lacunarity;
            weigth*= persistance;
    
        }

        noiseVal = (noiseVal /divisonVal); // 0-1 scale
        return noiseVal;

}


float GetNoiseVal(float x, float y,float octave ,float mountainSmoothness , float mountainHeight , float hillHeight, float generalScale , float mountainSpec1, float mountainSpec2  ,float mountainScale, float hillScale , float2 hillOffset){
        float output = 0.0;
        float hills = ApplyOctave_Raw(x,y,octave,hillScale, hillOffset);
        float mountains = ApplyOctave_Rigid(x,y,octave,mountainScale);
        //float water = ApplyOctave_Raw(x,y,octave,3000.0, 15.33);
        

        
        
        mountains = pow( mountains * mountainSpec1 , mountainSpec2);
        mountains*=mountainHeight;
        hills *= hillHeight;
        output =   max (mountains, hills);
        output *= generalScale;

        
        return output;

    }

    

    
    



    void EvaluatePoint_float( float x, float y,float octave ,float mountainSmoothness , float mountainHeight , float hillHeight, float generalScale  , float mountainSpec1, float mountainSpec2 ,float mountainScale, float hillScale, float2 hillOffset,out float PosOut,out float ColorOut){

        float noise = GetNoiseVal( x,  y, octave , mountainSmoothness ,  mountainHeight ,  hillHeight,  generalScale, mountainSpec1,  mountainSpec2,  mountainScale,hillScale,hillOffset );
        PosOut = noise;
        ColorOut = noise;

    }























#endif