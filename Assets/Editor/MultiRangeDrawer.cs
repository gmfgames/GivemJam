using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MultiRangeAttribute))]
public class MultiRangeDrawer : PropertyDrawerExtends
{
	MultiRangeAttribute multiRangeAttribute { get { return ((MultiRangeAttribute)attribute); } }
		
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {				
		base.OnGUI(position, property, label);
		
		Rect sliderRect = new Rect(position.x, position.y, position.width, 20);
		sliderRect.y    += descriptionHeight + padding;	
		
		if(property.propertyType == SerializedPropertyType.Float)
			
			EditorGUI.Slider(sliderRect, property, multiRangeAttribute.min, multiRangeAttribute.max);
		
		else if(property.propertyType == SerializedPropertyType.Integer)	 		
						
			EditorGUI.IntSlider(sliderRect, property, multiRangeAttribute.min, multiRangeAttribute.max);
		
		else
			
			EditorGUI.HelpBox(sliderRect, "Propriedade não suportada", MessageType.Error);		
    }
	
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return base.GetPropertyHeight (property, label) + 20; 
	}
}

