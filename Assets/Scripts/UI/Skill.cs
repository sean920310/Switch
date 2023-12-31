using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public float pressScale = 0.25f;
    public float duration = 0.2f;
    private bool isAnim = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public async void PressKeyBoard()
    {
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
