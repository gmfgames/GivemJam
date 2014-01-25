using UnityEditor;
using UnityEngine;

/// <summary>
/// Classe que extende um <see cref="PropertyDrawer"/> para habilitar
/// a descrição da propriedade.
/// </summary>
public class PropertyDrawerExtends : PropertyDrawer
{	
	/// <summary>
	/// Tamanho do componente de texto.
	/// </summary>
	protected float descriptionHeight;
	
	/// <summary>
	/// Distancia entre as propriedades.
	/// </summary>
	protected float gap = 4;
	
	/// <summary>
	/// Distancia da descrição para os componentes.
	/// </summary>
	protected float padding = 9;
	
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {		
		descriptionHeight = 0;
		
		position.y += gap;
				
		if(attribute is PropertyAttributeExtends)
		{
			PropertyAttributeExtends propertyExtends = (PropertyAttributeExtends)attribute;
			
			if(propertyExtends != null && propertyExtends.description != null && propertyExtends.description.Length > 0)
			{		
				Rect descRect = EditorGUI.IndentedRect(position);
								
				GUI.skin.label.wordWrap = true;
				descRect.width  -= gap ;
				descRect.x 		= (gap / 2) + (EditorGUI.indentLevel * 10);
				descRect.y 		+= gap / 2;
				
				float caracterPerLine = (position.width * 60) / 320;
				float numLines  	  = Mathf.Ceil(propertyExtends.description.Length / caracterPerLine);
				descRect.height = descriptionHeight = numLines * 20;
				descriptionHeight += gap;
				
				EditorGUI.HelpBox(descRect, propertyExtends.description, MessageType.Info);
			}
		}		
    }
	
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return base.GetPropertyHeight (property, label) + descriptionHeight;
	}
}