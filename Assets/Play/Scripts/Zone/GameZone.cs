using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.palash.lineZen.gamePlay{
	public class GameZone : MonoBehaviour {

		public GameObject ball, m_camera, lastSpawnedObj, defaultSpawnedObj,blastGameObject, sosPrefab;
		public float nextSpawnY;
		public List<GameObject>PathListGenerated = new List<GameObject>();
		public List<GameObject>sosListGenerated = new List<GameObject>();


		internal Vector3 ballInitialPosition, cameraInitialPosition;

		/// <summary>
		/// Resets the zone.
		/// </summary>
		public void ResetZone()
		{
			ball.transform.position = ballInitialPosition;
			m_camera.transform.position = cameraInitialPosition;

			ball.gameObject.SetActive (false);
		}
	}
}
