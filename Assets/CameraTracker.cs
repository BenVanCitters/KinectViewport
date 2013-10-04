using UnityEngine;
using System.Collections;

public class CameraTracker : MonoBehaviour 
{
	public Camera MainCamera;
	public GameObject Head;
	
	private Mesh mesh;
	private float[] vBounds;
//	enum bounds{
//		topBound,
//		bottomBound
//	};
	// Use this for initialization
	void Start () 
	{
		vBounds = new float[]{99999,-99999};
		MeshFilter mFilt = (MeshFilter)this.GetComponent("MeshFilter");
		mesh = mFilt.mesh;
		Vector3[] verts = mesh.vertices;
		foreach(Vector3 v in verts)
		{
			
			Debug.Log("vert: " + v);
//			if(v.y < vBounds[topBound])
//				vBounds[topBound] 
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3[] verts = mesh.vertices;
		
		Vector3 a = transform.TransformPoint( verts[0] )- Head.transform.position;
		Vector3 b = transform.TransformPoint(verts[1])- Head.transform.position;
		
		MainCamera.fieldOfView = Vector3.Angle(a,b);
		
		Vector3 lookAt = MainCamera.transform.position + (MainCamera.transform.position - Head.transform.position);
		MainCamera.transform.LookAt(lookAt);
		
		Debug.Log("MainCamera.fieldOfView: " + MainCamera.fieldOfView);
	}
}
