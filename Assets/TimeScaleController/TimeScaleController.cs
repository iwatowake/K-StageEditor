using UnityEngine;
using System.Collections;

//=================================================
/*!
 *	@brief	早送り & スローモーションを司るクラス
 *
 *	@date	2013/05/05
 *	@author	Daisuke Kojima
 */
 //================================================
public class TimeScaleController : SingletonMonoBehaviour<TimeScaleController> {
	
	//=================================================
	/*!
	 *	@brief	UnityEngine.Time内の時間の流れをn倍速にする(呼び出し用)
	 *
	 *			StartCoroutineをラッピングするためのメソッド.
	 *
	 *	@param	speed	UnityEngine.Time内の時間を何倍速にするか
	 *			time	現実時間で何秒の間行うか
	 *	@date	2013/05/05
	 *	@author	Daisuke Kojima
	 */
	 //================================================
	public void WitchTime(float speed, float time){
		StartCoroutine(Coroutine_WitchTime(speed,time));
	}
	
	//=================================================
	/*!
	 *	@brief	UnityEngine.Time内の時間の流れをn倍速にする
	 *
	 *	@param	speed	UnityEngine.Time内の時間を何倍速にするか
	 *			time	現実時間で何秒の間行うか
	 *	@date	2013/05/05
	 *	@author	Daisuke Kojima
	 */
	 //================================================
	protected IEnumerator Coroutine_WitchTime(float speed, float time){
		Time.timeScale = speed;
		
		yield return new WaitForSeconds(time*speed);
		
		Time.timeScale = 1.0f;
	}
}
