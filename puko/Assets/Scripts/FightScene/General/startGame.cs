using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public Image BlackScreen;
    float fillAmount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartFight());
    }

    IEnumerator StartFight()
    {
        BlackScreen.gameObject.SetActive(true);
        soundsControl.Instance.fightsound.Play();

        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i <= 20; i++)
        {
            float randomAlpha = Random.Range(0.0f, 1.0f);
            yield return new WaitForSeconds(0.05f);
            BlackScreen.color = new Color(0f, 0f, 0f, randomAlpha);
        }
        BlackScreen.color = new Color(0f, 0f, 0f, 1.0f);
        BlackScreen.fillAmount = 0f;
        while (fillAmount <= 1)
        {
            yield return new WaitForSeconds(0.03f);
            fillAmount += 0.05f;
            BlackScreen.fillAmount = fillAmount;
        }
        yield return new WaitForSeconds(0.8f);
        for (int i = 0; i <=2; i++)
        {
            yield return new WaitForSeconds(0.05f);
            BlackScreen.color = new Color(0f, 0f, 0f, 1f);
            yield return new WaitForSeconds(0.05f);
            BlackScreen.color = new Color(0f, 0f, 0f, 0f);
        }
        GameControllerScript.GameStatus = "fightHasStarted";
        GameControllerScript.Instance.gameStatusInfoBar();
        charizardControlScript.Instance.charizardAppeared();

        BlackScreen.gameObject.SetActive(false);

    }
}
