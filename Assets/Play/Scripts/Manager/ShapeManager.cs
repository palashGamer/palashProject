using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.palash.lineZen.UI;

namespace com.palash.lineZen.gamePlay{

	[RequireComponent(typeof(ShapeZone))]
	public class ShapeManager : MonoBehaviour {

		#region myZone
		ShapeZone _mZone;
		ShapeZone mZone{
			get{ 
				if (_mZone == null)
					_mZone = GetComponent<ShapeZone> ();

				return _mZone;
			}
		}
		#endregion

		#region Unity's start callback
		IEnumerator Start()
		{
			int loopIterator = (int)(mZone.barriers.Length * ((GameConstants.difficulty + 0.1f)));
			for (int count = 0; count < loopIterator; count++) {
					MakeBarrierOrSOSRandomly (mZone.barriers [count]);
					mZone.barriers [count].SetActive (true);
					yield return new WaitForSeconds (Random.Range (0.0f, 0.3f));
			}
			yield return 0;
		}
		#endregion

		#region SOS_Barrier handle
		public void GenerateSOSrandomly(GameObject sosPrefab)
		{
			int rand = Random.Range (0,3);
			Vector3 topPosition = mZone.topPosition.position;

			if (rand == 1) {
				int m_Rand = Random.Range (0,4);

				for (int count = 0; count < m_Rand; count++) {
					GameObject sos = Instantiate<GameObject> (sosPrefab);
					sos.transform.position = new Vector3 (topPosition.x + (0.42f * (count-1)), topPosition.y-0.4f, topPosition.z);
					GameManager.instance.AddInSOSlist (this.gameObject);
				}
			}
		}
		void MakeBarrierOrSOSRandomly (GameObject Obj)
		{
			if (Random.Range (0, 2) == 1) {
				Obj.tag = GameConstants.SOS_TAG;
				Obj.GetComponent<SpriteRenderer> ().color = ItemsData.instance.sosColor;
			}
			else{
				Obj.tag = GameConstants.ROAD_TAG;
				Obj.GetComponent<SpriteRenderer> ().color = ItemsData.instance.barrierColor;
			}
		}
		#endregion

		#region Self-Destroy Logic
		IEnumerator MakeInvisible()
		{
			if(GameConstants.gameStatus == GameStatus.GameRunning)
			GameManager.instance.spawn ();

			yield return new WaitForSeconds (7);
			if (!mZone.dontDestroy) {
				Destroy (this.gameObject);
			}
			yield return 0;
		}

		void OnTriggerEnter2D(Collider2D coll)
		{
			if (coll.tag == "Player") {
				StartCoroutine (MakeInvisible());
			}
		}
		#endregion

		#region helper methods
		public Vector3 ReturnTopPosition()
		{
			return mZone.topPosition.position;
		}
		public void setNextSpawnPos()
		{
			GameManager.instance.SetNextSpawnPos (mZone.topPosition.position.y);
		}
		#endregion

	}
}
