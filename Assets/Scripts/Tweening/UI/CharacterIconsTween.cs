using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIconsTween : MonoBehaviour
{
    public Transform attachedObj;

    void OnEnable()
    {
        attachedObj.localPosition = new Vector2(-20, 0);
        LeanTween.moveLocalX(attachedObj.gameObject, 0, 0.5f);
    }
}
