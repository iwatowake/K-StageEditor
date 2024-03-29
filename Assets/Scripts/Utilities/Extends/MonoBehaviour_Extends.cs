using UnityEngine;
using System.Collections;

//===========================================
/*!
 *	@brief	拡張機能付きMonoBehaviour
 *
 *			便利系機能が追加されたMonoBehaviourです
 *			基本的にMonoBehaviourの代わりにこれを継承して下さい.
 *
 *	@date	2013/05/02
 *	@author	Daisuke Kojima
 */
//===========================================
public class MonoBehaviour_Extends : MonoBehaviour {
	
	
	// ************ Instantiate by a Resource ***********
	
	//===========================================
	/*!
	 *	@brief	リソースからのInstantiateを簡略に行うメソッド
	 *
	 *	@date	2013/05/02
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObject(string resourcepath)
	{
		GameObject go = 
			Instantiate(Resources.Load(resourcepath))as GameObject;
		
		if(go == null)
		{
			Debug.LogError("Expected to find gameobject"+resourcepath+"but found none.");
		}
		
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	リソースからのInstantiateを簡略に行うメソッド(position指定)
	 *
	 *	@date	2013/05/02
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObject(string resourcepath, Vector3 position)
	{
		GameObject go = 
			InstantiateGameObject(resourcepath);
		
		go.transform.position = position;
		
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	リソースからのInstantiateを簡略に行うメソッド(position,rotation指定)
	 *
	 *	@date	2013/05/02
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObject(string resourcepath, Vector3 position, Quaternion rotation)
	{
		GameObject go = 
			InstantiateGameObject(resourcepath);
		
		go.transform.position = position;
		go.transform.rotation = rotation;
		
		return go;
	}
	
	
	
	// ************ Instantiate by a Object ***********
	
	//===========================================
	/*!
	 *	@brief	プレハブからのInstantiateを簡略に行うメソッド
	 *
	 *	@date	2013/05/02
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObject(Object obj)
	{
		GameObject go =
			Instantiate(obj) as GameObject;
		
		if(go == null)
		{
			Debug.LogError("Expected to find gameobject but found none.");
		}
		
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	プレハブからのInstantiateを簡略に行うメソッド(position指定)
	 *
	 *	@date	2013/05/02
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObject(Object obj,Vector3 position)
	{
		GameObject go =
			InstantiateGameObject(obj);
			
		go.transform.position = position;
		
		return go;
	}
	
	
	//===========================================
	/*!
	 *	@brief	プレハブからのInstantiateを簡略に行うメソッド(position, rotation指定)
	 *
	 *	@date	2013/05/02
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObject(Object obj,Vector3 position, Quaternion rotation)
	{
		GameObject go =
			InstantiateGameObject(obj);
			
		go.transform.position = position;
		go.transform.rotation = rotation;
		
		return go;
	}
	

	
	// ************ Instantiate by a Resource (with setting gameObject to transform.parent) ***********
	
	//===========================================
	/*!
	 *	@brief	リソースから生成して子にする
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(string resourcepath){
		GameObject go = InstantiateGameObject(resourcepath);
		go.transform.parent = transform;
		
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	リソースから生成して子にする(position指定)
	 *
	 *			座標は親の座標系での指定となる.
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(string resourcepath, Vector3 position){
		GameObject go = InstantiateGameObjectAsChild(resourcepath);
		go.transform.localPosition = position;
			
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	リソースから生成して子にする(position, rotation指定)
	 *
	 *			座標/回転は親の座標系での指定となる.
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(string resourcepath, Vector3 position, Quaternion rotation){
		GameObject go = InstantiateGameObjectAsChild(resourcepath);
		go.transform.localPosition = position;
		go.transform.localRotation = rotation;
		
		return go;
	}
	
	
	
	// ************ Instantiate by a Resource (with setting target GameObject to transform.parent) ***********
	
	//===========================================
	/*!
	 *	@brief	リソースから生成して, 指定オブジェクトの子にする
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(string resourcepath, GameObject parent){
		GameObject go = InstantiateGameObject(resourcepath);
		go.transform.parent = parent.transform;
		
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	リソースから生成して, 指定オブジェクトの子にする(position指定)
	 *
	 *			座標は親の座標系での指定となる.
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(string resourcepath, GameObject parent, Vector3 position){
		GameObject go = InstantiateGameObjectAsChild(resourcepath, parent);
		go.transform.localPosition = position;
			
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	リソースから生成して, 指定オブジェクトの子にする(position, rotation指定)
	 *
	 *			座標/回転は親の座標系での指定となる.
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(string resourcepath, GameObject parent, Vector3 position, Quaternion rotation){
		GameObject go = InstantiateGameObjectAsChild(resourcepath, parent);
		go.transform.localPosition = position;
		go.transform.localRotation = rotation;
		
		return go;
	}
	
	
	
	// ************ Instantiate by a Object (with setting gameObject to transform.parent) ***********
	
	//===========================================
	/*!
	 *	@brief	プレハブから生成して子にする
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(Object obj){
		GameObject go = InstantiateGameObject(obj);
		go.transform.parent = transform;
		
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	プレハブから生成して子にする(position指定)
	 *
	 *			座標は親の座標系での指定となる.
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(Object obj, Vector3 position){
		GameObject go = InstantiateGameObjectAsChild(obj);
		go.transform.localPosition = position;
		
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	プレハブから生成して子にする(position, rotation指定)
	 *
	 *			座標/回転は親の座標系での指定となる.
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(Object obj, Vector3 position, Quaternion rotation){
		GameObject go = InstantiateGameObjectAsChild(obj);
		go.transform.localPosition = position;
		go.transform.localRotation = rotation;
		
		return go;
	}
	
	
	
	// ************ Instantiate by a Object (with setting target GameObject to transform.parent) ***********
	
	//===========================================
	/*!
	 *	@brief	プレハブから生成して, 指定オブジェクトの子にする
	 *
	 *			座標/回転は親の座標系での指定となる.
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(Object obj, GameObject parent){
		GameObject go = InstantiateGameObject(obj);
		go.transform.parent = parent.transform;
		
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	プレハブから生成して, 指定オブジェクトの子にする(position指定)
	 *
	 *			座標は親の座標系での指定となる.
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(Object obj, GameObject parent, Vector3 position){
		GameObject go = InstantiateGameObjectAsChild(obj,parent);
		go.transform.localPosition = position;
		
		return go;
	}
	
	//===========================================
	/*!
	 *	@brief	プレハブから生成して, 指定オブジェクトの子にする(position, rotation指定)
	 *
	 *			座標/回転は親の座標系での指定となる.
	 *
	 *	@date	2013/05/09
	 *	@author	Daisuke Kojima
	 */
	//===========================================
	public GameObject InstantiateGameObjectAsChild(Object obj, GameObject parent, Vector3 position, Quaternion rotation){
		GameObject go = InstantiateGameObjectAsChild(obj,parent);
		go.transform.localPosition = position;
		go.transform.localRotation = rotation;
		
		return go;
	}
	

}