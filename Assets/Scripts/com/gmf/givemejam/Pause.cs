using UnityEngine;
using System.Collections;

/// <summary>
/// Componenete que cuida do sistema de pauser e continuar o jogo.
/// </summary>
public class Pause : MonoBehaviour
{
	#region Properties 
	/**********************************************************
	 * PROPRIEDADES
	 **********************************************************/ 
	#region Externas
		/**------------------------------------------------------------
		 * EXTERNAS	
		 **----------------------------------------------------------*/ 

		private static Pause _instance;

		/// <summary>
		/// Propriedade que indica se o jogo esta pausado.
		/// </summary>
		public static Pause instance
		{
			get
			{
				if(!_instance)
				{
					GameObject gameObject = new GameObject();
					gameObject.name = "Pause";
					gameObject.AddComponent<Pause>();

					_instance = gameObject.GetComponent<Pause>();
				}

				return _instance;
			}
		}

		/// <summary>
		/// Botao de para ou continuar o jogo.
		/// </summary>
		public tk2dUIToggleButton pauseButton;

		private bool _isPaused = false;

		/// <summary>
		/// Indica se o jogo esta parado ou nao.
		/// </summary>
		public bool isPaused
		{
			get
			{
				return _isPaused;
			}
		}

		/**------------------------------------------------------------
		 * INTERNAS	
		 **----------------------------------------------------------*/ 

	#endregion

	#endregion

	/**********************************************************
	 * FUNÇÕES
	 **********************************************************/ 

	protected void Awake()
	{
		if(pauseButton)

			pauseButton.OnToggle += onButtonClik;
	}

	#region Eventos
	/**------------------------------------------------------------
	 * EVENTOS
	 **----------------------------------------------------------*/

	void onButtonClik (tk2dUIToggleButton obj)
	{
		_isPaused = !_isPaused;

		MessageDispatcher.Broadcast<PauseMessage>(new PauseMessage(PauseMessage.ON_PAUSE_CHANGED, _isPaused),
		                                          DispatcherMode.DONT_REQUIRE_LISTENER );
	}

	#endregion
}

