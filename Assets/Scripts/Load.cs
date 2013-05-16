using Boomlagoon.JSON;
using UnityEngine;
using System.Collections;
using System.IO;

public class Load : MonoBehaviour {
	
	public	UIInput		mInput		= null;
	public	UIPopupList	mPopList	= null;
	
	void OnClick(){
		LoadExec();
	}

	void LoadExec(){
		string stagename = mInput.text;
		FileInfo fi = new FileInfo(Application.dataPath + "/StageData/" + stagename + "/" + stagename + ".txt");
		
		StreamReader sr = fi.OpenText();
		string jsonStr = sr.ReadLine();
		JSONObject stageJson = JSONObject.Parse(jsonStr);
		
		int area = (int)stageJson.GetNumber("area");
		
		mPopList.selection = mPopList.items[area-1];
		
		LayerManager.Instance.LoadfromJson(stageJson);
	}
}
