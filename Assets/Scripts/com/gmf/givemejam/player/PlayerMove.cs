using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using com.gmf.givemejam.move;

[RequireComponent (typeof(Rigidbody2D))]

/// <summary>
/// Moveimentaçao do jogador.
/// </summary>
public class PlayerMove :  FlipableObject
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
		[MultiRangeAttribute(0, 50, "Velocidade em que o personagem vai correr em X")]
		public float xVelocity;

		/// <summary>
		/// Velocidade do player em Y.
		/// </summary>
		[MultiRangeAttribute(0, 50, "Velocidade em que o personagem vai correr em Y")]
		public float yVelocity;

		#endregion

		#region Internas
		/**------------------------------------------------------------
		 * INTERNAS
		 **----------------------------------------------------------*/ 

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
		
		/// <summary>
		/// Retorna um <code>Vector2</code> que representa a movimentação do jogador.
		/// </summary>
		/// <value>
		/// As velocidades atuais de movimentação do jogador.
		/// </value>
		private Vector2 _moveDirection;	

		/// <summary>
		/// Botao esquerdo do personagem que fara ele andar para esquerda.
		/// </summary>
		private TapGesture leftButton;
		
		/// <summary>
		/// Botao direito do personagem que fara ele andar para a direita.
		/// </summary>
		private TapGesture rightButton;

		#endregion

	#endregion

	#region Funçoes

	/**********************************************************
	 * FUNÇÕES
	 **********************************************************/ 

	protected override void Awake()
	{	
		base.Awake();

		_moveDirection = new Vector2();

		_controller    = GetComponent<Rigidbody2D>();

		CreateButtons();

		leftButton.StateChanged += LeftButtonPress;

		rightButton.StateChanged += RightButtonPress;

		bool init = Pause.instance.isPaused;
	}

	/// <summary>
	/// Cria os botoes de movimentaçao do personagem.
	/// </summary>
	private void CreateButtons()
	{
		Vector3 cameraPos = Camera.main.transform.position;
		GameObject button = new GameObject();
		button.AddComponent<BoxCollider>();
		button.AddComponent<TapGesture>();
		button.transform.localScale = new Vector3(12, 12, 1);

		GameObject right = Instantiate(button) as GameObject;
		right.transform.parent = Camera.main.transform;
		right.transform.position = new Vector3(cameraPos.x + (right.collider.bounds.size.x / 2) + .2f,
		                                       cameraPos.y, cameraPos.z + 5) ;

		rightButton = right.GetComponent<TapGesture>();

		GameObject left = Instantiate(button) as GameObject;
		left.transform.parent = Camera.main.transform;
		left.transform.position = new Vector3(cameraPos.x - (right.collider.bounds.size.x / 2) - .2f,
		                                      cameraPos.y, cameraPos.z + 5) ;
		
		leftButton = left.GetComponent<TapGesture>();

		Destroy(button);
	}

	protected override void OnPause(bool pause)
	{
		if(pause)
		{
			_moveDirection       	= _controller.velocity;
			_controller.velocity 	= Vector2.zero;
			_controller.isKinematic = true;
		}
		else
		{
			_controller.isKinematic = false;
			_controller.velocity 	= _moveDirection;
		}
	}

	#endregion

	#region Eventos
	/**------------------------------------------------------------
	 * EVENTOS
	 **----------------------------------------------------------*/

	void LeftButtonPress (object sender, TouchScript.Events.GestureStateChangeEventArgs e)
	{
		if(!isPaused && isEnabled && e.State == Gesture.GestureState.Began)

			_controller.velocity = new Vector2(-xVelocity, yVelocity);
	}

	void RightButtonPress (object sender, TouchScript.Events.GestureStateChangeEventArgs e)
	{
		if(!isPaused && isEnabled && e.State == Gesture.GestureState.Began)

			_controller.velocity = new Vector2(xVelocity, yVelocity);
	}

	#endregion
}
