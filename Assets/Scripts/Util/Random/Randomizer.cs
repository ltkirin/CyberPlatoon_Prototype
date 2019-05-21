using UnityEngine;
/// <summary>
/// Singletone random numbers and rolls generator
/// </summary>
public class Randomizer
{
    private static Randomizer innerInstance;

    /// <summary>
    /// Current Randomizer object instance
    /// </summary>
    public static Randomizer Instance
    {
        get
        {
            if (innerInstance == null)
            { innerInstance = new Randomizer(); }
            return innerInstance;
        }
    }

    #region Dice rolls simulation
    /// <summary>
    /// Get value between 1 and maxValue. Simalting a dise roll
    /// </summary>
    /// <param name="maxValue">Maximum value of the unmodified Roll</param>
    /// <returns>Roll result</returns>
    public int GetRoll(int maxValue)
    {
        return GetRandomInt(1, maxValue);
    }
    /// <summary>
    /// Gets an array of Rolls
    /// </summary>
    /// <param name="rollsQuantity">Needed quantity of rolls</param>
    /// <param name="maxValue">Maximum value of a single unmodified Roll</param>
    /// <returns>Rolls results</returns>
    private int[] GetRolls(int rollsQuantity, int maxValue)
    {
        int[] rolls = new int[rollsQuantity];
        for (int i = 0; i < rolls.Length; i++)
        {
            rolls[i] = GetRoll(maxValue);
        }
        return rolls;
    }
    #endregion

    #region Dice rerolls
    /// <summary>
    /// Provides mentioned quantity of rolls and selects the highest result
    /// </summary>
    /// <param name="rollsQuantity">Count of rolls</param>
    /// <param name="maxValue">Maximum value of roll</param>
    /// <returns>The highest result of made rolls</returns>
    public int GetMaxRoll(int rollsQuantity, int maxValue)
    {
        int[] rolls = GetRolls(rollsQuantity, maxValue);
        int currentValue = 0;
        foreach (int roll in rolls)
        {
            if (roll > currentValue)
            {
                currentValue = roll;
            }
        }
        return currentValue;
    }
    /// <summary>
    /// Provides mentioned quantity of rolls and selects the lowest result
    /// </summary>
    /// <param name="rollsQuantity">Count of rolls</param>
    /// <param name="maxValue">Maximum value of roll</param>
    /// <returns>The lowest result of made rolls</returns>
    public int GetMinRoll(int rollsQuantity, int maxValue)
    {
        int[] rolls = GetRolls(rollsQuantity, maxValue);
        int currentValue = maxValue;
        foreach (int roll in rolls)
        {
            if (roll < currentValue)
            {
                currentValue = roll;
            }
        }
        return currentValue;
    }
    /// <summary>
    /// Make two rolls and get the higher result (simulates a single dice Reroll)
    /// </summary>
    /// <param name="maxValue">Max value of the Roll</param>
    /// <returns>Higher of two Rolls results</returns>
    public int GetMaxReroll(int maxValue)
    {
        return GetMaxRoll(2, maxValue);
    }
    /// <summary>
    /// Make two rolls and get the lower result (simulates a single dice Reroll)
    /// </summary>
    /// <param name="maxValue">Max value of the Roll</param>
    /// <returns>Lower of two Rolls results</returns>
    public int GetMinReroll(int maxValue)
    {
        return GetMinRoll(2, maxValue);
    }
    #endregion

    #region Integers generating
    /// <summary>
    /// Gets positive random ineger, not exceeding mentioned value
    /// </summary>
    /// <param name="maxValue">Maximum value of the Random integer</param>
    /// <returns>Generated random integer</returns>
    public int GetRandomInt(int maxValue)
    {
       return Random.Range(0, maxValue + 1);
    }
    /// <summary>
    /// Gets random ineger, which is not less then Minimal number and does not exceed Maximum value
    /// </summary>
    /// <param name="minValue">Maximum possible value of the generated integer</param>
    /// <param name="maxValue">Minimal possible value of the generated integer</param>
    /// <returns>Generated random integer</returns>
    public int GetRandomInt(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue + 1);
    }
    #endregion

  


}
