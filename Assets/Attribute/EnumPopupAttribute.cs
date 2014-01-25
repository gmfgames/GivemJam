using UnityEngine;
using System.Collections;

/// <summary>
/// Enum popup attribute.
/// </summary>
public class EnumPopupAttribute : PropertyAttributeExtends
{
	protected string[] labels;
	
	public EnumPopupAttribute(string[] labels, string description = ""): base(description)
    {
		this.labels = labels;
	}
}

