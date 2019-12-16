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
    public GameObject FightButtons;
    public GameObject StartButtons;
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
            case "selectOption":
                InfoText.text = "";
                ConfirmButton.SetActive(false);
                SelectBar.gameObject.SetActive(true);
                StartButtons.gameObject.SetActive(true);
                FightButtons.gameObject.SetActive(false);
                break;

            case "caughtCharizard":
                InfoText.text = "CHARIZARD was Caught";
                break;

            case "ashUsedPokeball":
                InfoText.text = "ASH uses POKEBALL";
                break;

            case "enemyattacks":
                ConfirmButton.SetActive(false);
                int RandomAttack = Random.Range(1, 2);

                if (RandomAttack == 0)
                {
                    InfoText.text = "CHARIZARD used FLY";
                    charizardControlScript.Instance.Fly();

                }
                else if (RandomAttack == 1)
                {
                    InfoText.text = "CHARIZARD used FLAMETHROWER";
                    charizardControlScript.Instance.FlameThrower();
                }
                GameStatus = "selectOption";
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
