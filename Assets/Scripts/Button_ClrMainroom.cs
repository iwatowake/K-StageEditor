using UnityEngine;
using System.Collections;

public class Button_ClrMainroom : ButtonBase {
	
	protected override void OnClick ()
	{
		LayerManager.Instance.ClearMainLayer();
	}
	
}
