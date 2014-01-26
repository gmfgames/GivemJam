using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.gmf.givemejam.move
{
	[RequireComponent (typeof(Rigidbody2D))]

	/// <summary>
	/// Classe que implementaçao a movimentaçao por <see cref="IMovle"/>.
	/// </summary>
	public abstract class MovableObject : MonoBehaviourExtends
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
			/// Movimentaçoes do objeto. 
			/// </summary>
			[SerializeField]
			public List<IMove> moviments;

			#endregion

		#endregion

		#region Funçoes
		
		/**********************************************************
		 * FUNÇÕES
		 **********************************************************/ 

		protected virtual void FixedUpdate()
		{
			foreach(IMove move in moviments)

				move.FixedMove(transform, rigidbody2D);
		}

		protected virtual void LateUpdate()
		{
			foreach(IMove move in moviments)
				
				move.Move(transform, rigidbody2D);
		}

		#endregion
	}
}



