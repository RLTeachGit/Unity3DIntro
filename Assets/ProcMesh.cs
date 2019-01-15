using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcMesh : MonoBehaviour {

    MeshFilter mMF;
    MeshRenderer mMR;

    public Material Mat;


    Vector3[]   mVertices = new Vector3[4];     //Points in 3D space where vertices are
    Vector3[]   mNormals = new Vector3[4];      //Normals at Vertices
    Vector2[]   mUVs = new Vector2[4];          //UV at Vertex

    int[] mTriangles = new int[6];              //2 triangles of 3 Vertices each


    float MasterWidth = 1.0f;
    float MasterHeight = 1.0f;


    // Use this for initialization
    void Start () {

        mMF = gameObject.AddComponent<MeshFilter>();        //Reads the mesh
        mMR = gameObject.AddComponent<MeshRenderer>();      //Renders the mesh

        mMF.mesh = new Mesh();      //make mesh in code

        //4 vertices to make a Square
        mVertices[0] = new Vector3(0, 0, 0);
        mVertices[1] = new Vector3(MasterWidth, 0, 0);
        mVertices[2] = new Vector3(0, MasterHeight, 0);
        mVertices[3] = new Vector3(MasterWidth, MasterHeight, 0);

        mMF.mesh.vertices = mVertices;      //Add to mesh

        mTriangles[0] = 0;      //First Triangle
        mTriangles[1] = 2;
        mTriangles[2] = 1;

        mTriangles[3] = 2;      //Second Triangle
        mTriangles[4] = 3;
        mTriangles[5] = 1;

        mMF.mesh.triangles = mTriangles;    //Add to mesh

        mNormals[0] = -Vector3.forward;     //Vertext normals, they change how light is affected
        mNormals[1] = -Vector3.forward;
        mNormals[2] = -Vector3.forward;
        mNormals[3] = -Vector3.forward;

        mMF.mesh.normals = mNormals;        //Add to mesh


        mUVs[0] = new Vector2(0, 0);        //Mesh UV maps 2D texture to mesh
        mUVs[1] = new Vector2(1, 0);
        mUVs[2] = new Vector2(0, 1);
        mUVs[3] = new Vector2(1, 1);


        mMF.mesh.uv = mUVs;

        mMR.material = Mat;
    }



    float tTime=0;
	// Update is called once per frame
	void Update () {
        float tWidth = Mathf.Cos(tTime)+2;
        float tHeight = Mathf.Sin(tTime)+2;

        mMF.mesh.Clear();

        mVertices[0] = new Vector3(0, 0, 0);
        mVertices[1] = new Vector3(tWidth, 0, 0);
        mVertices[2] = new Vector3(0, tHeight, 0);
        mVertices[3] = new Vector3(tWidth, tHeight, 0);

        mMR.material = Mat;
        mMF.mesh.vertices = mVertices;

        mMF.mesh.normals = mNormals;
        mMF.mesh.uv = mUVs;
        mMF.mesh.triangles = mTriangles;


        tTime += Time.deltaTime;
    }
}
