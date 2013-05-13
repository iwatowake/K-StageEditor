using UnityEngine;
using System.Collections;

public class Shortcut_LayerCheckBox : SingletonMonoBehaviour<Shortcut_LayerCheckBox> {

	public	UICheckbox[]	mCheckBoxes	=	null;
	
	public	void	LayerSelectShortcut(int layerNum){
		mCheckBoxes[layerNum].isChecked = true;
	}
}
