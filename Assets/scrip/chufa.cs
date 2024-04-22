using System.Collections;
using System.Collections.Generic;
//using Microsoft.SqlServer.Server;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;


public class chufa : MonoBehaviour
{
    public GameObject man;
    public GameObject fireWork;
    public GameObject sun;
    public GameObject sunProfab;
    public GameObject jiantou;
    public GameObject jiantouProfab;

   public Transform object1; // 第一个物体的Transform组件
    public Transform object2; // 第二个物体的Transform组件

    public time scriptB;

    //public GameObject jian;

    public static int nums=0;
    //public static int time = 0;
    public Text text;


    

    public PostProcessVolume postProcessVolume;

    private ChromaticAberration chromaticAberration;
    private LensDistortion lensDistortion;

    float timer=0;
    bool Trigger=false;

    private float initialYPos;
     private bool hasMovedUp ;
   
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
        postProcessVolume.profile.TryGetSettings(out lensDistortion);
        chromaticAberration.enabled.value = !chromaticAberration.enabled.value;
        lensDistortion.enabled.value = !lensDistortion.enabled.value;
        initialYPos = man.transform.position.y;
        
        scriptB = man.GetComponent<time>();
        scriptB.enabled = false;
         hasMovedUp = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        float distance = Vector3.Distance(man.transform.position, object2.position);
        if (distance < 1.5f)
        {
            Vector3 newSunPosition = sun.transform.position + new Vector3(2f, 0f, 0f);
            GameObject newSun = Instantiate(sunProfab, newSunPosition, Quaternion.identity);
            Destroy(sun);
            sun = newSun;
        }

        if (jiantou != null && sun != null)
        {
            // 计算 jiantou 在摄像机局部空间的固定位置
            Vector3 direction = sun.transform.position - jiantou.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            jiantou.transform.rotation = rotation;

            StartCoroutine(SetJiantouParent(man.transform.gameObject));
            Vector3 localPosition = new Vector3(0f, -0.5f, 1.78f); // 举例：假设 jiantou 距离摄像机 2 个单位的距离

            // 将局部位置转换为世界空间位置
            
            Vector3 worldPosition = man.transform.TransformPoint(localPosition);

            // 将 jiantou 移动到固定位置
            jiantou.transform.position = worldPosition;
        }



       timer+=Time.deltaTime;

       text.text = " " + nums;

       if (Trigger==true )

       {
        lensDistortion.scale.value +=timer*0.4f;
        lensDistortion.intensity.value+=timer*25;
       }
         
       if (timer>0.4f && Trigger==true)
        {
         lensDistortion.scale.value =1;
         lensDistortion.intensity.value =0;
         chromaticAberration.enabled.value = !chromaticAberration.enabled.value;
         lensDistortion.enabled.value = !lensDistortion.enabled.value;
         Trigger=false;
         }
    if (man.transform.position.y > initialYPos + 1f && hasMovedUp==false)
    {
        sun= Instantiate(sun, man.transform.position+new Vector3(0.02f,0,2.3f), Quaternion.Euler(90,0,0));
        scriptB.enabled = true;
        hasMovedUp=true;
    }
        //if (sun != null)
       // {
            //jian.transform.LookAt(sun.transform.position);
        //}
        
    }
     private void OnTriggerEnter(Collider man)
     {  
        
        timer=0;
    Vector3 move = new Vector3(0f,0.2f,Random.Range(2f,4f));
        Vector3 round = new Vector3(0,0,Random.Range(0,0));
        Instantiate(fireWork,man.transform.position,Quaternion.identity);
        Destroy(sun);
        Destroy(jiantou);
    Vector3 newPosition = new Vector3(man.transform.position.x + move.x, man.transform.position.y, man.transform.position.z + move.z);
        sun = Instantiate(sunProfab, newPosition, Quaternion.Euler(round));
        //sun.transform.LookAt(man.transform.position);
        //sun.transform.Rotate(90,0,0);

       Vector3 positionA = man.transform.position;
       // Vector3 positionB = sun.transform.position;
    Vector3 tz =new (0f,-0.42f,0.66f);

        // 计算中间点
        Vector3 midpoint = (positionA +tz) ;

        // 生成物体C在中间点位置
        jiantou= Instantiate(jiantouProfab, midpoint, Quaternion.identity);
         
        //jiantou.transform.SetParent(man.transform);
        //jiantou.transform.LookAt(sun.transform.position);
         
        chromaticAberration.enabled.value = !chromaticAberration.enabled.value;
        lensDistortion.enabled.value = !lensDistortion.enabled.value;
        Trigger=true;
        
        nums++;

    //float distance = Vector3.Distance(object1.position, object2.position);
    

       
     }

     private IEnumerator SetJiantouParent(GameObject man)
    {
    // 等待下一帧
    yield return null;

    // 将 jiantou 设置为 man 的子对象
    jiantou.transform.SetParent(man.transform);
    jiantou.transform.LookAt(sun.transform.position);
    }   
}
