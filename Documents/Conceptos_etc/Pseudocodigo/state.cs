// STATE - - - Concepto
using System;
using System.Collections.Generic;

const MAX_CUADRICULA;

// Bolsas de dinero
public class MoneyBag
{
    public int posX;
    public int posY;
    bool pickedUp;

    public MoneyBag(x, y, pUp)
    {
        posX = x;
        posY = y;
        pickedUp = pUp;
    }
    
    public void pickUp()
    {
        pickedUp = true;
    }

    public bool beenPickedUp()
    {
        return pickedUp;
    }
}

// Personajes
public class Character
{
    public int posX;
    public int posY;
    bool hasMoney;

    public Character(x, y, hMoney)
    {
        posX = x;
        posY = y;
        hasMoney = hMoney;
    }

    public void getMoney()ç
    {
        hasMoney = true;
    }

    public bool hasMoney()
    {
        return hasMoney;
    }

    public void changePos(x, y)
    {
        posX = x;
        posY = y;
    }
}

// Estado
public class State
{
    public MoneyBag money;
    public Character character;

    // Metodo de inicializacion
    public void init(cX, cY, mX, mY)
    {
        characters = new Character(cX, cY, false);
        money = new MoneyBag(mX, mY, false);
    }
}