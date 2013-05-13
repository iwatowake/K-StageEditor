using UnityEngine;
using System.Collections;

public class Shortcut_TileCheckBox : SingletonMonoBehaviour<Shortcut_TileCheckBox> {
	
	public	UICheckbox[]	mCheckBoxes	=	null;
	
	public	void	TileSelectShortcut(TileType type){
		mCheckBoxes[(int)type].isChecked = true;
	}
}
