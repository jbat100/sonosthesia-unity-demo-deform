#ifndef NOISE_SIMPLEX_4D_FUNC
#define NOISE_SIMPLEX_4D_FUNC

#include "Simplex4DImplementation.hlsl"

//----------------------- Simplex -------------------------

void SimplexNoise4D_float(float4 coordinates, out float Out)
{
    Out = snoise(coordinates);
}

// uses 4D simplex noise, using time as the 4th input component
void DynamicSimplexNoise3D_float(float3 coordinates, float time, out float Out)
{
    Out = snoise(float4(coordinates, time));
}

void SimplexNoise4D_half(half4 coordinates, out half Out)
{
    Out = snoise(coordinates);
}

// uses 4D simplex noise, using time as the 4th input component
void DynamicSimplexNoise3D_half(half3 coordinates, half time, out half Out)
{
    Out = snoise(half4(coordinates, time));
}

//----------------------- Settings -------------------------

// spark settings from https://alteredqualia.com/three/examples/webgl_shader_sparks.html

void DynamicSparkNoise_float(float3 coordinates, float time, out float Out)
{
    float4 coord = float4(coordinates, time);
    float n = 0.0;

    n += 1.0 * abs(snoise(coord));
    n += 0.5 * abs(snoise(coord * 2.0));
    n += 0.25 * abs(snoise(coord * 4.0));
    n += 0.125 * abs(snoise(coord * 8.0));

    const float rn = 1.0 - n;
    Out = rn * rn;
}

void DynamicSparkNoise_half(half3 coordinates, half time, out half Out)
{
    DynamicSparkNoise_float(coordinates, time, Out);
}

// amber settings from https://alteredqualia.com/three/examples/webgl_shader_amber.html




#endif