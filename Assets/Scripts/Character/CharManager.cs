using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    public CharInfo[] charInfo;
    public string charPath = "CharacterList";
    public bool manualLoad = false;

    // This function is called when the script instance is being loaded.
    void Awake()
    {
        if (!manualLoad)
        {
            charInfo = Resources.LoadAll<CharInfo>(charPath);
        }
    }
}
