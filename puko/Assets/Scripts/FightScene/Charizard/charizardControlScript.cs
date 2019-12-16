using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charizardControlScript : MonoBehaviour
{
    public static charizardControlScript Instance { set; get; }
    bool flyCharizard;
    public bool goCharizard;
    public ParticleSystem FlameThrowerGO;
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
     
    }
    public void Fly()
    {
            flyCharizard = true;
            StartCoroutine(waitforFlyAttack());
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
    }
    IEnumerator waitForFlameThrower()
    {
        gameObject.GetComponent<Animator>().Play("flamethrower");
        yield return new WaitForSeconds(1f);
        FlameThrowerGO.Play();
        GameObject.Find("Pikachu").GetComponent<Animator>().Play("attackFromCharizard");
        yield return new WaitForSeconds(1.2f);
        FlameThrowerGO.Stop();
        GameControllerScript.Instance.ConfirmButton.SetActive(true);
    }
}
