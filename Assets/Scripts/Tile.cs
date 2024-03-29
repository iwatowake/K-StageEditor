using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public RotateState	mRotateState = RotateState.rotateUP;
	public Vector2		mPos		 = new Vector2();
	public TileType		mTileType	 = TileType.tileNone;
	
	public void Rotate(){
		if(mRotateState == RotateState.rotateLEFT){
			mRotateState = RotateState.rotateUP;
		}else{
			mRotateState++;
		}
		
		transform.Rotate(new Vector3(0,0,-90.0f),Space.Self);
	}
	
	public void ChangeMaterial(string path, TileType type){
		mTileType = type;
		
		GameObject plane = transform.FindChild("TilePlane").gameObject;
		
		plane.renderer.material = Resources.Load(path) as Material;
	}
	
	public void ChangeIntensity(bool b){
		GameObject plane = transform.FindChild("TilePlane").gameObject;
		if(mTileType != TileType.tileNone){		
			if(b){
				plane.renderer.material.SetColor("_TintColor", new Color(0.6f,0.6f,0.6f,0.6f));
			}else{
				plane.renderer.material.SetColor("_TintColor", new Color(0.4f,0.4f,0.4f,0.3f));
			}
		}
	}
	
	public void ChangeVisible(bool b){
		GameObject plane = transform.FindChild("TilePlane").gameObject;
		plane.renderer.enabled = b;
	}
	
}
