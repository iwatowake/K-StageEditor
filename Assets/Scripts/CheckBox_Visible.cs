using UnityEngine;
using System.Collections;

public class CheckBox_Visible : CheckBoxBase {
	
	public	int	mLayerNumber	=	0;
	
	protected override void OnChecked ()
	{
		LayerManager.Instance.ChangeVisible(mLayerNumber, true);
	}
	
	protected override void OnUnChecked ()
	{
		LayerManager.Instance.ChangeVisible(mLayerNumber, false);
	}
}
