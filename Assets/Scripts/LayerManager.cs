using Boomlagoon.JSON;
using UnityEngine;
using System.Collections;

/*! メインルームのレイヤーとヴィジョンカードを管理するクラス */
public class LayerManager : SingletonMonoBehaviour<LayerManager> {
	
	private			Layer[]			mMainroomLayerList		= null;					//!< メインルームのレイヤー
	public			Layer[]			mVisionCardList			= null;					//!< ヴィジョンカード
	
	private		const	int			cs_LAYERMAX				= 6;					//!< レイヤーの最大数(メインルームそのものを含む)
	
	private				TileType	mCurrentTileType		= TileType.tileNone;	//!< 選択中のタイル
	
	private				int			mCurrentLayer			= 0;					//!< 選択中のレイヤ
	
	protected	const	float		cs_GLIDSTARTING_POINT	= -4.5f;				//!< グリッド幅(絶対値)
	
	protected override void Awake(){
		base.Awake();
		mMainroomLayerList	= new Layer[cs_LAYERMAX];
	}
	
	public int CurrentLayer{
		get{return mCurrentLayer;}
	}
	
	public TileType CurrentTile{
		get{return mCurrentTileType;}
	}
	
	void Start(){
		// レイヤ生成+初期化
		for(int i=0; i<cs_LAYERMAX; i++){
			GameObject go = InstantiateGameObjectAsChild("Prefabs/BlancLayer", new Vector3(0,0,-0.1f*(i+1)));
			go.transform.SetScaleAll(1.0f);
			go.name = "Layer"+i;
			
			mMainroomLayerList[i] = go.GetComponent<Layer>();
			mMainroomLayerList[i].AllocateTiles();
			mMainroomLayerList[i].BlockKind = i;
		}
		
		// ヴィジョンカード初期化
		for(int i=0; i<mVisionCardList.Length; i++){
			mVisionCardList[i].AllocateTiles();
			mVisionCardList[i].Number = i;
			mVisionCardList[i].BlockKind = i+1;
			mVisionCardList[i].SetDepth(-1.0f);
		}
	}
	
	/*! レイヤ内のタイルのマテリアルを変える */
	public void ChangeTile(int tileX, int tileY){
		
		if(mCurrentLayer > 0){
			if((mCurrentTileType == TileType.tileGoal) || (mCurrentTileType == TileType.tilePlayer)){
				return;
			}
		}
		
		mMainroomLayerList[mCurrentLayer].ChangeTile(tileX,tileY,mCurrentTileType);

		if(mCurrentLayer > 0){
			mVisionCardList[mCurrentLayer-1].ChangeTile(tileX,tileY,mCurrentTileType);
		}
	}
	
	/*! レイヤ内のタイルの向きを変える */
	public void RotateTile(int tileX, int tileY){
		mMainroomLayerList[mCurrentLayer].RotateTile(tileX, tileY);

		if(mCurrentLayer > 0){
			mVisionCardList[mCurrentLayer-1].RotateTile(tileX, tileY);
		}
	}
	
	public void RotateLayer_Right(int layer){
		mMainroomLayerList[layer+1].RotateRight();

		mVisionCardList[layer].RotateRight();
	}
	
	public void RotateLayer_Right(){
		if(mCurrentLayer > 0){
			mMainroomLayerList[mCurrentLayer].RotateRight();
	
			mVisionCardList[mCurrentLayer-1].RotateRight();
		}
	}
	
	public void RotateLayer_Left(int layer){
		mMainroomLayerList[layer+1].RotateLeft();

		mVisionCardList[layer].RotateLeft();
	}
	
	public void RotateLayer_Left(){
		if(mCurrentLayer > 0){
			mMainroomLayerList[mCurrentLayer].RotateLeft();
	
			mVisionCardList[mCurrentLayer-1].RotateLeft();
		}
	}
	
	public void ClearMainLayer(){
		mMainroomLayerList[0].ClearTiles();
	}
	
	public void ClearLayer(int layer){
		mMainroomLayerList[layer+1].ClearTiles();
		
		mVisionCardList[layer].ClearTiles();
	}
	
	public void ClearLayer(){
		if(mCurrentLayer > 0){
			mMainroomLayerList[mCurrentLayer].ClearTiles();
	
			mVisionCardList[mCurrentLayer-1].ClearTiles();
		}
	}

	
	public void ClearTile(int tileX, int tileY){
		mMainroomLayerList[mCurrentLayer].ChangeTile(tileX, tileY,TileType.tileNone);

		if(mCurrentLayer > 0){
			mVisionCardList[mCurrentLayer-1].ChangeTile(tileX,tileY,TileType.tileNone);
		}
	}
	
	public void SetCurrentLayer(int layer){
		mMainroomLayerList[mCurrentLayer].ChangeIntensity(false);
		if(mCurrentLayer>0){
			mVisionCardList[mCurrentLayer-1].ChangeIntensity(false);
		}
		
		mMainroomLayerList[layer].ChangeIntensity(true);
		if(layer>0){
			mVisionCardList[layer-1].ChangeIntensity(true);
		}
		
		mCurrentLayer = layer;
	}
	
	public void SetCurrentTile(TileType tile){
		mCurrentTileType = tile;
	}
	
	public void ChangeVisible(int layerNum, bool b){
		mMainroomLayerList[layerNum].ChangeVisible(b);
	}
		
	public void ChangeVisibleShortcut(){
		ViewCheckBox.Instance.ChangeVisibleShortcut(mCurrentLayer);
	}
	
	public JSONObject CreateJsonData(){		
		JSONObject	mainRoomJson = mMainroomLayerList[0].CreateJsonData();
		if(mainRoomJson == null){
			return null;
		}
		
		JSONObject	stageJson  = new JSONObject();
		JSONArray	layerArray = new JSONArray();
		
		for(int i=1; i<mMainroomLayerList.Length; i++){
			JSONObject layer = mMainroomLayerList[i].CreateJsonData();
			if(layer != null){
				layerArray.Add(layer);
			}
		}
		
		stageJson.Add("mainroom", mainRoomJson);
		stageJson.Add("layer", layerArray);
		
		Debug.Log(stageJson.ToString());
		
		return stageJson;
	}
}
