/// <summary>
/// Implant, designed to help to survive even critical wounds
/// Replaces standart Save Check for ontaining trooper
/// </summary>
public class LifeSaverImplant : BaseImplant
{
    
    public LifeSaverImplant(int tier) : base(tier)
    {
    }
    /// <summary>
    /// Improved Save Check, returning the lowest Roll result from Tier +1 Rolls
    /// </summary>
    /// <returns>Lowest result from Tier+1 Rolls</returns>
    public int GetSaveCheck()
    {
        return Randomizer.Instance.GetMinRoll(tier+1, ValuesStorage.Instance.RollMaxValues.Light);
    }
}
