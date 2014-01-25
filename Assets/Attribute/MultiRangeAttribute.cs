using UnityEngine;
using System.Collections;

/// <summary>
/// <see cref="PropertyAttribute"/> para ainterface do tipo <see cref="Slider"/> para
/// números: int ou float.
/// </summary>
public class MultiRangeAttribute : PropertyAttributeExtends
{
// <summary>
	/// Mínimo em que o slider poderá alcançar.
	/// </summary>
    public int min;
	
	/// <summary>
	/// Maximo em que o slider poderá alcançar.
	/// </summary>
    public int max;
	
	
    public MultiRangeAttribute(int min, int max, string description = "") : base(description)
    {	
        this.min = min;
        this.max = max;
    }
}

