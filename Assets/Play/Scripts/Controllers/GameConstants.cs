using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.gamePlay{
	public static class GameConstants {

		#region playerpref const
		public const string BESTSCORE = "BESTSCORE";
		public const string SHOWTUT = "SHOWTUT";
		#endregion

		#region Tag_Constants
		public const string ROAD_TAG = "Road";
		public const string SOS_TAG = "SOS";
		#endregion

		#region GamePlay_Constants
		public static GameStatus gameStatus;
		public static int Score;

		//these are randomized value, means 0-1
		public static float sensitivity, difficulty;

		#endregion
	}

	public enum GameStatus
	{
		GameRunning,
		GameFinished,
		GamePaused
	}
}

