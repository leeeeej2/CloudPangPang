using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotOut : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainObject;
    public Vector3 firstPosition;

    //GameObject child;
    //Component find;

    float yRange = 0;
    float xRange = 0;

    public static bool rightMove = true;
    public static bool leftMove = true;
    public static bool upMove = true;
    public static bool downMove = true;

    void Start()
    {
        //child = mainObject.transform.GetChild(6).gameObject;
        firstPosition = transform.position;
        //find = child.GetComponent<Camera>();

        //Vector3 limit = Camera.main.WorldToViewportPoint(find.transform.position);
        //Vector3 curPosition = Camera.main.ViewportToWorldPoint(limit);

        xRange = 2 * Camera.main.orthographicSize;//2 * (Screen.height / 10) / 2;
        yRange = xRange * Camera.main.aspect;

        //xRange = Screen.width / 2;
        //yRange = Screen.height / 2;
        //xRange = Mathf.Abs(1 - curPosition.x);
        //yRange = Mathf.Abs(1 - curPosition.y);
        
        //Debug.Log("x range");
        //Debug.Log(xRange);
        //Debug.Log("y range");
        //Debug.Log(yRange);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("X");
        //Debug.Log(Mathf.Abs(transform.position.x - firstPosition.x));
        //Debug.Log("Y");
        //Debug.Log(Mathf.Abs(transform.position.y - firstPosition.y));

        if (Mathf.Abs(transform.position.x - firstPosition.x) > (xRange + transform.localScale.x))
        {
            //Debug.Log("X OUT");

            if (firstPosition.x > transform.position.x)
            {
                leftMove = false;
                rightMove = true;
            }
            else
            {
                rightMove = false;
                leftMove = true;
            }
        }
        else
        {
            leftMove = true;
            rightMove = true;
        }

        if (Mathf.Abs(transform.position.y - firstPosition.y) > ((yRange / 2) - (transform.localScale.y)))
        {
            //Debug.Log("Y OUT");

            if (firstPosition.y > transform.position.y)
            {
                downMove = false;
                upMove = true;
            }
            else
            {
                upMove = false;
                downMove = true;
            }
        }
        else
        {
            upMove = true;
            downMove = true;
        }
    }
    

    static Vector3 myWorldToViewportPoint(Vector3 point3D)
    {
        Matrix4x4 P = Camera.main.projectionMatrix;
        Matrix4x4 V = Camera.main.transform.worldToLocalMatrix;
        Matrix4x4 VP = P * V;

        Vector4 point4 = new Vector4(point3D.x, point3D.y, point3D.z, 1.0f);
        Vector4 result4 = VP * point4;

        Vector3 result = result4;

        result /= -result4.w;

        result.x = result.x / 2 + 0.5f;
        result.y = result.y / 2 + 0.5f;

        result.z = -result4.w;

        var _result = Camera.main.WorldToViewportPoint(point3D);

        return _result;
    }

    static Vector3 myViewportToWorldPoint(Vector3 point2D)
    {

        Matrix4x4 P = Camera.main.projectionMatrix;
        Matrix4x4 V = Camera.main.transform.worldToLocalMatrix;
        Matrix4x4 VP = P * V;

        Vector3 point2DCopy = point2D;

        point2DCopy.x = 2.0f * (point2DCopy.x - 0.5f);
        point2DCopy.y = 2.0f * (point2DCopy.y - 0.5f);

        Vector4 point4 = new Vector4(point2DCopy.x, point2DCopy.y, point2DCopy.z, 1.0f); 

        Vector4 result4 = VP.inverse * point4; 

        Vector3 result = result4;

        var _result = Camera.main.ViewportToWorldPoint(point2D);

        return _result;
    }
}
