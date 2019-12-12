using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuControlScript : MonoBehaviour
{
    public static pikachuControlScript Instance { set; get;}
    public bool pikachuMove;

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
    }
    public void Growl()
    {
        gameObject.GetComponent<Animator>().Play("Attack");
        pikachuMove = true;
    }
}
