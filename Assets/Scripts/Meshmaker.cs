using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meshmaker : MonoBehaviour {

    public enum MeshKind {
        Quad
        ,Cube
    }

    MeshFilter mMF;
    MeshRenderer mMR;

    public Material Mat;

    public MeshKind MeshKindSelect=MeshKind.Quad;

    private void Start() {
        mMF = gameObject.AddComponent<MeshFilter>();        //Reads the mesh
        mMR = gameObject.AddComponent<MeshRenderer>();      //Renders the mesh
        mMF.mesh = Make(MeshKindSelect, 1.0f);      //make mesh in code
        mMR.material = Mat;
    }



    static public  Mesh    Make(MeshKind vKind, float vScale) {

        switch (vKind) {
            case MeshKind.Quad:
                return Quad(vScale);

            case MeshKind.Cube:
                return Cube(vScale);

            default:
                break;
        }

        return null;
    }

static Mesh Quad(float vScale) {
        Mesh tMesh = new Mesh();    //4 vertices to make a Quad

        var tVertices = new Vector3[4];

        tVertices[0] = new Vector3(-0.5f, -0.5f, 0) * vScale;
        tVertices[1] = new Vector3(0.5f, -0.5f, 0) * vScale;
        tVertices[2] = new Vector3(-0.5f, 0.5f, 0) * vScale;
        tVertices[3] = new Vector3(0.5f, 0.5f, 0) * vScale;

        var tNormals = new Vector3[4];
        tNormals[0] = -Vector3.forward;
        tNormals[1] = -Vector3.forward;
        tNormals[2] = -Vector3.forward;
        tNormals[3] = -Vector3.forward;

        var tUVs = new Vector2[4];

        tUVs[0] = new Vector2(0, 0);
        tUVs[1] = new Vector2(1, 0);
        tUVs[2] = new Vector2(0, 1);
        tUVs[3] = new Vector2(1, 1);

        var tTris = new int[6];

        tTris[0] = 0;      //First Triangle
        tTris[1] = 2;
        tTris[2] = 1;

        tTris[3] = 2;      //Second Triangle
        tTris[4] = 3;
        tTris[5] = 1;

        tMesh.vertices = tVertices;
        tMesh.normals = tNormals;
        tMesh.uv = tUVs;      //One per vertex
        tMesh.triangles = tTris;       //2x3 vertice indexes

        return tMesh;
    }



    static Mesh Cube(float vScale) {
        Mesh tMesh = new Mesh();
        //8 vertices to make a Quad

        var tVertices = new Vector3[8];

        tVertices[0] = new Vector3(-0.5f, -0.5f, -0.5f) * vScale;
        tVertices[1] = new Vector3(0.5f, -0.5f, -0.5f) * vScale;
        tVertices[2] = new Vector3(-0.5f, 0.5f, -0.5f) * vScale;
        tVertices[3] = new Vector3(0.5f, 0.5f, -0.5f) * vScale;
        tVertices[4] = new Vector3(-0.5f, -0.5f, 0.5f) * vScale;
        tVertices[5] = new Vector3(0.5f, -0.5f, 0.5f) * vScale;
        tVertices[6] = new Vector3(-0.5f, 0.5f, 0.5f) * vScale;
        tVertices[7] = new Vector3(0.5f, 0.5f, 0.5f) * vScale;

        var tNormals = new Vector3[8];
        tNormals[0] = Vector3.back;
        tNormals[1] = Vector3.back;
        tNormals[2] = Vector3.back;
        tNormals[3] = Vector3.back;
        tNormals[4] = Vector3.forward;
        tNormals[5] = Vector3.forward;
        tNormals[6] = Vector3.forward;
        tNormals[7] = Vector3.forward;

        var tUVs = new Vector2[8];


        tUVs[0] = new Vector2(0, 0);
        tUVs[1] = new Vector2(1, 0);
        tUVs[2] = new Vector2(0, 1);
        tUVs[3] = new Vector2(1, 1);
        tUVs[4] = new Vector2(0, 0);
        tUVs[5] = new Vector2(1, 0);
        tUVs[6] = new Vector2(0, 1);
        tUVs[7] = new Vector2(1, 1);

        var tTris = new int[12*3];
        int tIndex = 0;

        tTris[tIndex++] = 0;      //First Triangle
        tTris[tIndex++] = 2;
        tTris[tIndex++] = 1;

        tTris[tIndex++] = 2;      //Second Triangle
        tTris[tIndex++] = 3;
        tTris[tIndex++] = 1;

        tTris[tIndex++] = 1;      //3rd Triangle
        tTris[tIndex++] = 3;
        tTris[tIndex++] = 7;

        tTris[tIndex++] = 7;      //4th Triangle
        tTris[tIndex++] = 5;
        tTris[tIndex++] = 1;

        tTris[tIndex++] = 7;      //5th Triangle
        tTris[tIndex++] = 6;
        tTris[tIndex++] = 4;

        tTris[tIndex++] = 4;      //6th Triangle
        tTris[tIndex++] = 5;
        tTris[tIndex++] = 7;

        tTris[tIndex++] = 4;      //7th Triangle
        tTris[tIndex++] = 6;
        tTris[tIndex++] = 2;

        tTris[tIndex++] = 2;      //8th Triangle
        tTris[tIndex++] = 0;
        tTris[tIndex++] = 4;


        tTris[tIndex++] = 6;      //9th Triangle
        tTris[tIndex++] = 7;
        tTris[tIndex++] = 3;

        tTris[tIndex++] = 3;      //10th Triangle
        tTris[tIndex++] = 2;
        tTris[tIndex++] = 6;

        tTris[tIndex++] = 1;      //11th Triangle
        tTris[tIndex++] = 5;
        tTris[tIndex++] = 4;

        tTris[tIndex++] = 4;      //12th Triangle
        tTris[tIndex++] = 0;
        tTris[tIndex++] = 1;

        tMesh.vertices = tVertices;
        tMesh.normals = tNormals;
        //tMesh.uv = tUVs;      //One per vertex
        tMesh.triangles = tTris;       //2x3 vertice indexes

        return tMesh;

    }
}
