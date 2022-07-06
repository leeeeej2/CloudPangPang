using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject mainObject;

    public float xMax = -15f;
    public float xMin = -50f;

    public float yMax = 0;
    public float yMin = 25f;

    public float zMax = 25f;
    public float zMin = 30f;

    GameObject newEnemy;
    public static bool isDie = false;
    bool isFirst = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isFirst)
        {
            newEnemy = Instantiate(enemy);

            //Vector3 mainPosition = mainObject.transform.position;
            //newEnemy.transform.position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            newEnemy.transform.position = new Vector3(-28.8f, 17.3f, 23.8f);
            isFirst = false;
        }

        if (isDie)
        {
            Debug.Log("new enemy");
            newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector3(-28.8f, 17.3f, 23.8f);
            isDie = false;
        }
    }
}
