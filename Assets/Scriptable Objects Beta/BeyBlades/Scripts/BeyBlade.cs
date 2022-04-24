using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New BeyBlade", menuName = "BeyBlade System/BeyBlade")]
public class BeyBlade : ScriptableObject
{
    public string beyBladeName;
    private BeyBladeType beyBladeType;
    public string beyBladeDescription;
    private EnergyLayer energyLayer;
    private ForgeDisc forgeDisc;
    private PerformanceTip performanceTip;
    public EnergyLayer EnergyLayer { get => energyLayer; set => energyLayer = value; }
    public ForgeDisc ForgeDisc { get => forgeDisc; set => forgeDisc = value; }
    public PerformanceTip PerformanceTip { get => performanceTip; set => performanceTip = value; }
    private float attack,defence,stamina,speed;
    public float Attack { get => CalculateAttack();}
    public float Defence { get => CalculateDefence();}
    public float Stamina { get => CalculateStamina();}
    public float Speed { get => CalculateSpeed(); }
    public BeyBladeType BeyBladeType { get => FindType(); }

    private BeyBladeType FindType()
    {
        var _total = attack + defence + stamina;
        if (attack > 0.4f * (_total)) return BeyBladeType.ATTACK;
        else if (defence > 0.4f * (_total)) return BeyBladeType.DEFENCE;
        else if (stamina > 0.4f * (_total)) return BeyBladeType.STAMINA;
        else return BeyBladeType.BALANCE;
    }

    private float CalculateAttack()
    {
        attack = energyLayer.attackValue + forgeDisc.attackValue + performanceTip.attackValue;
        return attack;
    }
    private float CalculateDefence()
    {
        defence = energyLayer.defenceValue + forgeDisc.defenceValue + performanceTip.defenceValue;
        return defence;
    }
    private float CalculateStamina()
    {
        stamina =  energyLayer.staminaValue + forgeDisc.staminaValue + performanceTip.staminaValue;
        return stamina;
    }
    private float CalculateSpeed()
    {
        speed = energyLayer.speedValue + forgeDisc.speedValue + performanceTip.speedValue;
        return speed;
    }


}

public enum BeyBladeType
{
    ATTACK, DEFENCE, STAMINA, BALANCE
}
