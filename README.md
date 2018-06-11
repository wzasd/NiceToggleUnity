# NiceToggleUnity
 Perfect Toggle effect
##目标
本文将从 0 教你如何打造一个 Unity 的组件，来创建属于你的 UGUI~
效果图在这里：
![TogglePrefer.gif](https://upload-images.jianshu.io/upload_images/4034766-45b8d4234e098852.gif?imageMogr2/auto-orient/strip)
##动起来
如果是你想要的效果，那么跟我一起动起来，如果不是请点击右上角~
本文的项目已上传 github 可以直接使用 Unity 打开使用，不想看教程，代码一样说明一切。
如要代码请点击[这里](https://github.com/wzasd/NiceToggleUnity)。
### 创建 Canvas
所有的 UI 空间都需要在 Canvas 下进行布局，当然这是废话。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-e370f5461917a113.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
所有的 UI 都会出现在摄像机面前了。
### 创建一个 Panel
对这里创建一个 Panel，来放下我们所有的组件，毕竟要手写一个 Toggle。这里起名叫做 NiceToggle。
大小设置为 200*70 。按照你的需求来。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-efd9d94046c099ce.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
现在我们的组件是这样的结构。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-35a9e2faaeac1893.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
这是最基础的东西，下面就来加快速度了。
### 创建属于你的背景、滑块、ON文字、OFF 文字、需要相应的 Button
我们这里使用 Button 来响应用户的点击，当然你也可以用别的相应点击效果。
*  背景是 Image 组件，起名为 ToggleBg。
*  滑块是 Image 组件，起名为 Handle。
*  ON 是 Text 组件，起名 ON。
*  OFF 是 Text 组件，起名 OFF。
*  Button 是 Button 组件，起名  ToggleButton。

我们现在 Screen 是现在这样。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-a49f871ba0c4d69b.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

要把所有的组件组合起来，所以需要一些资源文件，在项目中你都可以得到这些资源文件，首先是背景，我这里叫 Toggle_bg，大概是这个样子。
![Toggle_bg](https://upload-images.jianshu.io/upload_images/4034766-2ed9e282e54f019b.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
其次是我的滑块背景，起名 Handle，大概是这个样子。
![Handle](https://upload-images.jianshu.io/upload_images/4034766-b40340394a62930f.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
放进 Unity 项目的时候要做这样的处理，这样做 Slice 的属性设置的时候，就不会不会出现圆角的拉伸情况，新技能赶紧 Get。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-8376f30fca688beb.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
将我们的格式编程 Sprite，选择 Sprite Editor。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-994681f8435af3e9.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
这样处理以后，无论你怎么拉伸就只会拉伸绿色框框内部的部分。
当然 Toggle_bg做相同处理，我把参数放在下面。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-14c0ae24c9c0308e.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
两个其实很像~~。
### 制作我们的 Toggle
ToggleBg 参数如下图：
![image.png](https://upload-images.jianshu.io/upload_images/4034766-58e45bfbd6274f6e.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
Handle 参数如下图：
![image.png](https://upload-images.jianshu.io/upload_images/4034766-73b49c52de9bdf60.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
ON 参数如下图：
![image.png](https://upload-images.jianshu.io/upload_images/4034766-b92b63373405bb6c.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
OFF 参数如下图：
![image.png](https://upload-images.jianshu.io/upload_images/4034766-afcd080e18755e5a.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
**注意：**ON 与 OFF 需要添加 Canvas Group，如果你想让我们 Toggle 更 Nice 的话。（调整透明度）
Button 参数如下图：
![image.png](https://upload-images.jianshu.io/upload_images/4034766-c2520a7bdef9d984.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
OnClick 的函数等下说，如果你上面的步骤做好之后，你会得到一个这个。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-637d9ac105f5511b.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
是不是很棒呢？那我们赶紧让他动起来。
### 编写 ToggleController 脚本
给 NiceToggle 添加脚本，取名 ToggleController。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-7bf874652b2d7fa7.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
编写如下代码：
``` c#
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

```
请在 `DoYourStaff()` 中填写你的业务逻辑，这里使用的 DOTween 的数值线性变化，DOTween 的[文档](http://dotween.demigiant.com/) 下一篇文章会单独介绍这个的使用。再把所有的控件挂在到 Controller 上就可以达到文章开头的效果啦，试一下吧。
![image.png](https://upload-images.jianshu.io/upload_images/4034766-a1fe331080cd3bcb.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
