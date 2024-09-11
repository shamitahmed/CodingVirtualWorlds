using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour {
	public float scrollSpeed = 0.0004f ;
	private Mesh mesh ;

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter>().mesh ;
	}
	
	// Update is called once per frame
	void Update () {
		scroll();
	}

	void scroll(){
		Vector2[] uvSwap = mesh.uv;
		
		for (int i = 0 ; i < uvSwap.Length ; i ++)
		{
			uvSwap[i] += new Vector2( scrollSpeed * Time.deltaTime, scrollSpeed * Time.deltaTime );
		}
		
		mesh.uv = uvSwap;
	}
}