using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject hand1;
    public List<GameObject> CardsInHand;
    public List<GameObject> CardsInDeck;

    void Start()
    {

        for(int i = 0; i < 10; i++)
        {
            OnClick();
        } 
    }

    public void OnClick()
    {
        int randomIndex = Random.Range(0, CardsInDeck.Count);
        GameObject drawCard = Instantiate(CardsInDeck[randomIndex], new Vector3(0, 0, 0), Quaternion.identity);
        drawCard.transform.SetParent(hand1.transform, false);
        CardsInHand.Add(drawCard);
        CardsInDeck.RemoveAt(randomIndex); 
    }
}
