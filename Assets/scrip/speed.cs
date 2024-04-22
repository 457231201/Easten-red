using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed : MonoBehaviour
{
    public GameObject camara;
    private Vector3 lastPosition;
    private float totalDistance;
    private float totalTime;

    float speedNum = 0.0f;
    //float round = 0.0f;
    public Text speedText;
    public Image zhizhen;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // 获取物体当前位置
        Vector3 currentPosition = camara.transform.position;

        // 计算当前帧的位移
        float distance = Vector3.Distance(currentPosition, lastPosition);

        // 更新总位移和总时间
        totalDistance += distance;
        totalTime += Time.deltaTime;

        // 更新上一帧的位置
        lastPosition = currentPosition;

        


        // 如果总时间超过1秒，则计算平均速度并重置计数器
        if (totalTime >= 0.5f)
        {
            // 计算平均速度（每秒移动的单位数）
            float averageSpeed = totalDistance / totalTime;

            // 打印平均速度（每秒移动的单位数）
            speedNum=averageSpeed;
            
            string formattedNumber = speedNum.ToString("F2");
        
            speedText.text = (formattedNumber) + " m/s";
            RectTransform rectTransform = zhizhen.GetComponent<RectTransform>();

        // 设置Z轴旋转角度为13.5度
            if(speedNum<=20)
            {
                rectTransform.rotation = Quaternion.Euler(0f, 0f,-speedNum* 13.5f);
            }
            else
            {
                rectTransform.rotation = Quaternion.Euler(0f, 0f,-270);
            }
            
            // 重置计数器
            totalDistance = 0.0f;
            totalTime = 0.0f;
        }
    
    }
}
