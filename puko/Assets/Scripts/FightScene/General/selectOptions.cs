using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectOptions : MonoBehaviour
{
    public GameObject StartButtons;
    public GameObject FightButtons;
    public GameObject Items;

    public void onFight()
    {
        StartButtons.gameObject.SetActive(false);
        FightButtons.gameObject.SetActive(true);
    }
    public void onItem()
    {
        StartButtons.gameObject.SetActive(false);
        Items.gameObject.SetActive(true);
    }
    public void onPokemon()
    {

    }
    public void onRun()
    {

    }

}

