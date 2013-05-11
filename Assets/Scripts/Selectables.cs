using UnityEngine;
using System.Collections;


public class Selectables : LayerBase {
	
	void Start(){
		AllocateTiles();
		for(int i=0; i<mTileList.size; i++){
			mTileList[i].tag = "Selectable";
		}
	}
	
}