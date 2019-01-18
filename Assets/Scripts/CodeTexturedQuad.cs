using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeTexturedQuad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var tMF = gameObject.AddComponent<MeshFilter>();        //Reads the mesh
        var tMR = gameObject.AddComponent<MeshRenderer>();      //Renders the mesh
        Debug.Assert((tMR.material = Resources.Load<Material>("Materials/Ground")) != null); //Load material from Resources folder
        tMF.mesh = TexturedQuad(1.0f);      //make a quad in code

    }


    Mesh TexturedQuad(float vScale) {
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

        var tTris = new int[6];

        tTris[0] = 0;      //First Triangle, the need to clockwise or they wont show
        tTris[1] = 2;
        tTris[2] = 1;

        tTris[3] = 2;      //Second Triangle
        tTris[4] = 3;
        tTris[5] = 1;

        var tUVs = new Vector2[4];

        tUVs[0] = new Vector2(0, 0);        //Map vertices to UV space
        tUVs[1] = new Vector2(1, 0);
        tUVs[2] = new Vector2(0, 1);
        tUVs[3] = new Vector2(1, 1);


        tMesh.vertices = tVertices;
        tMesh.normals = tNormals;
        tMesh.uv = tUVs;                //Add UV to mesh
        tMesh.triangles = tTris;       //2x3 vertice indexes

        return tMesh;
    }
}
