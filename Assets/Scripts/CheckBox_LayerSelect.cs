using UnityEngine;
using System.Collections;

public class CheckBox_LayerSelect : CheckBoxBase {
	
	public int mLayerNum = 0;
	
	protected override void OnChecked ()
	{
		LayerManager.Instance.SetCurrentLayer(mLayerNum);
	}
}
