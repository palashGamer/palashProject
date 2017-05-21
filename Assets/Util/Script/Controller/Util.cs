using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using com.palash.lineZen.gamePlay;
#if UNITY_EDITOR
using UnityEditor;

namespace com.palash.lineZen.util
{
	public static class Util {

		[UnityEditor.MenuItem("Palash/ScriptableObject/ItemsData")]
		public static void GetItemsData(){
			
			UnityEditor.Selection.activeObject = LoadScriptableObject<ItemsData> ("Assets/Play/Scripts/Data/Resources.asset");

		}

		[UnityEditor.MenuItem("Palash/ClearPlayerprefs")]
		public static void ClearPlayerprefs(){
			PlayerPrefs.DeleteAll ();
			EditorUtility.DisplayDialog ("Playerprefs deleted", "Playerprefs successfully deleted", "OK dude");
		}

		public static T LoadScriptableObject<T>(string assetPath) where T : ScriptableObject
		{
			string typeName = typeof(T).Name;

			T instance = Resources.Load (typeName) as T;

			if (instance == null) {
				instance = ScriptableObject.CreateInstance<T> ();
				#if UNITY_EDITOR
				AssetDatabase.CreateAsset (instance, assetPath);
				#endif
			}
			return instance;
		}
			
	}
}
#endif
