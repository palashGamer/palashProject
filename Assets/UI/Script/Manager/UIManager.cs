using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.palash.lineZen.gamePlay;

namespace com.palash.lineZen.UI{

	[RequireComponent(typeof(UIZone))]
	public partial class UIManager : MonoBehaviour {

		public static UIManager instance;

		void Awake()
		{
			//assigning singleton
			if (instance != null && instance != this)
				Destroy (this.gameObject);

			if (instance == null)
				instance = GetComponent<UIManager> ();

			DontDestroyOnLoad (this.gameObject);
		}

		UIZone _mZone;
		UIZone mZone{
			get{ 
				if (_mZone == null)
					_mZone = GetComponent<UIZone> ();

				return _mZone;
			}
		}

		void Start()
		{
			GameManager.instance.AddUseruserGameStatus (this);
		}

		public void HandleGameLaunchTasks()
		{
			ActivateSelf (true);
			mZone.menuManager.HandleGameLaunchTasks ();
		}
		 void ActivateSelf(bool activateStatus)
		{
			this.gameObject.SetActive (activateStatus);
		}

	}
	#region UI_Button_Controllers
	public partial class UIManager{

		public void PauseButtonClicked()
		{
			GameManager.instance.PauseGame ();
		}
		public void settingsBackButtonClicked()
		{
			mZone.settingsManager.gameObject.SetActive (false);
			mZone.menuManager.gameObject.SetActive (true);
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

}
