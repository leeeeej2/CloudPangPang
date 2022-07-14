using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject mainObject;

    GameObject newEnemy;

    public static bool isDie = false;
    bool isFirst = true;

    public float timer = 0;
    public float timeDiff = 1.5f;

    float xRange;
    float yRange;

    float xOffset;
    float yOffset;

    void Start()
    {
        xRange = 2 * Camera.main.orthographicSize;//2 * (Screen.height / 10) / 2;
        yRange = xRange * Camera.main.aspect;

        //xOffset = xRange + transform.localScale.x;
        //yOffset = (yRange / 2) - (transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mainLocation = mainObject.transform.position;

        if (isFirst)
        {
            if(Score.score > 4)
            {
                newEnemy = Instantiate(enemy);

                newEnemy.transform.position = new Vector3(mainLocation.x, mainLocation.y, mainLocation.z + 35f);
                isFirst = false;
            }
        }

        if (isDie)
        {
            timer += Time.deltaTime;

            if(timer > timeDiff)
            {

                Debug.Log("new enemy");

                newEnemy = Instantiate(enemy);

                //newEnemy.transform.position = new Vector3(-28.8f, 17.3f, 23.8f);
                //Vector3 newLocation = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
                newEnemy.transform.position = new Vector3(mainLocation.x, mainLocation.y, mainLocation.z + 35f);

                isDie = false;
                timer = 0;
            }
        }
    }
}
