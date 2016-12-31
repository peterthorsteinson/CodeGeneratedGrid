﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CodeGeneratedGrid : MonoBehaviour
{
    private Vector3[] vertices;
    public int xSize = 20, ySize = 20;
    private Mesh mesh;

    private void Awake()
    {
        Generate(); // normal fast generation of mesh
        //StartCoroutine(GenerateSlowMotion()); // use this one if you want to see the dots displayed as the mesh is generated in Unity3D Scene window
    }

    private void Generate()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                float xCenterOffset = xSize / 2.0f;
                float yCenterOffset = ySize / 2.0f;
                vertices[i] = new Vector3(
                    x - xCenterOffset,
                    y - yCenterOffset,
                    Mathf.Sqrt((x - xCenterOffset) * (x - xCenterOffset) + (y - yCenterOffset) * (y - yCenterOffset)));
            }
        }
        mesh.vertices = vertices;
        int[] triangles = new int[xSize * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
        }
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
    private IEnumerator GenerateSlowMotion()
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                float xCenterOffset = xSize / 2.0f;
                float yCenterOffset = ySize / 2.0f;
                vertices[i] = new Vector3(
                    x - xCenterOffset,
                    y - yCenterOffset,
                    Mathf.Sqrt((x - xCenterOffset) * (x - xCenterOffset) + (y - yCenterOffset) * (y - yCenterOffset)));
                yield return wait;
            }
        }
        mesh.vertices = vertices;
        int[] triangles = new int[xSize * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
        }
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
