using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class forLogoScene : MonoBehaviour
{
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            transform.SetSiblingIndex(0);
            //gameObject.SetActive(false);
            //this.transform.position = new Vector3(500, 500, 500);
        }

        if (timer > 4)
        {
            SceneManager.LoadScene("StartScreen");
            timer = 0;
        }
    }
}
