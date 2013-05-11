using UnityEngine;
using System.Collections;

public class CameraScript : SingletonMonoBehaviour<CameraScript> {

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit = new RaycastHit();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray,out hit)){
				Debug.Log(hit.collider.gameObject.name);
			}
		}
		
		if(Input.GetMouseButtonDown(1)){
			RaycastHit hit = new RaycastHit();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray,out hit)){
				Debug.Log(hit.collider.gameObject.name);
			}
		}
	}
}
