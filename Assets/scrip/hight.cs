using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camara;
    public Text hText;
    public Image tiao;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform targetTransform = camara.transform;

        // 获取目标对象在世界空间中的Y轴值
        float height = targetTransform.position.y;

        string highttext = height.ToString("F2");
        
            hText.text = "HIGHT."+(highttext) + "m";

         // 获取图片的RectTransform组件
        RectTransform rectTransform = tiao.GetComponent<RectTransform>();

        // 设置新的宽度和高度
        

         if(height<=80)
            {
                rectTransform.sizeDelta = new Vector2(100, height*10);
            }
            else
            {
                rectTransform.sizeDelta = new Vector2(100, 800);
            }
    }
}
