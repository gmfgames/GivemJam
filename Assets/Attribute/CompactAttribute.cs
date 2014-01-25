using UnityEngine;
using System.Collections;

/// <summary>
/// <see cref="PropertyAttributeExtends"/> utilizados para prorpiedades que configuram
/// posição ou tamanho.
/// </summary>
public class CompactAttribute : PropertyAttributeExtends {
	
	public CompactAttribute(string description = ""): base(description){}
}
