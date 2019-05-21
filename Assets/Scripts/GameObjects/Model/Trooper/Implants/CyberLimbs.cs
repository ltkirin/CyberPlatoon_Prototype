using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberLimbs : BaseImplant
{
    private int lightWoundsIgnorePoints;
    private int heavyWoundsIgnorePoints;

    public CyberLimbs(int tier) : base(tier)
    {
        if (tier == 3)
        {
            lightWoundsIgnorePoints = 2;
            heavyWoundsIgnorePoints = 1;
        }
        else
        {
            lightWoundsIgnorePoints = tier;
            heavyWoundsIgnorePoints = 0;
        }
    }

    public bool isActive
    {
        get => (lightWoundsIgnorePoints + heavyWoundsIgnorePoints) > 0;
    }

    public bool WoundIsIgnorable(Wound woundToIgnore)
    {
        int severity = (int)woundToIgnore.Severity;
        if (severity == 1 && lightWoundsIgnorePoints > 0)
        {
            lightWoundsIgnorePoints--;
            return true;
        }
        else if (severity > 1 && heavyWoundsIgnorePoints > 0)
        {
            heavyWoundsIgnorePoints--;
            return true;
        }
        else return false;
    }
}
