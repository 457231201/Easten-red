using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shan : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;
   private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        timer += Time.deltaTime;
        while (true)
        {
            // 等待0.2秒
            if (timer%136>=0 && timer%136<=37)
            {
                yield return new WaitForSeconds(1);
            }
            else if (timer%136<=51 && timer%136>=38)
            {
                yield return new WaitForSeconds(0.6f);
            }
            else if (timer%136<=122 && timer%136>=52)
            {
                yield return new WaitForSeconds(0.6f);
            }
            else if (timer%136>=123 && timer%136<=136)
            {
                yield return new WaitForSeconds(1);
            }
            
            
            
            // 切换可见性
            rend.enabled = !rend.enabled;
        }
    }
}