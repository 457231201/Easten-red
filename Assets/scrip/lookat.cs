using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject man;
    public GameObject sun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sun.transform.LookAt(man.transform.position);
    }
}
