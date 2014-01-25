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
	
		protected bool _isEnabled;
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
				//TODO verificar o pause
				//Pause.ispaused
				return true;
			}
		}

	//------------------------------------------------------------------------------
	// FUNCTIONS
	//------------------------------------------------------------------------------

	/// <summary>
	/// Funçao disparada sempre que o jogo for parado ou continuado.
	/// </summary>
	/// <param name="pause">Se o jogo for parado <c>true</c>, se o jogo for continuado <c>false</c> .</param>
	public abstract void onPause(bool pause);
}

