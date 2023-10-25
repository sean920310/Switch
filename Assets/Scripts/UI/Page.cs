using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public GameObject view = null;
    public GameObject mask = null;
    public float _openDuration = 1F;
    public float _closeDuration = 1F;
    public bool IsOn { get { return _isOn; } }
    private bool _isOn = false;
    private bool _isOpening = false;
    private bool _isCloseing = false;

    public async void Open()
    {
        if (_isOpening)
        {
            return;
        }
        _isOn = true;
        view.SetActive(true);
        mask.SetActive(true);
        _isOpening = true;
        await playOpen();
        _isOpening = false;
    }

    public async void Close()
    {
        if (_isCloseing)
        {
            return;
        }
        _isCloseing = true;
        await playClose();
        _isCloseing = false;
        view.SetActive(false);
        if (mask)
        {
            mask.SetActive(false);
        }
        _isOn = false;
    }

    public async Task playOpen()
    {
        view.transform.localScale = new Vector3(0, 0, 0);
        view.transform.DOBlendableScaleBy(new Vector3(1, 1, 1), _openDuration);
        if (mask)
        {
            mask.GetComponent<CanvasGroup>().DOFade(1, _openDuration);
        }
        await Task.Delay((int)(_openDuration * 1000));
    }

    public async Task playClose()
    {
        view.transform.DOBlendableScaleBy(new Vector3(-1, -1, -1), _closeDuration);
        if (mask)
        {
            mask.GetComponent<CanvasGroup>().DOFade(0, _closeDuration);
        }
        await Task.Delay((int)(_openDuration * 1000));
    }
}
