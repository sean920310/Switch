using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attribute that require implementation of the provided interface.
/// </summary>
public class RequireInterfaceAttribute : PropertyAttribute
{
    // Interface type.
    public List<System.Type> requiredType = new List<System.Type>();

    /// <summary>
    /// Requiring implementation of the <see cref="T:RequireInterfaceAttribute"/> interface.
    /// </summary>
    /// <param name="type">Interface type.</param>
    public RequireInterfaceAttribute(System.Type type)
    {
        this.requiredType.Add(type);

        // Get all parent type
        foreach (var i in type.GetInterfaces())
        {
            this.requiredType.Add(i);
        }
    }
}