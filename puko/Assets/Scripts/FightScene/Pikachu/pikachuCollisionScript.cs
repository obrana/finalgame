using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuCollisionScript : MonoBehaviour
{
    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.tag == "charizardCollision")
        {
            pikachuControlScript.Instance.pikachuMove = false;
            GameObject.Find("Pikachu").transform.position = GameObject.Find("MyPokemon").transform.position;
            GameObject.Find("Pikachu").GetComponent<Animator>().Play("pikashuIDLE");
            GameObject.FindGameObjectWithTag("CharizardGo").GetComponent<Animator>().Play("collisionWithPikashu");
        }
    }

    public static implicit operator pikachuCollisionScript(pikachuControlScript v)
    {
        throw new NotImplementedException();
    }
}
