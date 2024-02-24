using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public CharManager characterManager;
    public Transform parent;
    public GameObject objPrefab;

    void Start()
    {
        foreach (CharInfo charI in characterManager.charInfo)
        {
            GameObject btnInstantiate = Instantiate(objPrefab, parent);
            CharBtn charBtn = btnInstantiate.GetComponent<CharBtn>();
            //charBtn;
        }
    }
}
