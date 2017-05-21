using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.palash.lineZen.gamePlay;

namespace com.palash.lineZen.UI{
	public class ScoreHandler : MonoBehaviour {

		#region public parameters
		public Text score;
		public GameObject HighScorePrefab;
		#endregion

		#region private parameters
		int incrementValue = 1;
		GameObject hScore;
		bool newSession = true;
		#endregion

		#region public methods
		public void StartIncreasingScore()
		{
			newSession = true;
			InvokeRepeating ("IncreaseScore",1,1);
		}
		public void ResetScore()
		{
			GameConstants.Score = 0;
			ShowScore ();
			CancelInvoke ("IncreaseScore");
		}
		#endregion

		#region helper methods
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
				if (newSession && PlayerPrefs.HasKey(GameConstants.BESTSCORE)) {
					hScore = Instantiate<GameObject> (HighScorePrefab);

					hScore.transform.SetParent (this.transform, false);
					Destroy (hScore, 4);

				}
				newSession = false;
				PlayerPrefs.SetInt (GameConstants.BESTSCORE, GameConstants.Score);

			}
		}
		#endregion
	}
}
