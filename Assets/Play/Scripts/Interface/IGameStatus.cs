namespace com.palash.lineZen.gamePlay{
	public interface IGameStatus  {

		void OnGameStart();
		void OnGameOver();
		void OnGamePause();
		void OnGameContinue ();//this means starting again from pause
	}
}
