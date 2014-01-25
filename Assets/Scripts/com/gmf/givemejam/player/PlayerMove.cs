using UnityEngine;
using System.Collections;

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
		
		private Vector3 _moveDirection;
		/// <summary>
		/// Retorna um <code>Vector3</code> que representa a movimentação do jogador.
		/// </summary>
		/// <value>
		/// As velocidades atuais de movimentação do jogador.
		/// </value>
		public Vector3 moveDirection
		{
			get
			{
				return  _moveDirection;
			}
		}
	#endregion

	#endregion

	public override void onPause(bool pause)
	{
	}
}
