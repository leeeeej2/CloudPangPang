using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotOut : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainObject;

    public float maxCameraX = 1f;
    public float minCameraX = 0;
    public float maxCameraY = 1f;
    public float minCameraY = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var find = mainObject.GetComponent<Camera>();

        if (find != null)
        {
            Vector3 worldpos = Camera.main.WorldToViewportPoint(find.transform.position);

            Debug.Log(worldpos.x);
            Debug.Log(worldpos.y);

            if (worldpos.x < minCameraX)
            {
                worldpos.x = minCameraX;
            }

            if (worldpos.y < minCameraY)
            {
                worldpos.y = minCameraY;
            }

            if (worldpos.x > maxCameraX)
            {
                worldpos.x = maxCameraX;
            }

            if (worldpos.y > maxCameraY)
            {
                worldpos.y = maxCameraY;
            }

            this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
        }
    }
}
