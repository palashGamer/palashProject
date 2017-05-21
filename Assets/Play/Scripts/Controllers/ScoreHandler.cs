using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.palash.lineZen.UI{
	public class ScoreHandler : MonoBehaviour {

		public Text score;
		int incrementValue = 1;


		public void StartIncreasingScore()
		{
			InvokeRepeating ("IncreaseScore",1,1);
		}
		public void ResetScore()
		{
			GameConstants.Score = 0;
			CancelInvoke ("IncreaseScore");
		}


		void IncreaseScore()
		{
			if (GameConstants.gameStatus == GameStatus.GameRunning) {
				GameConstants.Score += incrementValue;
				ShowScore ();
				checkBestScore ();
			}
		}
		void ShowScore()
		{
			score.text = GameConstants.Score.ToString();
		}
		void checkBestScore()
		{
			if (GameConstants.Score > PlayerPrefs.GetInt (GameConstants.BESTSCORE)) {
				PlayerPrefs.SetInt (GameConstants.BESTSCORE, GameConstants.Score);
			}
		}
	}
}
