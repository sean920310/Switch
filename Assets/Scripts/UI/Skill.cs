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
    private bool isSkillUsing = false;


    public GameObject skillMask;
    public Image UIobj;
    public Image UsingObj;
    public float cdTime = 5.0f;
    public float usingTime = 5.0f;
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
        if (UsingObj.fillAmount != 0)
        {
            skillMask.SetActive(true);
            UsingObj.fillAmount -= 1.0f / usingTime * Time.deltaTime;
            remainTime -= Time.deltaTime;
        }

        if (UIobj.fillAmount != 0)
        {
            skillMask.SetActive(true);
            UIobj.fillAmount -= 1.0f / cdTime * Time.deltaTime;
            remainTime -= Time.deltaTime;
            if (remainTime >= 1)
            {
                time.text = ((int)remainTime).ToString();
            }
            else
            {
                time.text = remainTime.ToString("0.00");
            }
        }
        if (remainTime < 0)
        {
            if (isSkillUsing)
            {
                UIobj.fillAmount = 1.0f;
                time.enabled = false;
                remainTime = usingTime;
                time.enabled = true;
                isSkillUsing = false;
            }
            else
            {
                remainTime = 0;
                time.text = "";
                time.enabled = false;
                isSkillUsing = false;
                skillMask.SetActive(false);
            }
        }
    }

    public bool IsUsingSkillState()
    {
        return isAnim || isSkillUsing;
    }

    public async void PressKeyBoard()
    {
        if (IsUsingSkillState())
        {
            return;
        }
        isAnim = true;
        isSkillUsing = true;
        UsingObj.fillAmount = 1.0f;
        remainTime = usingTime;
        time.text = "";
        time.enabled = true;
        Debug.Log("PressKeyBoard");
        transform.DOScale(new Vector3(1 - pressScale, 1 - pressScale, 1 - pressScale), duration);
        await Task.Delay((int)(duration * 1000));
        transform.DOScale(new Vector3(1, 1, 1), duration);
        await Task.Delay((int)(duration * 1000));
        isAnim = false;
    }
}
