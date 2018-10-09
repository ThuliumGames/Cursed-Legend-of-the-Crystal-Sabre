using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {
	
    Mesh mesh;
    Vector3[] verts;
    Vector3 vertPos;
    GameObject[] handles;
	float r = 0;
	public float waveFreq;
	public float waveHeight;
     
    void Start() {
        
		mesh = GetComponent<MeshFilter>().mesh;
        verts = mesh.vertices;
        
		foreach(Vector3 vert in verts) {
            vertPos = transform.TransformPoint(vert);
            GameObject handle = new GameObject("handle");
            handle.transform.position = vertPos;
            handle.transform.parent = transform;
            handle.tag = "handle";
         }
     }
     
     void Update() {
		
		handles = GameObject.FindGameObjectsWithTag ("handle");
		r += Time.deltaTime;
		for(int i = 0; i < verts.Length; i++) {
			verts[i] = handles[i].transform.localPosition + new Vector3 (0, 0, waveHeight*Mathf.Sin((Vector3.Distance(handles[i].transform.localPosition, transform.position)*waveFreq+r)));
		}
		
		mesh.vertices = verts;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		GetComponent<MeshCollider>().sharedMesh = mesh;
     }
 }