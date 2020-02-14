﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour {

    [Range(1f, 10f)]
    public float velocidadAndar = 1f;
    [Range(1f, 10f)]
    public float velocidadCorrer = 2f;
    [Tooltip("Layer de los objetos que no podrá atravesar (estos deben tener collider)")]
    public LayerMask layerColision;
    [Tooltip("Layer de los objetos que no podrá atravesar (estos deben tener collider)")]
    public LayerMask layerObject;
    [Tooltip("Tamaño de las casillas del Tilemap, si se usa el Tilemap de Unity será el CellSize del Grid")]
    public float tamanioCasilla = 1;
    public KeyCode teclaCorrer;

    [SerializeField]
    Transform rayOrigin;

    private Vector2 siguientePosicion;
    private bool collisioned;
    private RaycastHit2D ray;
    private Vector2 direccionRayo;
    private float velocidadActual;

    Stack<GameObject> bag;
	private void Start ()
    {
        bag = new Stack<GameObject>();
        siguientePosicion = transform.position;
        velocidadActual = velocidadAndar;
    }

       
	
    private void Update()
    {
        AsignarVelocidadMovimiento();
        AsignarDireccionMovimiento();
        Mover();
        TakeObject();
        ReleaseObject();
    }

    private void AsignarVelocidadMovimiento()
    {
        if (Input.GetKeyDown(teclaCorrer))
        {
            velocidadActual = velocidadCorrer;
        }
        else
        {
            velocidadActual = velocidadAndar;
        }
    }

    private void AsignarDireccionMovimiento()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            direccionRayo = Vector2.right;
            if (PuedeMoverseALaSiguienteCasilla())
            {
                siguientePosicion.x += tamanioCasilla;

            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            direccionRayo = Vector2.left;
            if (PuedeMoverseALaSiguienteCasilla())
            {
                siguientePosicion.x -= tamanioCasilla;
            }

        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            direccionRayo = Vector2.up;
            if (PuedeMoverseALaSiguienteCasilla())
            {
                siguientePosicion.y += tamanioCasilla;
            }
          
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            direccionRayo = Vector2.down;
            if (PuedeMoverseALaSiguienteCasilla())
            {
                siguientePosicion.y -= tamanioCasilla;
            }
        }


    }

    private void Mover()
    {
        transform.position = Vector2.MoveTowards(transform.position, siguientePosicion, velocidadCorrer * Time.deltaTime);

    }

    private bool PuedeMoverseALaSiguienteCasilla()
    {
        //Si en la dirección del próximo movimiento hay un collider del layer definido como obstáculo no se puede mover
        RaycastHit2D rHitCollisions = Physics2D.Raycast(rayOrigin.position, direccionRayo, tamanioCasilla / 2.0f, layerColision);
        RaycastHit2D rHitObject = Physics2D.Raycast(rayOrigin.position, direccionRayo, tamanioCasilla / 2.0f, layerObject);
        if (rHitCollisions || rHitObject)
        {
            return false;
        }
        //Si está casi en la siguiente posición sí puede volver a moverse
        else if (Mathf.Abs(siguientePosicion.y - transform.position.y) < float.Epsilon && Mathf.Abs(siguientePosicion.x - transform.position.x) < float.Epsilon)
        {
            return true;
        }

        return false;
    }

    private void TakeObject()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            //Si en la dirección del próximo movimiento hay un collider del layer definido como obstáculo no se puede mover
            RaycastHit2D rHitObject = Physics2D.Raycast(rayOrigin.position, direccionRayo, tamanioCasilla / 2.0f, layerObject);
            if (rHitObject)
            {
                Debug.Log("estoy recogiendo objeto)");
                bag.Push(rHitObject.collider.gameObject);
                rHitObject.collider.gameObject.SetActive(false);
            }
        }
    }
    
   private void ReleaseObject()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (bag.Count > 0)
            {
                //Si en la dirección del próximo movimiento hay un collider del layer definido como obstáculo no se puede mover
                RaycastHit2D rHitCollisions = Physics2D.Raycast(rayOrigin.position, direccionRayo, tamanioCasilla / 2.0f, layerColision);
                if (!rHitCollisions)
                {
                    GameObject collectible = bag.Peek();
                    bag.Pop();

                    collectible.transform.position = new Vector2(transform.position.x + direccionRayo.x, transform.position.y + direccionRayo.y);
                    collectible.SetActive(true);
                }
            }
        }
    }
}
