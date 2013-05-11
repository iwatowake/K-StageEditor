using UnityEngine;
using System.Collections;

public class CheckBoxBase : MonoBehaviour {

	protected void OnActivate(){
		if(gameObject.GetComponent<UICheckbox>().isChecked){
			OnChecked();
		}else{
			OnUnChecked();
		}
	}
	
	protected virtual void OnChecked(){

	}
	
	protected virtual void OnUnChecked(){
		
	}
}
