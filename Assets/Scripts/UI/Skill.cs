using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public float pressScale = 0.5F;
    public float duration = 1F;
    private bool isAnim = false;

    public Image UIobj;
    public float countTime = 5.0f;
    [SerializeField, ReadOnly] float remainTime = 0;
    public Text time;

    // Start is called before the first frame update
    void Start()
    {
        time.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIobj.fillAmount != 0)
        {
            UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
            remainTime -= Time.deltaTime;
            time.text = ((int)remainTime).ToString();
        }
        if (remainTime < 0)
        {
            remainTime = 0;
            time.text = "0";
            time.enabled = false;
        }
    }

    public async void PressKeyBoard()
    {
        UIobj.fillAmount = 1.0f;
        remainTime = countTime;
        time.enabled = true;

        if (isAnim)
        {
            return;
        }
        isAnim = true;
        Debug.Log("PressKeyBoard");
        transform.DOScale(new Vector3(1 - pressScale, 1 - pressScale, 1 - pressScale), duration);
        await Task.Delay((int)(duration * 1000));
        transform.DOScale(new Vector3(1, 1, 1), duration);
        await Task.Delay((int)(duration * 1000));
        isAnim = false;
    }
}
