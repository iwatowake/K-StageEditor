using Boomlagoon.JSON;
using UnityEngine;
using System.Collections;
using System.IO;

public class Save : MonoBehaviour {
	
	public	UIInput		mInput		= null;
	public	UIPopupList	mPopList	= null;
	
	void OnClick(){
		SaveExec();
	}
	
	
	void SaveExec(){
		JSONObject json = LayerManager.Instance.CreateJsonData();
		
		if(json != null){
			
			string area			= mPopList.selection;
			string stagename	= mInput.text;
			
			Directory.CreateDirectory(Application.dataPath + "/StageData/" + stagename);
			
			Application.CaptureScreenshot(Application.dataPath + "/StageData/" + stagename + "/" + stagename + ".png");
			
			json.Add("name", stagename);
			
			switch(area){
			case "Area1":
				json.Add("area", 1);
				break;
			case "Area2":
				json.Add("area", 2);
				break;
			case "Area3":
				json.Add("area", 3);
				break;
			case "Area4":
				json.Add("area", 4);
				break;
			}
			
			
			FileInfo fi = new FileInfo(Application.dataPath + "/StageData/" + stagename + "/" + stagename + ".txt");
			
			StreamWriter sw = fi.AppendText();
			sw.WriteLine(json.ToString());
			sw.Flush();
			sw.Close();
		}
	}
	
}
