using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PokemonButton : MonoBehaviour
{
    public TextMeshProUGUI pokemonNameTxt;
    public TextMeshProUGUI hpText;

    public void SetPokemonData(Pokemon unit)
    {
        pokemonNameTxt.text = unit.name;
        hpText.text = unit.hp.ToString();
    }
}
