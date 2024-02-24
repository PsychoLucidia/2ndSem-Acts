using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public CharManager characterManager;
    public Transform parent;
    public GameObject objPrefab;
    public CharStatView charStatView;

    void Start()
    {
        foreach (CharInfo charI in characterManager.charInfo)
        {
            GameObject btnInstantiate = Instantiate(objPrefab, parent);
            CharBtn charBtn = btnInstantiate.GetComponent<CharBtn>();
            charBtn.CharSetData(charI);
            Debug.Log("Created Object");
            
            Button button = btnInstantiate.GetComponent<Button>();
            button.onClick.AddListener(() => charStatView.SetStatData(charI));
        }
    }
}
