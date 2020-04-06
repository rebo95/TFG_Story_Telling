using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Money:MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private int _posX = 0;

    [SerializeField]
    private int _posY = 0;

    [SerializeField]
    private int _quantity = 100;

    public int PosX { get { return this._posX; } set { this._posX = value;} }
    public int PosY { get { return this._posY; } set { this._posY = value;} }
    public int Quantity { get { return this._quantity; } set { this._quantity = value; } }
}
