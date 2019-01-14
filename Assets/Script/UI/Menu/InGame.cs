using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InGame : UI
{
    public void UpdateScore(int score)
    {
        Vars["Score"].GetComponent<Text>().text = score + " m";
    }
}
