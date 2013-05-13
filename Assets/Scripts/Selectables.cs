using UnityEngine;
using System.Collections;


public class Selectables : LayerBase {
	
	void Start(){
		AllocateTiles();
		for(int i=0; i<mTileList.Count; i++){
			mTileList[i].transform.FindChild("TilePlane").tag = "Selectable";
		}
	}
	
}