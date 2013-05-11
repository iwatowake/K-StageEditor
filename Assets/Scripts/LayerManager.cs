using UnityEngine;
using System.Collections;

/*! メインルームのレイヤーとヴィジョンカードを管理するクラス */
public class LayerManager : SingletonMonoBehaviour<LayerManager> {
	
	private			Layer[]		mMainroomLayerList		= null;			//!< メインルームのレイヤー
	public			Layer[]		mVisionCardList			= null;			//!< ヴィジョンカード
	
	private		const	int		cs_LAYERMAX				= 6;			//!< レイヤーの最大数(メインルームそのものを含む)
	
	protected	const	float	cs_GLIDSTARTING_POINT	=	-4.5f;		//!< グリッド幅(絶対値)
	
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
	public void ChangeTile(int layerNumber, float tileLocalX, float tileLocalY, TileType type ){
		int x = (int)(tileLocalX + 4.5f);
		int y = (int)(tileLocalY + 4.5f);
		
		int tileNum = x + y*10;
		
		mMainroomLayerList[layerNumber].ChangeTile(tileNum,type);

		if(layerNumber > 0){
			mVisionCardList[layerNumber-1].ChangeTile(tileNum,type);
		}
	}
	
	/*! レイヤ内のタイルの向きを変える */
	public void RotateTile(int layerNumber, float tileLocalX, float tileLocalY){
		int x = (int)(tileLocalX + 4.5f);
		int y = (int)(tileLocalY + 4.5f);
		
		int tileNum = x + y*10;
		
		mMainroomLayerList[layerNumber].RotateTile(tileNum);

		if(layerNumber > 0){
			mVisionCardList[layerNumber-1].RotateTile(tileNum);
		}
	}
}
