using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.palash.lineZen.gamePlay;
using com.palash.lineZen.UI;

namespace com.palash.lineZen.gamePlay
{
	[RequireComponent(typeof(GameZone))]
	public partial class GameManager : MonoBehaviour {

		#region myZone
		GameZone _mZone;
		GameZone mZone{
			get{ 
				if (_mZone == null) {
					_mZone = GetComponent<GameZone> ();
				}
				return _mZone;
			}
		}
		#endregion

		#region GameStatusListener
		List<IGameStatus> userGameStatus = new List<IGameStatus>();
		public void AddUseruserGameStatus(IGameStatus input){
			if (!userGameStatus.Contains (input)) {
				userGameStatus.Add (input);
			}
		}
		#endregion

		#region public parameter
		public static GameManager instance;
		#endregion

		#region Unity's start callbacks
		void Awake()
		{
			//assigning singleton
			if (instance != null && instance != this)
				Destroy (this.gameObject);

			if (instance == null)
				instance = GetComponent<GameManager> ();

			DontDestroyOnLoad (this.gameObject);

		}
		void Start()
		{
			HandleGameLaunchTasks ();
			createDefaultRoads ();
		}
		#endregion

		#region GameStatus Handlers
		public void StartGame()
		{
			GameConstants.gameStatus = GameStatus.GameRunning;
			setActiveBall (true);
			userGameStatus.ForEach (x => x.OnGameStart ());
		}
		public void FinishGame()
		{
			mZone.ResetZone ();
			DestroyOlderPaths ();
			DestroyOlderSOS ();
			userGameStatus.ForEach (x => x.OnGameOver ());

			createDefaultRoads ();
		}

		void createDefaultRoads()
		{
			mZone.lastSpawnedObj = mZone.defaultSpawnedObj;
			mZone.lastSpawnedObj.GetComponent<ShapeManager> ().setNextSpawnPos ();

			for (int count = 0; count < 2; count++) {
				spawn ();
			}
		}
		public void ContinueGame()
		{
			
			setActiveBall (true);
			GameConstants.gameStatus = GameStatus.GameRunning;
			userGameStatus.ForEach (x => x.OnGameContinue ());

		}
		public void PauseGame()
		{
			setActiveBall (false);
			GameConstants.gameStatus = GameStatus.GamePaused;
			userGameStatus.ForEach (x => x.OnGamePause ());

		}
		#endregion

		#region path-spawn & blastBall methods
		/// <summary>
		/// Spawn a new path
		/// </summary>
		public void spawn()
		{
			if (GameConstants.gameStatus == GameStatus.GamePaused)
				return;

			//Instantiate new path
			ShapeManager shapeManager = Instantiate<GameObject> (Resources.Load ("Path_"+Random.Range(0,6)) as GameObject).GetComponent<ShapeManager>();
			mZone.lastSpawnedObj = shapeManager.gameObject;

			//set new path's initials
			shapeManager.transform.SetParent (this.transform,false);
			shapeManager.transform.position = new Vector3 (shapeManager.transform.position.x, mZone.nextSpawnY, shapeManager.transform.position.z);
			shapeManager.transform.position += new Vector3 (0,-0.2f,0);

			//new path's intial required tasks
			shapeManager.GenerateSOSrandomly (mZone.sosPrefab);
			mZone.PathListGenerated.Add (shapeManager.gameObject);
			shapeManager.setNextSpawnPos ();
		}
		public void SetNextSpawnPos(float yPos)
		{
			mZone.nextSpawnY = yPos;
		}

		/// <summary>
		/// Enable the blast ball.
		/// </summary>
		/// <param name="waitTimer">Wait timer before the blast ball destroyed after instantiation.</param>
		public void setBlastBall (float waitTimer){
			StartCoroutine(HandleBlastBall (waitTimer));

			EnableBall (false);
		}

		/// <summary>
		/// Refreshes the ball difficulty after it returns from the settings screen
		/// </summary>
		public void refreshBallDifficulty()
		{
			mZone.ball.GetComponent<BallMovement> ().CalculateVertHoriSpeed ();
		}
		public void AddInSOSlist(GameObject objToAdd)
		{
			mZone.sosListGenerated.Add (objToAdd);
		}
		#endregion

		#region helper method
		IEnumerator HandleBlastBall(float waitTimer)
		{
			GameObject blastBall = Instantiate<GameObject> (mZone.blastGameObject);
			blastBall.transform.position = mZone.ball.transform.position;
			blastBall.SetActive (true);

			yield return new WaitForSeconds (waitTimer);
			Destroy (blastBall);
		}
		void DestroyOlderPaths()
		{
			int totalPaths = mZone.PathListGenerated.Count;
			for (int count = 0; count < totalPaths; count++) {
				GameObject path = mZone.PathListGenerated [count];
				if (path != null) {
					Debug.LogError ("Destroyed: "+path.name);
					Destroy (path);
				}
			}
			mZone.PathListGenerated.Clear ();
		}
		void DestroyOlderSOS()
		{
			int totalSOS = mZone.sosListGenerated.Count;
			for (int count = 0; count < totalSOS; count++) {
				GameObject SOS = mZone.sosListGenerated [count];
				if (SOS != null) {
					Debug.LogError ("Destroyed SOS: "+SOS.name);
					Destroy (SOS);
				}
			}
			mZone.sosListGenerated.Clear ();
		}
		void HandleGameLaunchTasks()
		{
			saveBallInitialPosition ();
			mZone.ball.SetActive (false);
			UIManager.instance.HandleGameLaunchTasks ();
			mZone.lastSpawnedObj.GetComponent<ShapeManager> ().setNextSpawnPos ();
		}
		void setActiveBall(bool activeStatus)
		{
			mZone.ball.SetActive (activeStatus);
			EnableBall (activeStatus);
		}
		void EnableBall(bool activeStatus)
		{
			mZone.ball.GetComponent<SpriteRenderer> ().enabled = activeStatus;
		}
		void saveBallInitialPosition()
		{
			mZone.ballInitialPosition = mZone.ball.transform.position;
			mZone.cameraInitialPosition = mZone.m_camera.transform.position;
		}
		#endregion
	}
		
}
