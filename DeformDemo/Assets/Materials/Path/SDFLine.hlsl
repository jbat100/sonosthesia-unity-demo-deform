#ifndef LINE_SEGMENT_2D_SDF_FUNC
#define LINE_SEGMENT_2D_SDF_FUNC

// https://www.youtube.com/watch?v=D_Zq6q1gnvw

void LineSegment2DSDF_float(float2 p, float2 a, float2 b, out float result)
{
    float2 ba = b - a;
    float2 pa = p - a;
    float k = saturate(dot(pa, ba) / dot(ba, ba));
    result = length(pa - ba * k);
}

void LineSegment2DSDF_half(half2 p, half2 a, half2 b, out half result)
{
    half2 ba = b - a;
    half2 pa = p - a;
    half k = saturate(dot(pa, ba) / dot(ba, ba));
    result = length(pa - ba * k);
}

// https://www.youtube.com/watch?v=WuNdmjca7eM

void AABoxSDF_float(float2 p, float2 dimensions, float2 offset, out float result)
{
    float2 q = p - offset;
    float2 d = abs(q) - dimensions * 0.5;
    result = length(max(d, 0)) + min(max(d.x, d.y), 0);
}

void AABoxSDF_half(half2 p, half2 dimensions, half2 offset, out half result)
{
    half2 q = p - offset;
    half2 d = abs(q) - dimensions * 0.5;
    result = length(max(d, 0)) + min(max(d.x, d.y), 0);
}

void AACoordSDF_float(float p, float dimensions, float offset, out float result)
{
    float q = p - offset;
    float d = abs(q) - dimensions * 0.5;
    result = length(max(d, 0));
}

void AACoordSDF_half(half p, half dimensions, half offset, out half result)
{
    half q = p - offset;
    half d = abs(q) - dimensions * 0.5;
    result = length(max(d, 0));
}

#endif