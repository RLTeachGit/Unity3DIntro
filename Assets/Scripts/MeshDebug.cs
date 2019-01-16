using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDebug : MonoBehaviour {

    public bool VertexNormals = true;
    public bool TriNormals = true;


    MeshFilter mMF;
    public void Start() {
        mMF = GetComponent<MeshFilter>();
    }

    public void Update() {
        if(VertexNormals) MeshDebug.DebugDrawVertexNormals(transform.position,mMF.mesh, Color.red);
        if(TriNormals) MeshDebug.DebugDrawTriangleNormals(transform.position,mMF.mesh, Color.green);
    }

    public static void DebugDrawVertexNormals(Vector3 vOrigin, Mesh vMesh, Color vColour) {
        for (int i = 0; i < vMesh.vertexCount; i++) {
            Debug.DrawRay(vMesh.vertices[i]+vOrigin, vMesh.normals[i], vColour, 2.0f);
        }
    }

    public static void DebugDrawTriangleNormals(Vector3 vOrigin,Mesh vMesh, Color vColour) {
        for (int tTriIndex = 0; tTriIndex < vMesh.triangles.Length; tTriIndex += 3) {
            Vector3 tCenter = Vector3.zero;
            for (int tVertIndex = 0; tVertIndex < 3; tVertIndex++) {
                tCenter += vMesh.vertices[vMesh.triangles[tTriIndex+tVertIndex]];
            }
            tCenter /= 3.0f;
            tCenter += vOrigin;     //Offset to transform
            Vector3 tV1 = vMesh.vertices[vMesh.triangles[tTriIndex + 1]]-vMesh.vertices[vMesh.triangles[tTriIndex]];
            Vector3 tV2 = vMesh.vertices[vMesh.triangles[tTriIndex + 2]]-vMesh.vertices[vMesh.triangles[tTriIndex + 1]];
            Vector3 tNormal = Vector3.Cross(tV1,tV2).normalized;
            Debug.DrawRay(tCenter, tNormal, vColour, 2.0f);
        }
    }
}
