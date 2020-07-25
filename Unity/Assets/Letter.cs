using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public InputField InputText;

    public void Test(Text text)
    {
        text.text = InputText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
