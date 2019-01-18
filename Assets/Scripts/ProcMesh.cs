using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcMesh : MonoBehaviour {

    MeshFilter mMF;
    MeshRenderer mMR;

    public Material Mat;


    Vector3[]   mVertices =     new Vector3[4];     //Points in 3D space where vertices are
    Vector3[]   mNormals =      new Vector3[4];      //Normals at Vertices
    Vector2[]   mUVs =          new Vector2[4];          //UV at Vertex
    int[]       mTriangles =    new int[6];              //2 triangles of 3 Vertices each

    [Range(0.0f, 2.0f)]
    public float Speed = 0.0f;

    [Range(0,5)]
    public  float Scale = 1.0f;

    [Range(-4, 4)]
    public float MapX = 1.0f;
    [Range(-4, 4)]
    public float MapY = 1.0f;

    [Range(-90,90)]
    public float AngleY = 0.0f;

    [Range(-90, 90)]
    public float AngleX = 0.0f;

    Vector3 tNormal = -Vector3.forward;

    Vector3 mRotationAxisY = Vector3.up;
    Vector3 mRotationAxisX = Vector3.right;

    Vector3 V1;
    Vector3 V2;
    Vector3 V3;
    Vector3 V4;

        // Use this for initialization
    void Start () {

        mMF = gameObject.AddComponent<MeshFilter>();        //Reads the mesh
        mMR = gameObject.AddComponent<MeshRenderer>();      //Renders the mesh
        mMF.mesh = new Mesh();      //make mesh in code

        //4 vertices to make a Square
        V1 = new Vector3(-0.5f, -0.5f, 0);
        V2 = new Vector3(0.5f, -0.5f, 0);
        V3 = new Vector3(-0.5f, 0.5f, 0);
        V4 = new Vector3(0.5f, 0.5f, 0);


        mTriangles[0] = 0;      //First Triangle
        mTriangles[1] = 2;
        mTriangles[2] = 1;

        mTriangles[3] = 2;      //Second Triangle
        mTriangles[4] = 3;
        mTriangles[5] = 1;

        }



    float tTime=0;
	// Update is called once per frame
	void Update () {
        Control();
        Vector2 tOffset = new Vector3(Mathf.Cos(tTime),Mathf.Sin(tTime));

        mMF.mesh.Clear();   //Clear buffers

        mVertices[0] = V1 * Scale;    //Reset vertex positions
        mVertices[1] = V2 * Scale;
        mVertices[2] = V3 * Scale;
        mVertices[3] = V4 * Scale;

        mMR.material = Mat;
        mMF.mesh.vertices = mVertices;

        mNormals[0] = Quaternion.AngleAxis(AngleX, mRotationAxisX) * Quaternion.AngleAxis(-AngleY, mRotationAxisY) * tNormal;     //Vertext normals, they change how light is affected
        mNormals[1] = Quaternion.AngleAxis(AngleX, mRotationAxisX) * Quaternion.AngleAxis(AngleY, mRotationAxisY) * tNormal;
        mNormals[2] = Quaternion.AngleAxis(-AngleX, mRotationAxisX) * Quaternion.AngleAxis(-AngleY, mRotationAxisY) * tNormal;
        mNormals[3] = Quaternion.AngleAxis(-AngleX, mRotationAxisX) * Quaternion.AngleAxis(AngleY, mRotationAxisY) * tNormal;
        mMF.mesh.normals = mNormals;

        mUVs[0] = new Vector2(0, 0) + tOffset;        //Mesh UV maps 2D texture to mesh
        mUVs[1] = new Vector2(MapX, 0) + tOffset;
        mUVs[2] = new Vector2(0, MapY) + tOffset;
        mUVs[3] = new Vector2(MapX, MapY) + tOffset;
        mMF.mesh.uv = mUVs;
        mMF.mesh.triangles = mTriangles;

        MeshDebug.DebugDrawVertexNormals(transform.position, transform.rotation, mMF.mesh,Color.red);
        MeshDebug.DebugDrawTriangleNormals(transform.position, transform.rotation, mMF.mesh, Color.green);

        tTime += Time.deltaTime*Speed;
    }

    private void Control() {
        if(Input.GetMouseButton(1)) {
            Vector2 tMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if(Mathf.Abs(tMousePos.x)<=1.0 && Mathf.Abs(tMousePos.y)<=1.0) {
                tMousePos.x = Mathf.Clamp(tMousePos.x * 2 - 1, -1, 1);
                tMousePos.y = Mathf.Clamp(tMousePos.y * 2 - 1, -1, 1);
                AngleY = 90 * tMousePos.x;
                AngleX = 90 * tMousePos.y;
            }
        }
    }

}
