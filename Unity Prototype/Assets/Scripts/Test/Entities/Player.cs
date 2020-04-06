using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    [SerializeField]
    private int _posX = 0;

    [SerializeField]
    private int _posY = 0;


    public int PosX { get { return _posX; } set { _posX = value; PrintPosition(); } }
    public int PosY { get { return _posY; } set { _posY = value; PrintPosition(); } }

    [SerializeField]
    private int _playerVel = 1;

    private bool _hasMoney = false;

    string _positionStirng = "";

    void PrintPosition()
    {
        
        _positionStirng = "Posicion del jugador : (" + _posX + ", " + _posY + ")";
        Debug.Log(_positionStirng);
    }
}
