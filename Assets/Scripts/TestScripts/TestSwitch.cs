using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class TestSwitch : MonoBehaviour
{
    public TestEnum testEnum;
    string day = "Monday";
    int x = 1;
    int y = 2;


    // Start is called before the first frame update
    void Start()
    {
        switch (testEnum)
        {
            case TestEnum.Monday: Debug.Log("Monday"); break;
            case TestEnum.Tuesday: Debug.Log("Tuesday"); break;
            case TestEnum.Wednesday: Debug.Log("Wednesday"); break;
            case TestEnum.Thursday: Debug.Log("Thursday"); break;
            case TestEnum.Friday: Debug.Log("Friday"); break;
            case TestEnum.Saturday: Debug.Log("Saturday"); break;
            case TestEnum.Sunday: Debug.Log("Sunday"); break;
            default:
                Debug.Log("There are no days called");
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
