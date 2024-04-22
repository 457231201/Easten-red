using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour

{
    public GameObject bird1;
    public GameObject man;

    void Update()
    {
       bird1.transform.RotateAround(man.transform.position, Vector3.up, 15* Time.deltaTime);
    }
}
    
