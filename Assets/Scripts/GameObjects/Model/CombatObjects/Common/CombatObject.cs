using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
/// <summary>
/// Base class for all objects, loaded with multiple parameters
/// </summary>
public abstract class CombatObject
{
    /// <summary>
    /// Create new CombatObject object, pass Parameters dictionary to parse
    /// </summary>
    /// <param name="parameters">Parameters dictionary</param>
    public CombatObject(Dictionary<string,object> parameters)
    {
        ParseParameters(parameters);
    }
    /// <summary>
    /// Parse Parameters dictionary and set values of an Object fields
    /// </summary>
    /// <param name="parameters"></param>
    protected void ParseParameters(Dictionary<string, object> parameters)
    {
        BindingFlags bindingFlags = BindingFlags.Instance |
                   BindingFlags.NonPublic;
        FieldInfo[] fields = GetType().GetFields(bindingFlags);
        foreach (KeyValuePair<string,object> kvp in parameters)
        {
            FieldInfo field = fields.Where(f => f.Name == kvp.Key).FirstOrDefault();
            if (field == null)
            {
                throw new Exception($"Wrong object in {GetType()} parameters dictionary! " +
                    $"The model does not contain {kvp.Key} field!");
            }
            field.SetValue(this, kvp.Value);
        }
    }
}
