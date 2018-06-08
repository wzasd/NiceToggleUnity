using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public bool isOn;
    public bool isEnable = true;

    public Color onColorBg;
    public Color offColorBg;
    public Color NoEnableBg;

    public Image toggleBgImage;
    public RectTransform toggle;

    public GameObject handle;
    private RectTransform handleTransform;


    public Button SwitchButton;

    private float handleSize;
    private float onPosX;
    private float offPosX;

    public float handleOffset;

    public GameObject onIcon;
    public GameObject offIcon;


    public float speed;
    static float t = 0.0f;

    private bool switching = false;


    void Awake()
    {
        handleTransform = handle.GetComponent<RectTransform>();
        RectTransform handleRect = handle.GetComponent<RectTransform>();
        handleSize = handleRect.sizeDelta.x;
        float toggleSizeX = toggle.sizeDelta.x;
        onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
        offPosX = onPosX * -1;
    }

    void Start()
    {
        if (isOn)
        {
            toggleBgImage.color = onColorBg;
            handleTransform.localPosition = new Vector3(onPosX, 0f, 0f);
            onIcon.gameObject.SetActive(true);
            offIcon.gameObject.SetActive(false);
            DOTweenTransparency(onIcon, 0f, 1f);
            DOTweenTransparency(offIcon, 1f, 0f);
        }
        else
        {
            toggleBgImage.color = offColorBg;
            handleTransform.localPosition = new Vector3(offPosX, 0f, 0f);
            onIcon.gameObject.SetActive(false);
            offIcon.gameObject.SetActive(true);
            DOTweenTransparency(onIcon, 1f, 0f);
            DOTweenTransparency(offIcon, 0f, 1f);
        }
    }

    void Update()
    {
        if (isEnable)
        {
            if (switching)
            {
                Toggle(isOn);
            }
        }
        else
        {
            toggleBgImage.color = NoEnableBg;
            onIcon.gameObject.SetActive(false);
            offIcon.gameObject.SetActive(true);
        }
    }

    public void DoYourStaff()
    {
        Debug.Log(isOn);
    }

    public void Switching()
    {
        if (isEnable)
        {
            switching = true;
        }
    }

    public void Toggle(bool toggleStatus)
    {
        if ((offIcon != null) && ((onIcon != null) && (!onIcon.active || !offIcon.active)))
        {
            onIcon.SetActive(true);
            offIcon.SetActive(true);
        }

        if (toggleStatus)
        {
            StopDOTweenSwitching();
            DOTweenSmoothColor(offColorBg);
            DOTweenTransparency(onIcon, 1f, 0f);
            DOTweenTransparency(offIcon, 0f, 1f);
            DOTweenSmoothMove(onPosX, offPosX);
        }
        else
        {
            StopDOTweenSwitching();
            DOTweenSmoothColor(onColorBg);
            DOTweenTransparency(onIcon, 0f, 1f);
            DOTweenTransparency(offIcon, 1f, 0f);
            DOTweenSmoothMove(offPosX, onPosX);
        }
    }

    void DOTweenSmoothMove(float startPosX, float endPosX)
    {
        DOTween.To(
            () => handleTransform.localPosition,
            x => handleTransform.localPosition = x,
            new Vector3((endPosX - startPosX) / 2, 0f, 0f),
            0.4f
        ).SetEase(Ease.OutQuad);
    }

    void DOTweenSmoothColor(Color endCol)
    {
        DOTween.To(
            () => toggleBgImage.color,
            x => toggleBgImage.color = x,
            endCol,
            0.4f
        ).SetEase(Ease.OutQuad);
    }

    void DOTweenTransparency(GameObject alphaObj, float startAlpha, float endAlpha)
    {
        CanvasGroup alphaVal;
        alphaVal = alphaObj.gameObject.GetComponent<CanvasGroup>();
        DOTween.To(() => alphaVal.alpha, x => alphaVal.alpha = x, endAlpha, 0.4f);
    }

    void StopDOTweenSwitching()
    {
        switching = false;
        switch (isOn)
        {
            case true:
                isOn = false;
                DoYourStaff();
                break;

            case false:
                isOn = true;
                DoYourStaff();
                break;
        }
    }

}
