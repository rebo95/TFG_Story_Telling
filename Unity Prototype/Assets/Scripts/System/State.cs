using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    [SerializeField]
    private int _objetiveMoney = 300;
    private int _currentMoney = 0;

    [SerializeField]
    private int _numBags = 2;

    [SerializeField]
    private int _boardRows = 6, _boardCols = 6;


    private Player _firstPlayer = new Player();
    private Money[] _money;


    private bool[,] _board;

    private float _minDistance;
    private int _minDistanceIndex = 0;



    void Start()
    {
        _money = new Money[_numBags];
        _board = new bool[_boardRows, _boardCols];

        for (int i = 0; i < _money.Length; i++)
            _money[i] = new Money();


        _money[0].PosX = 5;
        _money[0].PosY = 1;
        _money[0].Quantity = 200;


        _money[1].PosX = 0;
        _money[1].PosY = 1;
        _money[1].Quantity = 300;

        _minDistance = Mathf.Sqrt((0 -_boardRows - 1) ^ 2 + (0 - _boardCols - 1 ) ^ 2);
    }


    void Update()
    {
        if (HandleInput())
        {
            LookForMinDistance();
            PrintMinsDistanceInformation();
        }
    }


    bool HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _firstPlayer.PosY++;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _firstPlayer.PosY--;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _firstPlayer.PosX--;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _firstPlayer.PosX++;
            return true;
        }

        return false;

    }

    float  CalculateDistance(Player p, Money m)
    {
        float distance = 0;

        distance = Mathf.Sqrt( (p.PosX - m.PosX)^2 + (p.PosY - m.PosY)^2 );

        return distance;
    }

    void IsMinDistance(float distance, int index)
    {
        if(distance < _minDistance)
        {
            _minDistance = distance;
            _minDistanceIndex = index;
        }
    }

    void LookForMinDistance()
    {
        for (int i = 0; i < _money.Length; i++)
        {
            IsMinDistance(CalculateDistance(_firstPlayer, _money[i]), i);
        }
    }

    void PrintMinsDistanceInformation()
    {
        Debug.Log("Bolsa más cercana : " + "( " + _money[_minDistanceIndex].PosX + ", " + _money[_minDistanceIndex].PosY + ") ");
    }
}
