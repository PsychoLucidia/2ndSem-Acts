using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonData : MonoBehaviour
{
    [Header("Pokemon Info")]
    public string name;
    public Types types;
    public Gender gender;
    public string owner;

    [Header("Stats")]
    public int currentHP;
    public int maxHP;
    public int atk;
    public int def;
    public int spAtk;
    public int defAtk;
    public int spd;


    private void Start()
    {
        switch (types)
        {
            case Types.Bug: Debug.Log("Bug"); break;
            case Types.Dark: Debug.Log("Dark"); break;
            case Types.Dragon: Debug.Log("Dragon"); break;
            case Types.Electric: Debug.Log("Electric"); break;
            case Types.Fairy: Debug.Log("Fairy"); break;
            case Types.Fighting: Debug.Log("Fighting"); break;
            case Types.Fire: Debug.Log("Fire"); break;
            case Types.Flying: Debug.Log("Flying"); break;
            case Types.Ghost: Debug.Log("Ghost"); break;
            case Types.Grass: Debug.Log("Grass"); break;
            case Types.Ground: Debug.Log("Ground"); break;
            case Types.Ice: Debug.Log("Ice"); break;
            case Types.Normal: Debug.Log("Normal"); break;
            case Types.Poison: Debug.Log("Poison"); break;
            case Types.Psychic: Debug.Log("Psychic"); break;
            case Types.Rock: Debug.Log("Rock"); break;
            case Types.Steel: Debug.Log("Steel"); break;
            case Types.Water: Debug.Log("Water"); break;
        }
    }
}

