using UnityEngine;

namespace com.gmf.givemejam.move
{
	/// <summary>
	/// <see cref="IMove"/> para movimentaçao de virar o algo de acordo com sua direçao.
	/// </summary>
	[System.Serializable]
	public class FiplableMove : IMove
	{
		#region Properties 
		/**********************************************************
		 * PROPRIEDADES
		 **********************************************************/ 

			/// <summary>
			/// Enumeraçao de posiçao vertical do objeto.
			/// </summary>
			public enum SIDE
			{
				RIGHT,

				LEFT
			}

			#region Externas
			/**------------------------------------------------------------
			 * EXTERNAS	
			 **----------------------------------------------------------*/ 

			private SIDE _currentSide;

			/// <summary>
			/// Direçao atual do objeto.
			/// </summary>
			public SIDE  currentSide
			{
				get
				{
					return _currentSide;
				}
			}

			#endregion

		#endregion

		#region Funçoes
		
		/**********************************************************
		 * FUNÇÕES
		 **********************************************************/ 

		protected virtual void FlipX(Transform transform)
		{
			_currentSide 			= _currentSide == SIDE.RIGHT ? SIDE.LEFT : SIDE.RIGHT;
			transform.localScale 	= new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}

		#endregion

		#region IMove implementation

		public void FixedMove (Transform transform, Rigidbody2D rigidbody){}

		public void Move (Transform transform, Rigidbody2D rigidbody)
		{
			if(_currentSide == SIDE.RIGHT && rigidbody.velocity.x < 0)

				FlipX(transform);

			else if(_currentSide == SIDE.LEFT && rigidbody.velocity.x > 0)

				FlipX(transform);
		}

		#endregion
	}
}

