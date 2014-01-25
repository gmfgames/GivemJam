using UnityEngine;
using System.Collections;

/// <summary>
/// Classe que extende um <see cref="PropertyAttribute"/> para habilitar
/// a descrição das propriedades.
/// </summary>
public class PropertyAttributeExtends : PropertyAttribute
{
	/// <summary>
	/// Descrição do atributo que terá uma interface customizada.
	/// </summary>
	public string description;
	
	public PropertyAttributeExtends(string description = "")
	{
		this.description = description;
	}
}

