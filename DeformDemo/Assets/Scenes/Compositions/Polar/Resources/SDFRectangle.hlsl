#ifndef SDFRECTANGLE_INCLUDED
#define SDFRECTANGLE_INCLUDED

// NedMakesGames comes to rescue yet again https://www.youtube.com/watch?v=WuNdmjca7eM

void AABoxSDF_float(float2 p, float dimensions, out float result) {
    float2 d = abs(p) - dimensions * 0.5;
    result = length(max(d, 0)) + min(max(d.x, d.y), 0);
}

void OffsetAABoxSDF_float(float2 p, float dimensions, float2 offset, out float result) {
    float2 q = p - offset;
    float2 d = abs(q) - dimensions * 0.5;
    result = length(max(d, 0)) + min(max(d.x, d.y), 0);
}

void RoundedAABoxSDF_float(float2 p, float2 dimensions, float2 offset, float rounding, out float result) {
    float2 q = p - offset;
    float2 d = abs(q) - dimensions * 0.5 + rounding;
    result = length(max(d, 0)) + min(max(d.x, d.y), 0) - rounding;
}

#endif