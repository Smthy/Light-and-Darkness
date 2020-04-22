using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Player Spells")]
public class PlayerSpells : ScriptableObject
{
    public string spellName;

    public GameObject spell;

    public float lifetime;
    public float damage;
    public float knockback;
}
