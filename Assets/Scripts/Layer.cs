using UnityEngine;
using System.Collections;

public class Layer : LayerBase {
	
	private	int			mLayerNumber	=	0;
	
	private	string		mMatPath		=	"Materials/Tiles/";
	
	private	string[]	mMatNameList	=	{
												"Selectable",
												"Block_",
												"Circuit_St",
												"Circuit_L",
												"Circuit_T",
												"Circuit_Cr",
												"Generator",
												"Lamp",
												"Crystal",
												"Goal"
											};
	
	public int Number{
		get{return mLayerNumber;}
		set{mLayerNumber = value;}
	}
	
	public void ChangeTile(int tileNumber, TileType type){
		string materialPath = mMatPath + mMatNameList[(int)type];
		
		if(type == TileType.tileBlock){
			materialPath = materialPath + mLayerNumber;
		}
		
		Material mat = Resources.Load(materialPath) as Material;
		
		mTileList[tileNumber].renderer.material = mat;
	}
	
	public void RotateTile(int tileNumber){
		mTileList[tileNumber].transform.Rotate(new Vector3(0,0,90.0f),Space.Self);
	}
	
	public void RotateRight(){
		transform.Rotate(new Vector3(0,0,90.0f),Space.Self);
	}
	
	public void RotateLeft(){
		transform.Rotate(new Vector3(0,0,90.0f),Space.Self);
	}
	
}
