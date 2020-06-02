using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusPanel : MonoBehaviour
{
    public Text score;
   
    
    public void PlusPoint(int oneKilledl)
    {
        score.text = (int.Parse(score.text) + oneKilledl).ToString();
    }
}
