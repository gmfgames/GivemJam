using UnityEngine;
using System.Collections;

/// <summary>
/// Classe base de todas as classes do game.
/// </summary>
public abstract class MonoBehaviourExtends : MonoBehaviour
{
	/**********************************************************
	 * PROPRIEDADES
	 **********************************************************/ 
	
		/**------------------------------------------------------------
		 * PUBLICAS
		 **----------------------------------------------------------*/ 
	
	protected bool _isEnabled = true;
		/// <summary>
		/// Propriedade que indica se o componente esta habilitado ou não.
		/// </summary>
		public virtual bool isEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				_isEnabled = value;
			}
		}

		/// <summary>
		/// Indica se o jogo esta parado ou nao.
		/// </summary>
		protected bool isPaused
		{
			get
			{
				return Pause.instance.isPaused;
			}
		}

	/**********************************************************
	 * FUNÇOES
	 **********************************************************/ 

	protected virtual void Awake()
	{
		MessageDispatcher.AddListener<PauseMessage>(PauseMessage.ON_PAUSE_CHANGED, OnPauseChange);
	}

	/// <summary>
	/// Funçao disparada sempre que o jogo for parado ou continuado.
	/// </summary>
	/// <param name="pause">Se o jogo for parado <c>true</c>, se o jogo for continuado <c>false</c> .</param>
	protected abstract void OnPause(bool pause);

	/**********************************************************
	 * EVENTOS
	 **********************************************************/ 

	void OnPauseChange (PauseMessage message)
	{
		OnPause((message as PauseMessage).paused);
	}
}

