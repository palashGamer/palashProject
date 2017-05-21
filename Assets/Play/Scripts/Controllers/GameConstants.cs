using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants {

	public const string BESTSCORE = "BESTSCORE";
	public const string ROAD_TAG = "Road";
	public const string SOS_TAG = "SOS";

	public static GameStatus gameStatus;
	public static int Score;
}

public enum GameStatus
{
	GameRunning,
	GameFinished,
	GamePaused
}

