using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Money
{
    [SerializeField]
    private int _posX = 0;

    [SerializeField]
    private int _posY = 0;

    [SerializeField]
    private int _quantity = 100;

    public int PosX { get { return _posX; } set { _posX = value;} }
    public int PosY { get { return _posY; } set { _posY = value;} }
    public int Quantity { get { return _quantity; } set { _quantity = value; } }

}
