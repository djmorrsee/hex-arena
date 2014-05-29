//// Created By Daniel Morrissey
////////////////////////////////

using UnityEngine;
using System.Collections;

public static class HexTileGameObject : object
{

    public static GameObject HexTileGO()
    {
        GameObject hTile = new GameObject();
        MeshFilter mf = hTile.AddComponent<MeshFilter>();
        MeshRenderer mr = hTile.AddComponent<MeshRenderer>();
        mr.material = new Material(Shader.Find("Diffuse"));
        mr.material.color *= Random.value + 0.5f;

        mf.mesh = HexMesh(1);


        return hTile;
    }

    static Mesh HexMesh(float r)
    {
        r *= 0.95f;
        Mesh m = new Mesh();

        Vector3[] verts = new Vector3[7];
        verts[0] = Vector3.zero;
        Vector2[] uv = new Vector2[7];
        uv[0] = new Vector2(.5f, .5f);
        int[] tris = new int[18];

        for (int i = 0; i < 6; ++i)
        {
            Vector3 point;
            float angle = -2 * Mathf.PI * (1f / 6f) * (i + 0.5f);

            float x_i = Mathf.Cos(angle);
            float y_i = Mathf.Sin(angle);

            point = new Vector3(x_i, y_i, 0);
            verts[i + 1] = point * r;
            uv[i] = new Vector2(point.x, point.z);

            for (int j = 0; j < 3; ++j)
            {
                tris[j + i * 3] = j * (i + j);
            }

            int l_idx = i * 3;
            tris[l_idx] = 0;
            tris[l_idx + 1] = i + 1;

            if (i == 5)
                tris[l_idx + 2] = 1;
            else 
                tris[l_idx + 2] = i + 2;
        }

        m.vertices = verts;
        m.uv = uv;
        m.triangles = tris;
        m.RecalculateNormals();
        m.RecalculateBounds();

        return m;
    }
}