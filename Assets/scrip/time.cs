using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class time : MonoBehaviour
{
    public static int allTime = 60;
    public Text times;
    public Text over;

    private bool isVisible = true;
    public GameObject huaban;
    public GameObject sakura;
    public GameObject man;
    public GameObject jiantou;
    public GameObject sun;

    private PostProcessVolume postProcessVolume;
    private ChromaticAberration chromaticAberration;
    private Coroutine timerCoroutine;
    private Coroutine overCoroutine; // 新增：用于管理 "Over" 消失的协程

    Vector3 hua=new Vector3(0,0.2f,0.5f);

    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
    }

    private void OnEnable()
    {
        if (timerCoroutine == null)
        {
            timerCoroutine = StartCoroutine(StartTimer());
        }
    }

    private void OnDisable()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        // 停止 "Over" 消失的协程
        if (overCoroutine != null)
        {
            StopCoroutine(overCoroutine);
            overCoroutine = null;
        }
    }

    private IEnumerator StartTimer()
    {
        int timer = 0;
        
        while (timer < allTime)
        {
            int sj = allTime - timer;
            int s = sj % 60;
            int m = sj / 60;
            
            times.text = string.Format("{0:D2}:{1:D2}", m, s);
            timer++;
            
            yield return new WaitForSeconds(1f);
        }
        GameObject sakuraTree=Instantiate(sakura, new Vector3(man.transform.position.x-2.19f,3.6f,man.transform.position.z+12f), Quaternion.identity);

        

            // 更新对象的可见性
        Instantiate(huaban,man.transform.position+hua,Quaternion.identity);
        huaban.transform.SetParent(man.transform);

        over.text = "Over!";
        times.text = "00:00";
        Destroy(jiantou);
        Destroy(sun);

        // 启动 "Over" 消失的协程
        overCoroutine = StartCoroutine(HideOverAfterDelay(8f));

        if (chromaticAberration != null)
        {
            chromaticAberration.enabled.value = !chromaticAberration.enabled.value;
        }
    }

    private IEnumerator HideOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 隐藏 "Over" 文本
        over.text = "";
        chromaticAberration = null;
    }
}
