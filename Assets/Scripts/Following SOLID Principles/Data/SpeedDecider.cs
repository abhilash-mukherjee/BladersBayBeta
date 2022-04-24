using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpeedDecider : MonoBehaviour, IDecideSpeed
{
    public abstract float DecideSpeed();
}
