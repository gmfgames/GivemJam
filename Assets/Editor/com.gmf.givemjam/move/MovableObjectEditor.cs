using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using com.gmf.givemejam.move;

[CanEditMultipleObjects]
[CustomEditor(typeof(MovableObject), true)]
public class MovableObjectEditor : Editor
{
	public enum MOVE_TYPE
	{
		TRACKING,

		FIPLABLE
	}

	#region Properties 
	/**********************************************************
	 * PROPRIEDADES
	 **********************************************************/ 

	/// <summary>
	/// Lista de movimentos.
	/// </summary>
	private SerializedProperty moviments;

	private MovableObject      moveTarget;

	/// <summary>
	/// Tipos de movimentos.
	/// </summary>
	private List<MoveType> movimentsType = new List<MoveType>();

	/// <summary>
	/// Tamanho da lista de movimentos.
	/// </summary>
	private int movimentsSize = 0;

	/// <summary>
	/// Propriedade que indica se a lista de movimentos esta
	/// sendo visualizada ou nao.
	/// </summary>
	private bool showMoviments;

	#endregion

	#region Funçoes
	
	/**********************************************************
	 * FUNÇÕES
	 **********************************************************/ 

	void OnEnable()
	{
		moveTarget = target as MovableObject;
		moviments  = serializedObject.FindProperty("moviments");


		movimentsSize = moviments.arraySize;

		movimentsType = new List<MoveType>();
		MoveType currentMove;

		foreach(IMove move in moveTarget.moviments)
		{
			currentMove 	 = new MoveType();
			currentMove.move = move;

			if(move is TrackingMove)

				currentMove.moveType = MOVE_TYPE.TRACKING;

			else

				currentMove.moveType = MOVE_TYPE.FIPLABLE;
		}
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		DrawDefaultInspector();

		showMoviments = EditorGUILayout.Foldout(showMoviments, "Movimentos (" + movimentsSize + ")");

		if(showMoviments)
		{
			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.LabelField("Tamanho"); 
			movimentsSize = EditorGUILayout.IntField(movimentsSize);

			EditorGUILayout.EndHorizontal();

			MoveType currentMove;
			moveTarget.moviments.Clear();

			for(int i = 0; i < movimentsSize; i++)
			{
				if(movimentsType.Count < (i + 1))
				{
					currentMove = new MoveType();
					movimentsType.Add(currentMove);
				}
				else

					currentMove = movimentsType.ElementAt(i);

				currentMove = movimentsType.ElementAt(i);
					
				currentMove.moveType = (MOVE_TYPE) EditorGUILayout.EnumPopup("Tipo: ", currentMove.moveType);

				if(currentMove.moveType == MOVE_TYPE.FIPLABLE && !(currentMove.move is FiplableMove))
				{
					currentMove.move = new FiplableMove();
				}
				else if(currentMove.moveType == MOVE_TYPE.TRACKING && !(currentMove.move is TrackingMove))
				{
					currentMove.move = new TrackingMove();
				}

				moveTarget.moviments.Add(currentMove.move);
			}

			for(int j = 0; j < moviments.arraySize; j++)
			{
				EditorGUILayout.PropertyField(moviments.GetArrayElementAtIndex(j));
			}
		}
	}
	
	#endregion
}

class MoveType
{
	#region Properties 
	/**********************************************************
	 * PROPRIEDADES
	 **********************************************************/ 

	/// <summary>
	/// Tipo de movimento.
	/// </summary>
	public MovableObjectEditor.MOVE_TYPE moveType = MovableObjectEditor.MOVE_TYPE.TRACKING;

	/// <summary>
	/// Instancia do movimento atual.
	/// </summary>
	public IMove move;

	#endregion
}


