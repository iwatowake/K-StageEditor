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
	
	void Start(){
		// レイヤ生成+初期化
		for(int i=0; i<cs_LAYERMAX; i++){
			GameObject go = InstantiateGameObjectAsChild("Prefabs/BlancLayer", new Vector3(0,0,-0.1f*(i+1)));
			go.transform.SetScaleAll(1.0f);
			go.name = "Layer"+i;
			
			mMainroomLayerList[i] = go.GetComponent<Layer>();
			mMainroomLayerList[i].AllocateTiles();
		}
		
		// ヴィジョンカード初期化
		for(int i=0; i<mVisionCardList.Length; i++){
			mVisionCardList[i].AllocateTiles();
			mVisionCardList[i].Number = i;
			mVisionCardList[i].SetDepth(-1.0f);
		}
	}
	
	/*! レイヤ内のタイルのマテリアルを変える */
	public void ChangeTile(int tileX, int tileY){
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
	
	public void RotateLayer_Left(int layer){
		mMainroomLayerList[layer+1].RotateLeft();

		mVisionCardList[layer].RotateLeft();
	}
	
	public void ClearLayer(int layer){
		mMainroomLayerList[layer+1].ClearTiles();
		
		mVisionCardList[layer].ClearTiles();
	}
	
	public void SetCurrentLayer(int layer){
		mCurrentLayer = layer;
		Debug.Log(mCurrentLayer);
	}
	
	public void SetCurrentTile(TileType tile){
		mCurrentTileType = tile;
	}
}
