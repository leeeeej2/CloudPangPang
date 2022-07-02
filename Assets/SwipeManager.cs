using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwipeManager : MonoBehaviour
{
    private Vector3 firstPostiion;
    private Vector3 lastPosition;
    
    private float dragDistance = 0.25f;
    
    public float maxCameraX = 1f;
    public float minCameraX = 0;
    public float maxCameraY = 1f;
    public float minCameraY = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstPostiion = touch.position;
                lastPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lastPosition = touch.position;
                if (Mathf.Abs(lastPosition.x - firstPostiion.x) <= Mathf.Abs(lastPosition.y - firstPostiion.y))
                {
                    //float dist = Mathf.Abs(lastPosition.y - firstPostiion.y);
                    if (lastPosition.y > firstPostiion.y)
                    {
                        //up
                        transform.position = new Vector3(transform.position.x, transform.position.y + dragDistance, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - dragDistance, transform.position.z);
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lastPosition = touch.position;
                /*if(Mathf.Abs(lastPosition.y - firstPostiion.y) > dragDistance)
                {
                    if(Mathf.Abs(lastPosition.x - firstPostiion.x) <= Mathf.Abs(lastPosition.y - firstPostiion.y))
                    {
                        if(lastPosition.y > firstPostiion.y)
                        {
                            //up
                            transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
                        }
                        else{
                            transform.position = new Vector3(transform.position.x,transform.position.y - 2.5f, transform.position.z);
                        }
                    }
                }*/
            }

            Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);

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
