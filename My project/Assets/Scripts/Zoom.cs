using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    GameObject canvas;
    private GameObject zoomCard;
    private Vector2 zoomScale = new Vector2(3, 3);
    public void Awake()
    {
        canvas = GameObject.Find("Canvas");
    }
    public void OnMouseEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector2(280, 280), Quaternion.identity);

        zoomCard.transform.SetParent(canvas.transform, false);

        zoomCard.transform.localScale = zoomScale;
    }
    public void OnMouseExit()
    {
        Destroy(zoomCard);
    }
}

