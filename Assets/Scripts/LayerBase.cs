using UnityEngine;
using System.Collections;

public class LayerBase : MonoBehaviour_Extends {	
	
	// protected
	
	protected			float					mDepth					=	-1;								// レイヤのZ値
	
	protected	const	int						cs_GLIDMAX				=	10;								// グリッド数
	protected	const	float					cs_GLIDSTARTING_POINT	=	-4.5f;							// グリッド開始位置
	protected	const	float					cs_GLIDUNIT				=	1.0f;							// グリッド一個分の距離
	
	protected			BetterList<GameObject>	mTileList				=	new BetterList<GameObject>();	// レイヤ内のタイルのリスト
	
	public void SetDepth(float depth){
		transform.SetPosZ(depth);
	}
	
	public void AllocateTiles(){
		for(int i=0; i<cs_GLIDMAX; i++)
		{
			for(int j=0; j<cs_GLIDMAX; j++){
				float x = cs_GLIDSTARTING_POINT + cs_GLIDUNIT * j;
				float y = cs_GLIDSTARTING_POINT + cs_GLIDUNIT * i;
				GameObject go = InstantiateGameObjectAsChild("Prefabs/TileBase",new Vector3(x, y, 0));
				go.transform.SetScaleAll(0.083f);
				go.name = "x"+j+"y"+i;
				mTileList.Add(go);
			}
		}		
	}
	
}
