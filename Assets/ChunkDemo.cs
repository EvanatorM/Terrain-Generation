using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class ChunkDemo : MonoBehaviour
{
    [SerializeField, Range(2, 100)] int resolution = 10;
    [SerializeField, Range(1, 100)] int size = 10;

    MeshFilter mFilter;

    Mesh mesh;

    void Start()
    {
        mFilter = GetComponent<MeshFilter>();

        GenerateMesh();
    }

    void GenerateMesh()
    {
        mesh = new Mesh();

        Vector3[] vertices = new Vector3[resolution * resolution];
        Vector3[] normals = new Vector3[resolution * resolution];

        float spacing = size / (float)resolution;
        
        for (int x = 0; x < resolution; x++)
        {
            for (int z = 0; z < resolution; z++)
            {
                vertices[x * resolution + z] = new Vector3(x * spacing, Random.Range(-1f, 1f), z * spacing);
                normals[x * resolution + z] = Vector3.up;
            }
        }

        int[] triangles = new int[((resolution - 1) * (resolution - 1)) * 6];
        int t = 0;
        for (int i = 0; i < triangles.Length - 5; i += 6)
        {
            triangles[i] = t;
            triangles[i + 1] = t + 1;
            triangles[i + 2] = t + resolution;
            triangles[i + 3] = t + 1;
            triangles[i + 4] = t + resolution + 1;
            triangles[i + 5] = t + resolution;
            t += 1;

            if (t % resolution == resolution - 1)
                t++;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        //mesh.uv = uv;
        //mesh.tangents = tangents;

        mFilter.mesh = mesh;
    }
}
