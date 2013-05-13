using UnityEngine;
using System.Collections;

public class VCButtonFuncs : MonoBehaviour {
	
	public	int	mLayerNumber = 0;
	
	public void Rot_L(){
		LayerManager.Instance.RotateLayer_Left(mLayerNumber);
	}
	
	public void Rot_R(){
		LayerManager.Instance.RotateLayer_Right(mLayerNumber);
	}
	
	public void Clear(){
		LayerManager.Instance.ClearLayer(mLayerNumber);
	}
}
