using UnityEngine;
using System.Collections;

public class List_AreaSelect : MonoBehaviour {

	public UIPopupList	mList	 =	null;
	bool	mEnable	 =	false;
	
	void Update(){
		bool	nowEnable = mList.isAnimated;
		
		if(nowEnable != mEnable){
			CameraScript.Instance.mCanPut = mEnable;
			mEnable = nowEnable;
		}
	}
}
