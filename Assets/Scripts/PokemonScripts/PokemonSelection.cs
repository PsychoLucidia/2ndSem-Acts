using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonSelection : MonoBehaviour
{
    public PokemonManager pokemonManager;
    public Transform parentPos;
    public GameObject pokemonButtonPrefab;

    void Start()
    {
        Debug.Log(pokemonManager.pokemons.Count());
        foreach (Pokemon p in pokemonManager.pokemons)
        {
            GameObject buttonPrefab = Instantiate(pokemonButtonPrefab,parentPos);
            PokemonButton pokemonButton = buttonPrefab.GetComponent<PokemonButton>();
            pokemonButton.SetPokemonData(p);
        }

    }
}
