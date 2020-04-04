using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int _posX = 0;
    private int _posY = 0;

    [SerializeField]
    private int _playerVel = 1;

    private bool _hasMoney = false;

    string _positionStirng = "";

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }


    void UpdatePosition()
    {
        if (HandleInput()) 
            PrintPosition();
    }

    bool HandleInput()
    {
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _posY++;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _posY--;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _posX--;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _posX++;
            return true;
        }

        return false;
    }

    void PrintPosition()
    {
        _positionStirng = "(" + _posX + ", " + _posY + ")";
        Debug.Log(_positionStirng);
    }
}
