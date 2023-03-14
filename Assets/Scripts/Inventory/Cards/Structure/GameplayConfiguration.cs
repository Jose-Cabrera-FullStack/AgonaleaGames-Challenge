using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameplayConfiguration {
    [Header("Damage configuration")]
    public int physicDamage;
    public int  magicDamage, fireDamage, lightingDamage, poisonDamage, bleedDamage;
    [Header("Resistance configuration")]
    public float physicResistancePorcentage;
    public float  magicResistancePorcentage, fireResistancePorcentage, lightingResistancePorcentage, poisonResistancePorcentage, bleedResistancePorcentage;
    [Header("Bonus configuration")]
    public float physicDamageBonus;
    public float  magicDamageBonus, fireDamageBonus, lightingDamageBonus, poisonDamageBonus, bleedDamageBonus;

    [Header("Defensive Configuration")]
    public float blockAmount;
    public float dodgeChance, criticalChange, criticalMultiplier, healthPointBoost;

}
