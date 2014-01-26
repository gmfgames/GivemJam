using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

[RequireComponent (typeof(Rigidbody2D))]

/// <summary>
/// Moveimentaçao do jogador.
/// </summary>
public class PlayerMove : MonoBehaviourExtends 
{
	#region Properties 
	/**********************************************************
	 * PROPRIEDADES
	 **********************************************************/ 
	#region Externas
		/**------------------------------------------------------------
		 * EXTERNAS	
		 **----------------------------------------------------------*/ 

		/// <summary>
		/// Velocidade do jogador em X.
		/// </summary>
		public float xVelocity;

		/// <summary>
		/// Velocidade do player em Y.
		/// </summary>
		public float yVelocity;

		/// <summary>
		/// Gravidade que sera aplicada ao persongem.
		/// </summary>
		public float gravity;

		/// <summary>
		/// Botao esquerdo do personagem que fara ele andar para esquerda.
		/// </summary>
		public TapGesture leftButton;

		/// <summary>
		/// Botao direito do personagem que fara ele andar para a direita.
		/// </summary>
		public TapGesture rightButton;
	#endregion

	#region Internas
		/**------------------------------------------------------------
		 * INTERNAS
		 **----------------------------------------------------------*/ 

		//////////////////////////////////////////////////
		// controller
		////////////////////////////////////////////////

		private Rigidbody2D _controller;
		/// <summary>
		/// Componente <code>Rigidbody2D</code> utilizado para movimentar o jogador.
		/// </summary>
		
		public  Rigidbody2D controller
		{
			get
			{
				return _controller;
			}
		}
		
		//////////////////////////////////////////////////
		// moveDirection
		////////////////////////////////////////////////
		
		/// <summary>
		/// Retorna um <code>Vector2</code> que representa a movimentação do jogador.
		/// </summary>
		/// <value>
		/// As velocidades atuais de movimentação do jogador.
		/// </value>
		private Vector2 _moveDirection;
		

	#endregion

	#endregion

	#region Funçoes

	/**********************************************************
	 * FUNÇÕES
	 **********************************************************/ 

	protected void Awake()
	{	
		_moveDirection = new Vector2();

		_controller    = GetComponent<Rigidbody2D>();

		if(leftButton)

			leftButton.StateChanged += LeftButtonPress;

		else

			throw new UnityException("O botao esquerdo de movimentaçao do personagem nao esta configurado.");

		if(rightButton)
			
			rightButton.StateChanged += RightButtonPress;
		
		else
			
			throw new UnityException("O botao direito de movimentaçao do personagem nao esta configurado.");
	}

	public override void onPause(bool pause)
	{
		if(true)
		{
			_moveDirection       = _controller.velocity;
			_controller.velocity = Vector2.zero;
		}
		else
		{
			_controller.velocity = _moveDirection;
		}
	}

	#endregion

	#region Eventos
	/**------------------------------------------------------------
	 * INTERNAS
	 **----------------------------------------------------------*/

	void LeftButtonPress (object sender, TouchScript.Events.GestureStateChangeEventArgs e)
	{
		if(!isPaused && isEnabled)

			_controller.velocity = new Vector2(-xVelocity, yVelocity);
	}

	void RightButtonPress (object sender, TouchScript.Events.GestureStateChangeEventArgs e)
	{
		if(!isPaused && isEnabled)

			_controller.velocity = new Vector2(xVelocity, yVelocity);
	}

	#endregion
}
