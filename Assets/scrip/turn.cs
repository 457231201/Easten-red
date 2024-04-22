using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sun;
    public float rotationSpeed = 50f; // 旋转速度

    float timer = 0;

    void Update()
    {
        
        timer += Time.deltaTime;
        // 让物体绕着Z轴旋转
        sun.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        if (timer>9)
        {
            Destroy(sun);
        }
    }
}
