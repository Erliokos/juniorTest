using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorPanel : MonoBehaviour
{
    public Image line;
   
  


    public void ArmorDamage(float damage, float armor)
    {
        
        line.GetComponent<RectTransform>().localScale = new Vector3(armor-damage, 1, 1);
        
    }

}
