using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public RotateState	mRotateState = RotateState.rotateUP;
	public Vector2		mPos		 = new Vector2();
	public TileType		mTileType	 = TileType.tileNone;
	
	public void ChangeMaterial(string path){
		GameObject plane = transform.FindChild("TilePlane").gameObject;
		
		plane.renderer.material = Resources.Load(path) as Material;
	}

}
