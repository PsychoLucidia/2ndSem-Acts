using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Pokemon", menuName ="ScriptableObjects/Pokemon")]
public class Pokemon : ScriptableObject
{
    // Common attributes for all Pokémon
    public string name;
    public int level;
    public int hp;
    public Gender gender;
    public PokemonType type;
    public Moves[] moves;

    // Common behavior for all Pokémon
    public void Attack()
    {
        Debug.Log($"{name} used Tackle!");
    }

    
}



