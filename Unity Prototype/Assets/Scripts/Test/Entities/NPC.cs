using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private int _posX = 0;

    [SerializeField]
    private int _posY = 0;

    [SerializeField]
    private int _moneyBagPosX;

    [SerializeField]
    private int _moneyBagPosY;

    private bool _finalPosXReached;
    private bool _finalPosYReached;




    public int MoneyBagPosX { get { return _moneyBagPosX; } set { _moneyBagPosX = value; } }
    public int MoneyBagPosY { get { return _moneyBagPosY; } set { _moneyBagPosY = value; } }

    public int PosX { get { return _posX; } set { _posX = value; PrintPosition(); } }
    public int PosY { get { return _posY; } set { _posY = value; PrintPosition(); } }

    [SerializeField]
    private int _npcVel = 1;


    string _positionStirng = "";


    void PrintPosition()
    {
        _positionStirng = "Posicion del NPC : (" + _posX + ", " + _posY + ")";
        Debug.Log(_positionStirng);
    }

    void PrintMinsDistanceInformation()
    {
        Debug.Log("Bolsa más cercana : " + "( " + _moneyBagPosX + ", " + _moneyBagPosY + ") ");
    }

    public void SetTargetMoneyBag(int posX, int posY)
    {
        _moneyBagPosX = posX;
        _moneyBagPosY = posY;

        if (_moneyBagPosY == _posY)
            _finalPosYReached = true;
        if (_moneyBagPosX == _posX)
            _finalPosXReached = true;
    }

    public void LookForTarget()
    {
        PrintMinsDistanceInformation();
        if (_finalPosXReached && _finalPosYReached) return;

        System.Random rnd = new System.Random();
        int r = rnd.Next(0, 2);

        if(r == 0)
        {
            if(_finalPosXReached)
                LookForTargetY();
            else 
                LookForTargetX();
        }
        else
        {
            if (_finalPosYReached)
                LookForTargetX();
            else 
                LookForTargetY();
        }

    }
    void LookForTargetX()
    {
        if (_posX < _moneyBagPosX)
            _posX++;
        else if (_posX > _moneyBagPosX)
            _posX--;
        else {
            _finalPosXReached = true;
        }
    }

    void LookForTargetY()
    {
        if (_posY < _moneyBagPosY)
            _posY++;
        else if (_posY > _moneyBagPosY)
            _posY--;
        else
        {
            _finalPosYReached = true;
        }

    }
}
