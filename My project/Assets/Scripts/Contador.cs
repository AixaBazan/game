using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Contador : MonoBehaviour
{
    public TMP_Text ContadorTotal;
    public GameObject Melee;
    public GameObject Ranged;
    public GameObject Siege;
    public int Sum = 0;
   
    void Update()
    {
        Sum = Melee.GetComponent<ZonaCM>().contador + Ranged.GetComponent<ZonaCM>(). contador + Siege.GetComponent<ZonaCM>(). contador;
        ContadorTotal.text = Sum.ToString();
    }

}
