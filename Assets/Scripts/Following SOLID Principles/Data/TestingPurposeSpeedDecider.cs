using UnityEngine;

public class TestingPurposeSpeedDecider : SpeedDecider
{
    [SerializeField] private float speed = 1f;
    public override float DecideSpeed()
    {
        return speed;
    }
}
