using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PokemonInfoView : MonoBehaviour
{
    public Pokemon pokemon;

    [Header("UI Headers")]
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI genderTMP;


    public void OnEnable()
    {
        DisplayPokemon(pokemon);
    }
    public void DisplayPokemon(Pokemon pokemon)
    {
        nameTMP.text = pokemon.name;
        genderTMP.text = pokemon.gender.ToString();
    }

    public void ClearView()
    {
        pokemon = null;
        nameTMP.text = null;
        genderTMP.text = null;
    }
    public void OnDisable()
    {
        ClearView();
    }
}
