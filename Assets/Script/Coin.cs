using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{
    public static int value;
    public Text coinText;

    void Update()
    {
        coinText.text = value.ToString("0");
    }
    
}
