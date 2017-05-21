using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.gamePlay{
	public class BallCollisionController : MonoBehaviour {

		void OnCollisionStay2D(Collision2D coll)
		{
			//Debug.Log ("stay "+coll.gameObject.name);
		}
		void OnCollisionEnter2D(Collision2D coll)
		{
			Debug.Log ("Enter: "+coll.gameObject.tag);
			if (coll.gameObject.CompareTag (GameConstants.ROAD_TAG) && GameConstants.gameStatus == GameStatus.GameRunning) {
				GameConstants.gameStatus = GameStatus.GameFinished;
				StartCoroutine(blastTheBall ());

			}
		}
		void OnCollisionExit2D(Collision2D coll)
		{
			Debug.Log ("Exit: "+coll.gameObject.name);
		}

		IEnumerator blastTheBall()
		{
			float waitTimer = 1.75f;

			GameManager.instance.setBlastBall (waitTimer);
			yield return new WaitForSeconds (waitTimer);
			GameManager.instance.FinishGame ();
			
		}
	}
}
