using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pikachuControlScript : MonoBehaviour
{
    public static pikachuControlScript Instance { set; get;}
    public bool pikachuMove;
    public float quickAttackValue = 20;
    float pikachuHealth = 100f;
    Image HPBar;

    // Start is called before the first frame update
    void Start()
    {
       Instance = this;  
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("CharizardGo") != null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("CharizardGo").transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        if (pikachuMove)
        {
            transform.Translate(Vector3.forward * Time.deltaTime *3f);
        }
        if(pikachuHealth <= 0)
        {
            StartCoroutine(waitThenDead());
        }
    }
    public void Growl()
    {
        charizardControlScript.Instance.quickAttackFromPikachu(quickAttackValue, false);
        gameObject.GetComponent<Animator>().Play("Attack");
        pikachuMove = true;
        GameControllerScript.GameStatus = "pikachuUsedGrowl";
        GameControllerScript.Instance.gameStatusInfoBar();
    }
    public void flyAttackFromCharizard ( float flyValue, bool collisionWithCharizard)
    {
        HPBar = GameObject.Find("HPBarBackground").GetComponent<Image>();
        pikachuHealth -= flyValue;
        if (collisionWithCharizard)
        {
            HPBar.fillAmount = pikachuHealth / 100f;
        }
    }
    public void flamethrowerFromCharizard(float flameThrowerValue)
    {
        HPBar = GameObject.Find("HPBarBackground").GetComponent<Image>();
        pikachuHealth -= flameThrowerValue;
        HPBar.fillAmount = pikachuHealth / 100f;
    }
    IEnumerator waitThenDead()
    {
        yield return new WaitForSeconds(2.5f);
        GameControllerScript.GameStatus = "pikachuIsDead";
        GameControllerScript.Instance.gameStatusInfoBar();
        gameObject.SetActive(false);
    }
}
