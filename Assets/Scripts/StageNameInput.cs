using UnityEngine;
using System.Collections;

public class StageNameInput : MonoBehaviour {
	
	public UIInput	mInput	 =	null;
	bool	mEnable	 =	false;
	
	void Update(){
		bool	nowEnable = mInput.selected;
		
		if(nowEnable != mEnable){
			KeyboardShortCuts.Instance.mCanUse = mEnable;
			mEnable = nowEnable;
		}
	}
	
}
