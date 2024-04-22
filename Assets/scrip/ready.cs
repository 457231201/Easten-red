using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ready: MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject panelToDelete;

   
   void Start()
    {
        panelToDelete = GameObject.Find("shuom"); // 用实际的面板名称替换"YourPanelName"

        // 获取按钮组件
        Button button = GetComponent<Button>();

        // 添加点击事件监听器
        button.onClick.AddListener(OnButtonClick);
    }
   public void OnButtonClick()
    {
        // 检查是否存在需要删除的面板
        if (panelToDelete != null)
        {
            // 删除面板
            Destroy(panelToDelete);
        }
    }
}