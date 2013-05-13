using UnityEngine;
using System.Collections;

public class ViewCheckBox : SingletonMonoBehaviour<ViewCheckBox> {

	public UICheckbox[]	mCheckBoxes = null;
	
	public void ChangeVisibleShortcut(int layerNum){
		mCheckBoxes[layerNum].isChecked = !(mCheckBoxes[layerNum].isChecked);
	}
}
