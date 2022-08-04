using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeTime;
    private float shakeIntensity;

    public void Update() {
        //if(Input.GetKeyDown("1"))
        if(Gun.shootCamera)
        {
            OnShakeCamera(0.1f, 1f);
        }
    }

    public void OnShakeCamera(float shakeTime = 1f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    private IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;

        while(shakeTime > 0.0f)
        {
            float z = 1f;
            transform.position = startPosition + new Vector3(0, 0, z) * shakeIntensity;

            shakeTime -= Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
