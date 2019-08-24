using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshFilter))]

public class SpawnButtonMesh : MonoBehaviour {
	int objn = 20;

	public Material materialUI;

	// Use this for initialization
	void Start () {
		for(int i = 0;i <= 3; i++){
			
		}
		var mesh = new Mesh ();
		mesh.vertices = new Vector3[] {
			new Vector3 (1, 2f),
			new Vector3 (-1f, 2f),
			new Vector3 (0f, 0f),
		};
		mesh.triangles = new int[] {
			2, 1, 0
		};
		mesh.RecalculateNormals ();
		var filter = GetComponent<MeshFilter> ();
		filter.sharedMesh = mesh;

		var renderer = GetComponent<MeshRenderer> ();
		renderer.material = materialUI;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
