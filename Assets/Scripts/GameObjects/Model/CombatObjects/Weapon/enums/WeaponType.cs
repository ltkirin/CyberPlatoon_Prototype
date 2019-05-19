using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType 
{
    /// <summary>
    /// The Weapon, trooper operates most time in the combat.
    /// </summary>
    Primary = 0,
    /// <summary>
    /// Aditional weapon, that Trooper can carry in combat. Mostly situational weapons. 
    /// </summary>
    Secondry = 1,
    /// <summary>
    /// Personal weapon with short range, mostly used in close combat
    /// </summary>
    Handgun = 2,
    /// <summary>
    /// Vast weapon to fight vehicles, fortifications and armored units
    /// </summary>
    Heavy = 3,
    /// <summary>
    /// Varied personal explosives. Amount of grenade types, that one trooper can carry, is unlimited.
    /// </summary>
    Grenade = 4,
    /// <summary>
    /// Different types of highly specialized or exotic weapons. 
    /// </summary>
    Specioal = 5
}
