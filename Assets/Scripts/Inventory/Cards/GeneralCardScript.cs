using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Agonalea Games/Card", order = 1)]
public class GeneralCardScript : ScriptableObject
{

    public GeneralCardScript()
    {

    }

    public GeneralCardScript getCopy()
    {
        return (GeneralCardScript)this.MemberwiseClone();
    }

    [Header("Testing data")]
    public int level;
    [Header("General info")]
    public string ID = "CA";
    public string cardName;
    public string description;
    public Rarity rarity;
    public Category category;
    public Sprite sprite;

    [Header("Upgrading system configuration")]
    public int maxLevel;
    public int avaiableCards;

    [Header("Gameplay data")]
    public GameObject Model3D;
    public Material armourMaterialMale, armourMaterialFemale;
    [Header("Musical Configuration")]
    public GameplayConfiguration gameplayConfiguration;

    public int getTotalDamage()
    {
        int damage = 0;
        damage += gameplayConfiguration.fireDamage;
        damage += gameplayConfiguration.bleedDamage;
        damage += gameplayConfiguration.magicDamage;
        damage += gameplayConfiguration.physicDamage;
        damage += gameplayConfiguration.poisonDamage;
        damage += gameplayConfiguration.lightingDamage;
        return damage;
    }

}

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary,
    Unique,
    Seasonal
}

public enum Category
{
    Armor,
    Helmet,
    Magic,
    Pet,
    Shield,
    Weapon,
    Null

}
