using UnityEngine;
using System.Collections;

public class CheckBox_TileSelect : CheckBoxBase {
	
	public	TileType	mTileType = TileType.tileNone;
	
	protected override void OnChecked ()
	{
		LayerManager.Instance.SetCurrentTile(mTileType);
	}
	
}
