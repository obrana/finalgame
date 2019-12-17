using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationControllerScript : MonoBehaviour
{
    public GameObject[] Pokemons;
    GameObject randomPokemonGO;
    public Transform Trainer;
    public Transform Map;
    int randomPokemon;
    int randomX;

    // Start is called before the first frame update
    void Start()
    {
        MyRandomPokemon();
    }
    void MyRandomPokemon()
    {
        randomPokemon = Random.Range(0, Pokemons.Length);
        randomX = Random.Range(-10, 10);
        randomPokemonGO = Instantiate(Pokemons[randomPokemon], new Vector3(randomX, Map.position.y, Map.position.z), Quaternion.identity) as GameObject;
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(randomPokemonGO.transform.position, Trainer.position);
        print(distance);

        if(distance <=5f && randomPokemonGO.tag =="randomCharizard")
        {
            SceneManager.LoadScene("FightScene");
        }
    }
}
