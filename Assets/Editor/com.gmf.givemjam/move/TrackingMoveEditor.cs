using UnityEditor;

using com.gmf.givemejam.move;

namespace AssemblyCSharpEditor
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(TrackingMove), true)]
	public class TrackingMoveEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.LabelField("Teste");
		}
	}
}

