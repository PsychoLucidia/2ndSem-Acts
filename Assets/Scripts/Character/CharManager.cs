using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    public CharInfo[] charInfo;
    public string charPath = "CharacterList";

    void Awake()
    {
        charInfo = Resources.LoadAll<CharInfo>(charPath);
    }
}
