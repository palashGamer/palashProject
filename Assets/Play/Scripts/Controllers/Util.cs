using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


#if UNITY_EDITOR
using UnityEditor;


namespace com.palash.lineZen.util
{
	public static class Util {

		[UnityEditor.MenuItem("Palash/Util/ItemsData")]
		public static void GetItemsData(){
			
			UnityEditor.Selection.activeObject = LoadScriptableObject<ItemsData> ("Assets/Play/Scripts/Data/Resources.asset");

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
