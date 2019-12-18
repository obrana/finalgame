using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charizardControlScript : MonoBehaviour
{
    public static charizardControlScript Instance { set; get; }
    bool flyCharizard;
    public bool goCharizard;
    public ParticleSystem FlameThrowerGO;
    public float flyValue = 20f;
    float charizardHealth =100f;
    public float flameThrowerValue = 20f;
    Image HPBar;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("PikachuGO") != null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("PikachuGO").transform.position);
        }
        if (flyCharizard)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 2f);
        }
        if (goCharizard)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5f);
        }
        if (charizardHealth <= 0)
        {
            StartCoroutine(waitThenDead());
        }
     
    }
    public void charizardAppeared()
    {
        soundsControl.Instance.charizardStartSound.Play();
    }
    public void Fly()
    {

            flyCharizard = true;
            StartCoroutine(waitforFlyAttack());
        pikachuControlScript.Instance.flyAttackFromCharizard(flyValue, false);
    }
    IEnumerator waitforFlyAttack()
    {
        yield return new WaitForSeconds(1.5f);
        flyCharizard = false;
        yield return new WaitForSeconds(0.5f);
        goCharizard = true;
        gameObject.GetComponent<Animator>().Play("flyAttack");
    }
    public void FlameThrower()
    {
        StartCoroutine(waitForFlameThrower());
       // pikachuControlScript.Instance.flamethrowerFromCharizard(flameThrowerValue);
    }
    IEnumerator waitForFlameThrower()
    {
        gameObject.GetComponent<Animator>().Play("flamethrower");
        yield return new WaitForSeconds(1f);
        FlameThrowerGO.Play();
        soundsControl.Instance.flamethrowerSound.Play();
        yield return new WaitForSeconds(0.5f);
        pikachuControlScript.Instance.flamethrowerFromCharizard(flameThrowerValue);
        GameObject.Find("Pikachu").GetComponent<Animator>().Play("attackFromCharizard");
        yield return new WaitForSeconds(1.2f);
        FlameThrowerGO.Stop();
        GameControllerScript.Instance.ConfirmButton.SetActive(true);

    }
    public void quickAttackFromPikachu(float quickAttackValue, bool collisionWithPikachu)
    {
        HPBar = GameObject.Find("HPBarBackgroundEnemy").GetComponent<Image>();
        charizardHealth -= quickAttackValue;
        if (collisionWithPikachu)
        {
            HPBar.fillAmount = charizardHealth / 100f;
        }
    }
    IEnumerator waitThenDead()
    {
        yield return new WaitForSeconds(2.5f);
        GameControllerScript.GameStatus = "enemyIsDead";
        GameControllerScript.Instance.gameStatusInfoBar();
        gameObject.SetActive(false);
    }
}
