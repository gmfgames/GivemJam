using UnityEngine;
using System.Collections;

/// <summary>
/// Classe base de todas as classes do game.
/// </summary>
public abstract class MonoBehaviourExtends : MonoBehaviour
{
	/// <summary>
	/// Indica se o jogo esta parado ou nao.
	/// </summary>
	protected float isPaused
	{
		get
		{
			//TODO verificar o pause
			//Pause.ispaused
		}
	}

	/// <summary>
	/// Funçao disparada sempre que o jogo for parado ou continuado.
	/// </summary>
	/// <param name="pause">Se o jogo for parado <c>true</c>, se o jogo for continuado <c>false</c> .</param>
	public abstract void onPause(bool pause);
}

