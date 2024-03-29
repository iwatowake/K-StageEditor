using UnityEngine;
using System.Collections;

public class CameraScript : SingletonMonoBehaviour<CameraScript> {
	
	public bool mCanPut	= true;
	
	void Update(){
		if(Input.GetMouseButton(0) && mCanPut){
			RaycastHit hit = new RaycastHit();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray,out hit)){
				if(hit.collider.gameObject.tag == "Selectable"){
					
					GameObject go = hit.collider.gameObject.transform.parent.gameObject;
					Vector2 pos = go.GetComponent<Tile>().mPos;
					
					if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
						LayerManager.Instance.ClearTile((int)pos.x, (int)pos.y);
					}else{
						LayerManager.Instance.ChangeTile((int)pos.x, (int)pos.y);
					}
				}
			}
		}
		
		if(Input.GetMouseButtonDown(1)){
			RaycastHit hit = new RaycastHit();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray,out hit)){
				if(hit.collider.gameObject.tag == "Selectable"){
					GameObject go = hit.collider.gameObject.transform.parent.gameObject;
					Vector2 pos = go.GetComponent<Tile>().mPos;
					LayerManager.Instance.RotateTile((int)pos.x, (int)pos.y);
				}
			}
		}
	}
}
