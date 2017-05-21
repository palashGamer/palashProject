using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.palash.lineZen.gamePlay;
using com.palash.lineZen.util;

namespace com.palash.lineZen.UI{

	[RequireComponent(typeof(UIZone))]
	public partial class UIManager : MonoBehaviour {

		public static UIManager instance;
		GameObject tutorial;

		#region myZone
		UIZone _mZone;
		UIZone mZone{
			get{ 
				if (_mZone == null)
					_mZone = GetComponent<UIZone> ();

				return _mZone;
			}
		}
		#endregion

		#region Unity's starting callbacks
		void Awake()
		{
			//assigning singleton
			if (instance != null && instance != this)
				Destroy (this.gameObject);

			if (instance == null)
				instance = GetComponent<UIManager> ();

			DontDestroyOnLoad (this.gameObject);
		}
		void Start()
		{
			GameManager.instance.AddUseruserGameStatus (this);
			UserInput.instance.AddUserInputLstnr (this);
		}
		#endregion


		#region helper methods
		public void HandleGameLaunchTasks()
		{
			ActivateSelf (true);
			mZone.menuManager.HandleGameLaunchTasks ();
		}
		 void ActivateSelf(bool activateStatus)
		{
			this.gameObject.SetActive (activateStatus);
		}
		void showTutorial()
		{
			if (!PlayerPrefs.HasKey (GameConstants.SHOWTUT)) {
				PlayerPrefs.SetInt (GameConstants.SHOWTUT, 1);
				tutorial = Instantiate<GameObject> (mZone.tutorialPrefab);

				tutorial.transform.SetParent (this.transform, false);

			}
		}
		#endregion
	}
	#region UI_Button_Controllers
	public partial class UIManager{

		public void PauseButtonClicked()
		{
			if(GameConstants.gameStatus == GameStatus.GameRunning)
			GameManager.instance.PauseGame ();
		}
		public void settingsBackButtonClicked()
		{
			mZone.settingsManager.gameObject.SetActive (false);
			mZone.menuManager.gameObject.SetActive (true);
			GameManager.instance.refreshBallDifficulty ();
		}
		public void settingsButtonClicked()
		{
			mZone.settingsManager.gameObject.SetActive (true);
			mZone.menuManager.gameObject.SetActive (false);

		}
	}
	#endregion

	#region GameStatus Callbacks
	public partial class UIManager : IGameStatus{
		public void OnGameStart ()
		{
			mZone.scoreHandler.ResetScore ();
			mZone.scoreHandler.StartIncreasingScore ();
			showTutorial ();
		}
		public void OnGamePause ()
		{
			
		}

		public void OnGameContinue ()
		{
			
		}
		public void OnGameOver ()
		{
			
		}
	}
	#endregion

	#region Input callback
	public partial class UIManager : IInput
	{
		public void OnMouseMoved (float deltaX)
		{
			if (tutorial) {
				Destroy (tutorial);
			}
		}
	}
	#endregion

}
