using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuControlScript : MonoBehaviour
{
    bool pikachuMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("CharizardGo") != null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("CharizardGo").transform.position);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

    }
    public void Growl()
    {
        gameObject.GetComponent<Animator>().Play("Attack");
        pikachuMove = true;
    }
}
