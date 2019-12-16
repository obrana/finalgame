using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript Instance { set; get; }
    public static string GameStatus;
    public Text InfoText;
    public GameObject SelectBar;
    public GameObject ConfirmButton;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

    }

    // Update is called once per frame
   public void gameStatusInfoBar()
    {
        switch (GameStatus)
        {
            case "caughtCharizard":
                InfoText.text = "CHARIZARD was Caught";
                break;

            case "ashUsedPokeball":
                InfoText.text = "ASH uses POKEBALL";
                break;

            case "enemyattacks":
                int RandomAttack = Random.Range(0, 1);

                if (RandomAttack == 0)
                {
                    InfoText.text = "CHARIZARD used FLY";
                    charizardControlScript.Instance.Fly();

                }
                else if (RandomAttack == 1)
                {
                    InfoText.text = "CHARIZARD used FLAMETHROWER";
                }
                break;

            case "pikachuUsedThundershock":
                InfoText.text = "PIKACHU used THUNDERSHOCK";
                break;

            case "pikachuUsedGrowl":
                
                InfoText.text = "PIKACHU used QUICKATTACK";
                SelectBar.gameObject.SetActive(false);
                ConfirmButton.SetActive(false);
                GameStatus = "enemyattacks";
                break;

            case "pokemonIsOut":
                InfoText.text = "GO! PIKACHU!";
                break;

            case "enemyAppeared":
                InfoText.text = "Choose your Pokemon";
                break;

            case "fightHasStarted":
                InfoText.text = "wild CHARIZARD appreared";
                break;

            default:
                InfoText.text = "hello";
                break;
        }

    }
}
