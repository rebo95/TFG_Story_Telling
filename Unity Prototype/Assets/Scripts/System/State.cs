using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    [SerializeField]
    GameObject _objectMoney;
    [SerializeField]
    GameObject _objectPlayer;
    [SerializeField]
    GameObject _objectPosition;



    [SerializeField]
    private int _objetiveMoney = 300;
    private int _currentMoney = 0;

    [SerializeField]
    private int _numBags = 4;

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

        for (int i = 0; i < _numBags; i++)
            _money[i] = new Money();


        _money[0].PosX = 5;
        _money[0].PosY = 0;
        _money[0].Quantity = 200;


        _money[1].PosX = 0;
        _money[1].PosY = 0;
        _money[1].Quantity = 300;


        _money[2].PosX = 0;
        _money[2].PosY = 5;
        _money[2].Quantity = 200;


        _money[3].PosX = 3;
        _money[3].PosY = 3;
        _money[3].Quantity = 300;

        _firstPlayer.PosX += 0;

        _minDistance = Mathf.Sqrt(Mathf.Pow((0 - _boardRows - 1), 2)+ Mathf.Pow((0 - _boardCols - 1), 2));
        LookForMinDistance();
        PrintMinsDistanceInformation();


        SetMoneyBagPosition();
        SetPlayerPosition();
        SetStandPointsPosition();
    }


    void Update()
    {
        if (HandleInput())
        {
            LookForMinDistance();
            PrintMinsDistanceInformation();
            _minDistance = Mathf.Sqrt(Mathf.Pow((0 - _boardRows - 1), 2) + Mathf.Pow((0 - _boardCols - 1), 2));
        }
    }


    bool HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _firstPlayer.PosY++;
            UpdatePlayerPosition();
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _firstPlayer.PosY--;
            UpdatePlayerPosition();
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _firstPlayer.PosX--;
            UpdatePlayerPosition();
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _firstPlayer.PosX++;
            UpdatePlayerPosition();
            return true;
        }


        return false;

    }

    float  CalculateDistance(Player p, Money m)
    {
        float distance = 0;

        distance = Mathf.Sqrt(Mathf.Pow((p.PosX - m.PosX), 2) + Mathf.Pow((p.PosY - m.PosY), 2));

        return distance;
    }

    void IsMinDistance(float distance, int index)
    {
        if (distance <= _minDistance)
        {
            _minDistance = distance;
            _minDistanceIndex = index;
        }
    }

    void LookForMinDistance()
    {
        for (int i = 0; i < _money.Length; i++)
        {
            float distance = CalculateDistance(_firstPlayer, _money[i]);
            IsMinDistance(distance, i);
        }
    }

    void PrintMinsDistanceInformation()
    {
       Debug.Log("Bolsa más cercana : " + "( " + _money[_minDistanceIndex].PosX + ", " + _money[_minDistanceIndex].PosY + ") ");
    }




    int offset = 3;
    void SetStandPointsPosition()
    {
        for(int i = 0; i < _boardRows; i++)
        {
            for (int j = 0; j < _boardRows; j++)
            {
                Instantiate(_objectPosition, new Vector3(j - offset, i - offset, 0), new Quaternion(0,0,0,0));
            }
        }
    }

    GameObject _movableObjectPlayer;
    void SetPlayerPosition()
    {
        _movableObjectPlayer = Instantiate(_objectPlayer, new Vector3(_firstPlayer.PosX - offset, _firstPlayer.PosY - offset, 0), new Quaternion(0, 0, 0, 0));
 
    }

    void SetMoneyBagPosition()
    {
        for (int i = 0; i < _numBags; i++)
        {
            Instantiate(_objectMoney, new Vector3(_money[i].PosX - offset, _money[i].PosY - offset, 0), new Quaternion(0, 0, 0, 0));
        }
    }

    void UpdatePlayerPosition()
    {
        _movableObjectPlayer.transform.position = new Vector3(_firstPlayer.PosX - offset, _firstPlayer.PosY - offset, 1);
    }
}
