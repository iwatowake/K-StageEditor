using UnityEngine;
using System.Collections;

public class KeyboardShortCuts : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.S)){
			LayerManager.Instance.RotateLayer_Left();
		}
		if(Input.GetKeyDown(KeyCode.F)){
			LayerManager.Instance.RotateLayer_Right();
		}
		if(Input.GetKeyDown(KeyCode.E)){
			LayerManager.Instance.ChangeVisibleShortcut();
		}
		
		TileShortcut();
		
		LayerShortcut();
		
		if(Input.GetKeyDown(KeyCode.Delete)){
			if(LayerManager.Instance.CurrentLayer == 0){
				LayerManager.Instance.ClearMainLayer();
			}else{
				LayerManager.Instance.ClearLayer();
			}
		}
	}
	
	void TileShortcut(){
		if(Input.GetKeyDown(KeyCode.X)){
			TileType type = LayerManager.Instance.CurrentTile;
			if(type == TileType.tileNone){
				type = TileType.tilePlayer;
			}else{
				type--;
			}
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(type);
		}
		if(Input.GetKeyDown(KeyCode.V)){
			TileType type = LayerManager.Instance.CurrentTile;
			if(type == TileType.tilePlayer){
				type = TileType.tileNone;
			}else{
				type++;
			}
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(type);
		}
		/*
		if(Input.GetKeyDown(KeyCode.Q)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileNone);
		}
		if(Input.GetKeyDown(KeyCode.W)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileBlock);
		}
		if(Input.GetKeyDown(KeyCode.E)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileCircuit_St);
		}
		if(Input.GetKeyDown(KeyCode.R)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileCircuit_L);
		}
		
		if(Input.GetKeyDown(KeyCode.T)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileCircuit_T);
		}
		if(Input.GetKeyDown(KeyCode.Y)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileCircuit_Cr);
		}
		if(Input.GetKeyDown(KeyCode.U)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileGenerator);
		}
		if(Input.GetKeyDown(KeyCode.I)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileLamp);
		}

		if(Input.GetKeyDown(KeyCode.O)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileCrystal);
		}
		if(Input.GetKeyDown(KeyCode.P)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tileGoal);
		}
		if(Input.GetKeyDown(KeyCode.At)){
			Shortcut_TileCheckBox.Instance.TileSelectShortcut(TileType.tilePlayer);
		}
		*/
	}
	
	void LayerShortcut(){
		if(Input.GetKeyDown(KeyCode.W)){
			int num = LayerManager.Instance.CurrentLayer;
			if(num == 0){
				num = 5;
			}else{
				num--;
			}
			Shortcut_LayerCheckBox.Instance.LayerSelectShortcut(num);
		}
		if(Input.GetKeyDown(KeyCode.R)){
			int num = LayerManager.Instance.CurrentLayer;
			if(num == 5){
				num = 0;
			}else{
				num++;
			}
			Shortcut_LayerCheckBox.Instance.LayerSelectShortcut(num);
		}
		/*
		if(Input.GetKeyDown("1")){
			Shortcut_LayerCheckBox.Instance.LayerSelectShortcut(0);
		}
		if(Input.GetKeyDown("2")){
			Shortcut_LayerCheckBox.Instance.LayerSelectShortcut(1);
		}
		if(Input.GetKeyDown("3")){
			Shortcut_LayerCheckBox.Instance.LayerSelectShortcut(2);
		}
		if(Input.GetKeyDown("4")){
			Shortcut_LayerCheckBox.Instance.LayerSelectShortcut(3);
		}
		if(Input.GetKeyDown("5")){
			Shortcut_LayerCheckBox.Instance.LayerSelectShortcut(4);
		}
		if(Input.GetKeyDown("6")){
			Shortcut_LayerCheckBox.Instance.LayerSelectShortcut(5);
		}
		*/
	}
}
