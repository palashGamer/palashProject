using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.gamePlay{
	public class ItemsData : ScriptableObject {

		#region myInstance
		static ItemsData _instance;

		public static ItemsData instance{
			get{ 
				if(_instance==null)
					_instance =  Resources.Load ("ItemsData") as ItemsData;

				return _instance;
			}
		}
		#endregion

		[Range(5,15f)]
		public float ballAutoVertSpeedMultiplier = 10f;

		public const float horiSpeedMin = 0.5f;
		public const float horiSpeedMax = 2f;

		[Tooltip("This controls sensitivity of left-right movement")]
		[Range(0.5f,2f)]
		public float horizontalSpeedMultiplier = 1.15f;

		[Tooltip("This defines force when ball blasts")]
		[Range(0.75f,2.5f)]
		public float blastForce = 1.5f;

		public Color barrierColor;
		public Color sosColor;

	}
}
