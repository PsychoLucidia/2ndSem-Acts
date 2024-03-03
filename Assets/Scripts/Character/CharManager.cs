using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    public CharInfo[] charInfo;
    public string charPath = "CharacterList";

    // This function is called when the script instance is being loaded.
    void Awake()
    {
        charInfo = Resources.LoadAll<CharInfo>(charPath);
    }
}
