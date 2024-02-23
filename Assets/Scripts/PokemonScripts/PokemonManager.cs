using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour
{
    public Pokemon[] pokemons;
    private string folderPath = "Pokemon"; // Folder name inside the Assets/Resources folder

    void Start()
    {
        pokemons = Resources.LoadAll<Pokemon>(folderPath);
    }
}
