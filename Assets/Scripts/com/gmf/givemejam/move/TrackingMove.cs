using UnityEngine;

namespace com.gmf.givemejam.move
{
	/// <summary>
	/// <see cref="IMove"/> para movimentaçao de seguir um alvo.
	/// </summary>
	[System.Serializable]
	public class TrackingMove : IMove
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
			/// Alvo em que o movimento ira seguir.
			/// </summary>
			public Transform target;

			/// <summary>
			/// Velocidade em que o movimento ira seguir o alvo.
			/// </summary>
			[MultiRangeAttribute(0, 10, "Velocidade em que o movimento ira seguir o alvo.")]
			public float speed;

			/// <summary>
			/// Distancia minima entre o alvo e o objeto.
			/// </summary>
			[MultiRangeAttribute(0, 30, "Distancia minima entre o alvo e o objeto..")]
			public float minDistance;

			private bool _isTracking;

			/// <summary>
			/// Propriedade que indica se o objeto esta seguindo o alvo.
			/// </summary>
			public bool isTracking
			{
				get
				{
					return _isTracking;
				}
			}

		#endregion

		#endregion

		#region IMove implementation

		public override void FixedMove (Transform transform, Rigidbody2D rigidbody){}

		public override void Move (Transform transform, Rigidbody2D rigidbody)
		{
			if(isTracking)
			{
				if(Vector3.Distance(transform.position, target.position) > minDistance)
				{
					Vector2 direction    = new Vector2(target.position.x - transform.position.x,
					                                   target.position.y - transform.position.y).normalized;
					rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
				}
				else
				{
					rigidbody.velocity = Vector2.zero;
				}
			}
		}

		#endregion
	}
}

