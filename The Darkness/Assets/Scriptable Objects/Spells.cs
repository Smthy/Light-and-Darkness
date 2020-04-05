using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Spell", menuName = "Spell"]
public class Spells : ScriptableObject
{
    public string spellName;

    public Sprite projectile;

    public int lifeTime;
    public int damage;
    public int knockback;

    public bool continuousDamage;
    public int cDamage;
    public int clifeTime;    
}
