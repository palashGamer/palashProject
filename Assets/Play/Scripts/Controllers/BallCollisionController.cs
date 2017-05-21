using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.gamePlay{

	/// <summary>
	/// Ball collision controller. Controls ball collision & hence set method for blast-ball 
	/// </summary>
	public class BallCollisionController : MonoBehaviour {

		#region Physics Callback
		void OnCollisionEnter2D(Collision2D coll)
		{
			Debug.Log ("Enter: "+coll.gameObject.tag);
			if (coll.gameObject.CompareTag (GameConstants.ROAD_TAG) && GameConstants.gameStatus == GameStatus.GameRunning) {
				GameConstants.gameStatus = GameStatus.GameFinished;
				StartCoroutine(blastTheBall ());

			}
		}
		#endregion

		#region helper Methods
		IEnumerator blastTheBall()
		{
			float waitTimer = 1.75f;

			GameManager.instance.setBlastBall (waitTimer);
			yield return new WaitForSeconds (waitTimer);
			GameManager.instance.FinishGame ();
			
		}
		#endregion
	}
}
