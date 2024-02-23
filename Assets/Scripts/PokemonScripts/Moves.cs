using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moves" , menuName = "ScriptableObjects/Moves")]
public class Moves : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] int damage;
    [SerializeField] PokemonType type;
}
