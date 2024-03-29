using Boomlagoon.JSON;
using UnityEngine;
using System.Collections;

public class Layer : LayerBase {
	
	private RotateState mRotateState	=	RotateState.rotateUP;
	
	private	int			mLayerNumber	=	0;
	private int			mBlockKind		=	0;
	
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
	
	public int BlockKind{
		get{return mBlockKind;}
		set{mBlockKind = value;}
	}
	
	public void ChangeIntensity(bool b){
		for(int i=0; i<mTileList.Count; i++){
			mTileList[i].GetComponent<Tile>().ChangeIntensity(b);
		}
	}
	
	public void ChangeTile(int tileX, int tileY, TileType type){
		string materialPath = mMatPath + mMatNameList[(int)type];
		
		if(type == TileType.tileBlock){
			materialPath = materialPath + mBlockKind;
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
		
		mTileList[tileNum].GetComponent<Tile>().Rotate();
	}
	
	public void RotateRight(){
		if(mRotateState == RotateState.rotateLEFT){
			mRotateState = RotateState.rotateUP;
		}else{
			mRotateState++;
		}
		
		for(int i=0; i<mTileList.Count; i++){
			Tile tile = mTileList[i].GetComponent<Tile>();
			Vector2 tmp = tile.mPos;
			tile.mPos.x = tmp.y;
			tile.mPos.y = 9-tmp.x;
		}
		
		transform.Rotate(new Vector3(0,0,-90.0f),Space.Self);
	}
	
	public void RotateLeft(){
		if(mRotateState == RotateState.rotateUP){
			mRotateState = RotateState.rotateLEFT;
		}else{
			mRotateState--;
		}
		
		for(int i=0; i<mTileList.Count; i++){
			Tile tile = mTileList[i].GetComponent<Tile>();
			Vector2 tmp = tile.mPos;
			tile.mPos.x = 9-tmp.y;
			tile.mPos.y = tmp.x;
		}
		
		transform.Rotate(new Vector3(0,0,90.0f),Space.Self);
	}
	
	public void ChangeVisible(bool b){
		for(int i=0; i<mTileList.Count; i++){
			mTileList[i].GetComponent<Tile>().ChangeVisible(b);
		}
	}
	
	public JSONObject CreateJsonData(){
		
		int					itemNum		= 0;
		
		Vector2				playerPos	= new Vector2(-1,-1);
		Vector2				goalPos		= new Vector2(-1,-1);
		Vector2				crystalPos  = new Vector2(-1,-1);
		BetterList<Vector2>	blockPos 	= new BetterList<Vector2>();
		BetterList<Vector2> lampPos	 	= new BetterList<Vector2>();
		BetterList<Vector2> genPos	 	= new BetterList<Vector2>();
		BetterList<Tile> 	circuit		= new BetterList<Tile>();
		
		for(int i=0; i<mTileList.Count; i++){
			Tile tile = mTileList[i].GetComponent<Tile>();
			
			switch(tile.mTileType){

			case TileType.tileNone:
				break;

			case TileType.tileBlock:
				itemNum++;
				blockPos.Add(tile.mPos);
				break;
				
			case TileType.tileCircuit_St:
			case TileType.tileCircuit_L:
			case TileType.tileCircuit_T:
			case TileType.tileCircuit_Cr:
				itemNum++;
				circuit.Add(tile);
				break;
				
			case TileType.tileGenerator:
				itemNum++;
				genPos.Add(tile.mPos);
				break;
				
			case TileType.tileLamp:
				itemNum++;
				lampPos.Add(tile.mPos);
				break;
				
			case TileType.tileCrystal:
				itemNum++;
				crystalPos = tile.mPos;
				break;
				
			case TileType.tileGoal:
				itemNum++;
				goalPos = tile.mPos;
				break;
				
			case TileType.tilePlayer:
				itemNum++;
				playerPos = tile.mPos;
				break;
			}
		}
		
		JSONObject	layerJson = new JSONObject();
		
		// block
		JSONArray	blockArray = new JSONArray();
		for(int i=0; i<blockPos.size; i++){
			JSONObject	pos = new JSONObject();
			pos.Add("x",blockPos[i].x);
			pos.Add("y",blockPos[i].y);
			blockArray.Add(pos);
		}
		
		// circuit
		JSONArray	circuitArray = new JSONArray();
		for(int i=0; i<circuit.size; i++){
			JSONObject	data = new JSONObject();
			
			// type & dir
			int type = 0;
			
			switch(circuit[i].mTileType){
			case TileType.tileCircuit_St:
				type = 0;
				break;
			case TileType.tileCircuit_L:
				type = 1;
				break;
			case TileType.tileCircuit_T:
				type = 2;
				break;
			case TileType.tileCircuit_Cr:
				type = 3;
				break;
			}
			
			data.Add("type",type);
			data.Add("dir",(int)circuit[i].mRotateState);
			
			// pos
			JSONObject pos = new JSONObject();
			pos.Add("x",circuit[i].mPos.x);
			pos.Add("y",circuit[i].mPos.y);
			
			data.Add("pos",pos);
			
			// add to array
			circuitArray.Add(data);
		}
		
		// lamp
		JSONArray	lampArray = new JSONArray();
		for(int i=0; i<lampPos.size; i++){
			JSONObject pos = new JSONObject();
			pos.Add("x", lampPos[i].x);
			pos.Add("y", lampPos[i].y);
			
			lampArray.Add(pos);
		}
		
		// gen
		JSONArray	genArray = new JSONArray();
		for(int i=0; i<genPos.size; i++){
			JSONObject pos = new JSONObject();
			pos.Add("x", genPos[i].x);
			pos.Add("y", genPos[i].y);
			
			genArray.Add(pos);
		}
		
		// player
		if(playerPos.x != -1){
			JSONObject	player = new JSONObject();
			player.Add("x",playerPos.x);
			player.Add("y",playerPos.y);
			layerJson.Add("player", player);
		}
		
		// goal
		if(goalPos.x != -1){
			JSONObject	goal = new JSONObject();
			goal.Add("x",goalPos.x);
			goal.Add("y",goalPos.y);
			layerJson.Add("goal", goal);
		}
		
		// crystal
		if(crystalPos.x != -1){
			JSONObject	crystal = new JSONObject();
			crystal.Add("x",crystalPos.x);
			crystal.Add("y",crystalPos.y);
			layerJson.Add("crystal", crystal);
		}
		
		layerJson.Add("block", blockArray);
		layerJson.Add("circuit", circuitArray);
		layerJson.Add("lamp", lampArray);
		layerJson.Add("gen", genArray);
		
		if(itemNum == 0){
			return null;
		}else{
			return layerJson;
		}
	}
	
	public void LoadfromJSON(JSONObject layerJson){
		ClearTiles();
		InitTilePos();
		
		JSONObject playerJson = layerJson.GetObject("player");
		if(playerJson != null){
			Vector2 playerPos= new Vector2((float)playerJson.GetNumber("x"),(float)playerJson.GetNumber("y"));
			ChangeTile((int)playerPos.x, (int)playerPos.y, TileType.tilePlayer);
		}
		
		JSONObject goalJson = layerJson.GetObject("goal");
		if(goalJson != null){
			Vector2 goalPos= new Vector2((float)goalJson.GetNumber("x"),(float)goalJson.GetNumber("y"));
			ChangeTile((int)goalPos.x, (int)goalPos.y, TileType.tileGoal);
		}
		
		JSONObject crystalJson = layerJson.GetObject("crystal");
		if(crystalJson != null){
			Vector2 crystalPos= new Vector2((float)crystalJson.GetNumber("x"),(float)crystalJson.GetNumber("y"));
			ChangeTile((int)crystalPos.x, (int)crystalPos.y, TileType.tileCrystal);
		}
		
		JSONArray blockArray = layerJson.GetArray("block");
		for(int i=0; i<blockArray.Length; i++){
			JSONObject blockJson = blockArray[i].Obj;
			Vector2 blockPos = new Vector2((float)blockJson.GetNumber("x"),(float)blockJson.GetNumber("y"));
			ChangeTile((int)blockPos.x, (int)blockPos.y, TileType.tileBlock);
		}
		
		JSONArray genArray = layerJson.GetArray("gen");
		for(int i=0; i<genArray.Length; i++){
			JSONObject genJson = genArray[i].Obj;
			Vector2 genPos = new Vector2((float)genJson.GetNumber("x"),(float)genJson.GetNumber("y"));
			ChangeTile((int)genPos.x, (int)genPos.y, TileType.tileGenerator);
		}
		
		JSONArray lampArray = layerJson.GetArray("lamp");
		for(int i=0; i<lampArray.Length; i++){
			JSONObject lampJson = lampArray[i].Obj;
			Vector2 lampPos = new Vector2((float)lampJson.GetNumber("x"),(float)lampJson.GetNumber("y"));
			ChangeTile((int)lampPos.x, (int)lampPos.y, TileType.tileLamp);
		}
		
		JSONArray circuitArray = layerJson.GetArray("circuit");
		for(int i=0; i<circuitArray.Length; i++){
			JSONObject circuitJson	= circuitArray[i].Obj;
			JSONObject posJson		= circuitJson.GetObject("pos");
			Vector2 circuitPos = new Vector2((float)posJson.GetNumber("x"),(float)posJson.GetNumber("y"));
			
			int type = (int)circuitJson.GetNumber("type");
			int dir  = (int)circuitJson.GetNumber("dir");
			
			TileType tileType = (TileType)((int)TileType.tileCircuit_St + type);
			
			ChangeTile((int)circuitPos.x, (int)circuitPos.y, tileType);
			for(int j=0; j<dir; j++){
				RotateTile((int)circuitPos.x, (int)circuitPos.y);
			}
		}
		
	}
}
