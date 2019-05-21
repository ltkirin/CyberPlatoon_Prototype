using System;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Object to store and operate weaponary, trooper is carryng on a Mission
/// </summary>
public class TrooperWeaponary
{
    #region Fields
    private WeaponModel hands;
    private WeaponModel back;
    private WeaponModel holster;
    private WeaponModel sling = null;
    private List<WeaponModel> grenades = new List<WeaponModel>();
    #endregion

    #region Constructors
    /// <summary>
    /// Create new empty Weaponary 
    /// </summary>
    public TrooperWeaponary()
    {
    }
    /// <summary>
    /// Create new Weapnaey and fill it with a Loadout
    /// </summary>
    /// <param name="loadout"></param>
    public TrooperWeaponary(IList<WeaponModel> loadout)
    {
        PickUpLoadout(loadout);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Slot for gun in hands of a Trooper. This is active weapon, which will be used to generate Attacks pool
    /// </summary>
    public WeaponModel Hands
    {
        get => hands;
    }
    /// <summary>
    /// Aditional weapon, a Trooper carries in combat. Optional. Mostly is a situative or a heavy weapons
    /// </summary>
    public WeaponModel Back
    {
        get => back;
    }
    /// <summary>
    /// Slot for a handgun, trooper carries in combat. Optionsl
    /// </summary>
    public WeaponModel Holster
    {
        get => holster;
    }
    /// <summary>
    /// Temporal weapon slot for Trooper to use, when he temporally needs free hands (to use a grenade or a handgun)
    /// </summary>
    public WeaponModel Sling
    {
        get => sling;
    }
    /// <summary>
    /// Grenade pouch, that stores any number of grenade types
    /// </summary>
    public List<WeaponModel> Grenades
    {
        get => grenades;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Switch weapons, taking Hangds and Back slots
    /// </summary>
    public void SwitchPrimaryWeapons()
    {
        WeaponModel tempweapon = hands;
        hands = back;
        back = tempweapon;
    }
    /// <summary>
    /// Set weapon in a Holster slot to a Hands slot, and put weapon from hands to the Sling
    /// </summary>
    public void TakeHandgun()
    {
        if (hands.Type != WeaponType.Handgun)
        {
            sling = hands;
            hands = holster;
            holster = null;
        }
    }
    /// <summary>
    /// Take handgun to the Holster slot and take one of primary weapons in hands
    /// </summary>
    public void HolsterHandgun()
    {
        if (hands.Type == WeaponType.Handgun)
        {
            holster = hands;
            hands = null;
            if (sling != null)
            {
                hands = sling;
                sling = null;
            }
            else if (back != null)
            {
                SwitchPrimaryWeapons();
            }
        }
    }
    /// <summary>
    /// Take a greande from a Grenade pouch and take of current active weapon (to a Sling or a Holster)
    /// </summary>
    /// <param name="grenadeIndex"></param>
    public void TakeGrenade(int grenadeIndex)
    {
        if (hands.Type == WeaponType.Handgun)
        {
            holster = hands;
        }
        else if (hands.Type != WeaponType.Grenade)
        {
            sling = hands;
        }
        hands = grenades[grenadeIndex];
    }
    /// <summary>
    /// Take grenade back to a pouch and arm a primarey weapon or a Handgun, if the primary weapon is absent
    /// </summary>
    public void HolsterGrenade()
    {
        WeaponModel weaponToUse;
        if (hands.Type == WeaponType.Grenade)
        {
            hands = null;
            if (sling != null)
            {
                weaponToUse = sling;
            }
            else if (holster != null)
            {
                weaponToUse = holster;
            }
        }
    }
    /// <summary>
    /// take a new weapon or replace exisiting weapon, taking Hands or Holster slots, if slots are occupied
    /// </summary>
    /// <param name="weaponToPickUp"></param>
    public void PickUpWeapon(WeaponModel weaponToPickUp)
    {
        if (weaponToPickUp.Type == WeaponType.Handgun)
        {
            if (hands != holster)
            {
                holster = weaponToPickUp;
            }
            else
            {
                hands = weaponToPickUp;
            }
        }
        else if (weaponToPickUp.Type == WeaponType.Grenade)
        {
            if (!grenades.Where(g => g.Name == weaponToPickUp.Name).Any())
            {
                grenades.Add(weaponToPickUp);
            }
        }
        else
        {
            if (back == null)
            {
                back = weaponToPickUp;
            }
            else
            {
                hands = weaponToPickUp;
            }
        }
    }
    /// <summary>
    /// Take and allocate array of Weapons. 
    /// Removes all current contained in Wepaonary items before taking new ones.
    /// </summary>
    /// <param name="loadout">New items for Weaponary</param>
    public void PickUpLoadout(IList<WeaponModel> loadout)
    {
        ClearLoadout();
        if (loadout.Where(w => w.Type == WeaponType.Primary).Count() > 1
            || loadout.Where(w => w.Type == WeaponType.Handgun).Count() > 1)
        {
            throw new Exception("Wrong loadout composition! It contains redundant Primary or Handgun types weapons!");
        }
        foreach (WeaponModel weapon in loadout)
        {
            PickUpWeapon(weapon);
        }
        if(hands.Type != WeaponType.Primary && back.Type == WeaponType.Primary)
        {
            SwitchPrimaryWeapons();
        }
    }
    /// <summary>
    /// Remove all weapons from current Weaponary
    /// </summary>
    private void ClearLoadout()
    {
        hands = null;
        back = null;
        holster = null;
        sling = null;
        grenades.Clear();
    }
    #endregion

}
