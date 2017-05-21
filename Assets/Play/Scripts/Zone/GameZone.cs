using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZone : MonoBehaviour {

	public GameObject ball, camera, lastSpawnedObj, defaultSpawnedObj,blastGameObject, sosPrefab;
	public float nextSpawnY;
	internal Vector3 ballInitialPosition, cameraInitialPosition;
	public List<GameObject>PathListGenerated = new List<GameObject>();
	public List<GameObject>sosListGenerated = new List<GameObject>();
	public void ResetZone()
	{
		ball.transform.position = ballInitialPosition;
		camera.transform.position = cameraInitialPosition;

		ball.gameObject.SetActive (false);
	}
}
