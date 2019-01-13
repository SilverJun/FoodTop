using UnityEngine;
using System.Collections;

public class PlayBtn : UI
{
	[SerializeField] private InGameManager _game;
    [SerializeField] private MainMenu _menu;

	private void Start()
	{
		_game = GameObject.FindWithTag("InGameManager").GetComponent<InGameManager>();
	}

	public void Callback()
    {
        UIManager.CloseUI(_menu);

		Debug.Log(_game);
		_game.StartGame();
    }
}
