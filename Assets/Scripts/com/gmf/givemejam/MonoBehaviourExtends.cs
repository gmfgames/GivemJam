using UnityEngine;
using System.Collections;

/// <summary>
/// Classe base de todas as classes do game.
/// </summary>
public abstract class MonoBehaviourExtends : MonoBehaviour
{
	/// <summary>
	/// Funçao disparada sempre que o jogo for parado ou continuado.
	/// </summary>
	/// <param name="pause">Se o jogo for parado <c>true</c>, se o jogo for continuado <c>false</c> .</param>
	public abstract void onPause(bool pause);
}

