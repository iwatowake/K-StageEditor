using UnityEngine;
using System.Collections;

//============================================
/*!
 *	@brief	Material用拡張メソッド群
 *
 *	@date	2013/05/02
 *	@author	Daisuke Kojima
 */
//============================================
public static class MaterialExtension
{
	// ********** Color **********
	
	/*! Material.color.aを直接セット可能にする */
	public static void SetAlpha(this Color color, float a){
		Color newColor =
			new Color(color.r, color.g, color.b, a);
		
		color = newColor;
	}
	
	/*! Material.color.rを直接セット可能にする */
	public static void SetRed(this Color color, float r){
		Color newColor =
			new Color( r, color.g, color.b, color.a);
		
		color = newColor;
	}
	
	/*! Material.color.gを直接セット可能にする */
	public static void SetGreen(this Color color, float g){
		Color newColor =
			new Color( color.r, g, color.b, color.a);
		
		color = newColor;
	}
	
	/*! Material.color.bを直接セット可能にする */
	public static void SetBlue(this Color color, float b){
		Color newColor =
			new Color( color.r, color.g, b, color.a);
		
		color = newColor;
	}
	
	
	// ********** mainTexture *********
	
	/*! Material.mainTexture.offset.xを直接セット可能にする */
	public static void SetMainTextureOffset_X(this Material material, float x){
		Vector2 newOffset =
			new Vector2( x, material.mainTextureOffset.y);
		
		material.mainTextureOffset = newOffset;
	}
	
	/*! Material.mainTexture.offset.yを直接セット可能にする */
	public static void SetMainTextureOffset_Y(this Material material, float y){
		Vector2 newOffset =
			new Vector2( material.mainTextureOffset.x, y);
		
		material.mainTextureOffset = newOffset;
	}

}