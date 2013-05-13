using UnityEngine;
using System.Collections;

public class Layer : LayerBase {
	
	private RotateState mRotateState	=	RotateState.rotateUP;
	
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
												"Goal",
												"Player"
											};
	
	public int Number{
		get{return mLayerNumber;}
		set{mLayerNumber = value;}
	}
	
	public void ChangeIntensity(bool b){
		for(int i=0; i<mTileList.Count; i++){
			mTileList[i].GetComponent<Tile>().ChangeIntensity(b);
		}
	}
	
	public void ChangeTile(int tileX, int tileY, TileType type){
		string materialPath = mMatPath + mMatNameList[(int)type];
		
		if(type == TileType.tileBlock){
			materialPath = materialPath + mLayerNumber;
		}
		
		int x = 0;
		int y = 0;
		
		switch(mRotateState){
		case RotateState.rotateUP:
			x = tileX;
			y = tileY;
			break;
		case RotateState.rotateRIGHT:
			x = 9 - tileY;
			y = tileX;
			break;
		case RotateState.rotateDOWN:
			x = 9 - tileX;
			y = 9 - tileY;
			break;
		case RotateState.rotateLEFT:
			x = tileY;
			y = 9 - tileX;
			break;
		}
		
		int tileNum = x + y*10;
		
		Tile tile = mTileList[tileNum].GetComponent<Tile>();
		
		if(tile.mTileType != type){
			tile.ChangeMaterial(materialPath, type);
	
			if(type == TileType.tileNone){
				mTileList[tileNum].transform.localRotation = new Quaternion();
			}
		}
	}
	
	public void ClearTiles(){		
		transform.localRotation = new Quaternion();
		mRotateState = RotateState.rotateUP;
		
		for(int i=0; i<10; i++){
			for(int j=0; j<10; j++){
				ChangeTile(i,j, TileType.tileNone);
			}
		}
	}
	
	public void RotateTile(int tileX, int tileY){
		
		int x=0,y=0;
		
		switch(mRotateState){
		case RotateState.rotateUP:
			x = tileX;
			y = tileY;
			break;
		case RotateState.rotateRIGHT:
			x = 9 - tileY;
			y = tileX;
			break;
		case RotateState.rotateDOWN:
			x = 9 - tileX;
			y = 9 - tileY;
			break;
		case RotateState.rotateLEFT:
			x = tileY;
			y = 9 - tileX;
			break;
		}
		
		int tileNum = x + y*10;
		
		mTileList[tileNum].transform.Rotate(new Vector3(0,0,-90.0f),Space.Self);
	}
	
	public void RotateRight(){
		if(mRotateState == RotateState.rotateLEFT){
			mRotateState = RotateState.rotateUP;
		}else{
			mRotateState++;
		}
		
		transform.Rotate(new Vector3(0,0,-90.0f),Space.Self);
	}
	
	public void RotateLeft(){
		if(mRotateState == RotateState.rotateUP){
			mRotateState = RotateState.rotateLEFT;
		}else{
			mRotateState--;
		}
		
		transform.Rotate(new Vector3(0,0,90.0f),Space.Self);
	}
	
	public void ChangeVisible(bool b){
		for(int i=0; i<mTileList.Count; i++){
			mTileList[i].GetComponent<Tile>().ChangeVisible(b);
		}
	}
	
}
