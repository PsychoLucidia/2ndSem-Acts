using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTween : MonoBehaviour
{
    public Transform lineObj;

    void OnEnable()
    {
        lineObj.localPosition = new Vector2(-222, -43);
        LeanTween.moveLocalX(lineObj.gameObject, -232, 0.5f);
    }
}
