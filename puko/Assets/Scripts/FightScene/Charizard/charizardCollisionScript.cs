using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charizardCollisionScript : MonoBehaviour
{
    public bool collisionWithCharizard = true;
    void OnCollisionEnter(Collision Coll)
    {
        if (Coll.gameObject.tag == "pikachuCollision" && charizardControlScript.Instance.goCharizard)
        {
            charizardControlScript.Instance.goCharizard = false;
            GameObject.FindGameObjectWithTag("CharizardGO").transform.position = GameObject.Find("EnemyPokemon").transform.position;
            GameObject.FindGameObjectWithTag("CharizardGO").GetComponent<Animator>().Play("CharizardIDLE");
            GameObject.FindGameObjectWithTag("Pikashu").GetComponent<Animator>().Play("attackFromCharizard");
            pikachuControlScript.Instance.flyAttackFromCharizard(0f, collisionWithCharizard);
            GameControllerScript.Instance.ConfirmButton.SetActive(true);
        }
    }


}
