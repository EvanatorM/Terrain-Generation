using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float Noise2D(float x, float z, float amplitude, float frequency, int octaves)
    {
        float value = 0;
        for (int i = 0; i < octaves; i++)
        {
            value += Mathf.PerlinNoise(x * frequency, z * frequency) * amplitude;
            frequency *= 2f;
            amplitude *= .5f;
        }

        return value;
    }
}
