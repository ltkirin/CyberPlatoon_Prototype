using System;
using System.Collections.Generic;
/// <summary>
/// Collection of Implants, that Trooper cariies in his body
/// </summary>
public class ImplantsCollection : List<BaseImplant>
{
    /// <summary>
    /// Get Implant of type, or null, if Trooper has no Implant of the type
    /// </summary>
    /// <param name="implantType">Type of the implant</param>
    /// <returns>Implant of type or null, if Trooper has no such Implant</returns>
    public BaseImplant GetImplantOfType(Type implantType)
    {
        if(!implantType.IsSubclassOf(typeof(BaseImplant)))
        {
            return null;
        }
        else
        {
            return Find(i => i.GetType() == implantType);
        }
    }

}
