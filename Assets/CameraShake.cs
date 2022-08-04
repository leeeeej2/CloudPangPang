using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeTime;
    private float shakeIntensity;
    private int preLifeSystem;

    public void Update() {
        //if(Input.GetKeyDown("1"))
        if(preLifeSystem - HealthManager.lifeSystem != 0)
        {
            OnShakeCameraAttacked(0.1f, 1f);
        }

        if(Gun.shootCamera)
        {
            OnShakeCameraShoot(0.1f, 1f);
        }
        preLifeSystem = HealthManager.lifeSystem;
    }

    public void OnShakeCameraShoot(float shakeTime = 1f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    public void OnShakeCameraAttacked(float shakeTime = 1f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByRotation");
        StartCoroutine("ShakeByRotation");
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

    private IEnumerator ShakeByRotation()
    {
        Vector3 startRotation = transform.eulerAngles;
        float power = 10f;
        while(shakeTime > 0.0f)
        {
            float z = Random.Range(-1f, 1f);
            transform.rotation = Quaternion.Euler(startRotation + new Vector3(0, 0, z) * shakeIntensity * power);

            shakeTime -= Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(startRotation);
        //AIBullet.cameraAttacked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
