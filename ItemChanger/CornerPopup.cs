using System;
using UE = UnityEngine;
using UI = UnityEngine.UI;

namespace DDoor.ItemChanger;

public class CornerPopup
{
    private static CornerPopup? Instance;

    public static void Show(UE.Sprite icon, string msg)
    {
        if (Instance == null)
        {
            Instance = new();
        }
        if (Instance.counter.moveable == null)
        {
            if (Instance.go == null)
            {
                ItemChangerPlugin.LogInfo("CornerPopup go dead");
            }
            else
            {
                UE.Object.Destroy(Instance.go);
            }
            Instance = new();
        }
        Instance.ShowMessage(icon, msg);
    }

    public static void Show(Item x)
    {
        Show(ItemIcons.Get(x.Icon), x.DisplayName);
    }

    private UE.GameObject go;
    private UICount counter;
    private UI.Image image;

    internal CornerPopup()
    {
        var origCounter = FindSoulsCounter();
        go = UE.Object.Instantiate(origCounter.gameObject, origCounter.gameObject.transform.parent);
        counter = go.GetComponent<UICount>();
        counter.notGlobal = false;
        counter.maxOffsetX = Xpos;
        counter.count = 0;
        counter.realCount = 0;
        counter.showTimer = 0;
        counter.name = "IC-CornerPopup";
        counter.id = "IC-CornerPopup";
        counter.counter.fontSize = 24;
        counter.enabled = true;
        var cs = origCounter.gameObject.transform.parent.gameObject;
        var rt = cs.GetComponent<UE.RectTransform>();
        rt.SetSizeWithCurrentAnchors(UE.RectTransform.Axis.Horizontal, 800f);
        go.SetActive(true);
        image = go.GetComponentInChildren<UI.Image>();
        // Remove the little "x" (which in the original UI item, is meant
        // to precede a number).
        foreach (var txt in go.GetComponentsInChildren<TMPro.TextMeshProUGUI>())
        {
            if (txt.name == "x")
            {
                UE.Object.Destroy(txt);
                break;
            }
        }
    }

    private const float DisplayTime = 3f;
    private const float Xpos = -250f;

    internal void ShowMessage(UE.Sprite icon, string s)
    {
        counter.counter.text = s;
        counter.addText.text = "";
        image.sprite = icon;
        if (counter.IsShowing())
        {
            counter.ResetShowTimer(DisplayTime);
        }
        else
        {
            counter.xOffset = Xpos;
            counter.offScreenPos.x = Xpos;
            counter.moveable.localPosition = counter.offScreenPos;
            counter.showTimer = DisplayTime;
        }
    }

    private static UICount FindSoulsCounter()
    {
        foreach (var c in UICount.countList)
        {
            if (c == null)
            {
                ItemChangerPlugin.LogInfo("null counter in UICount.countList");
                continue;
            }
            if (c.name == "SOULS")
            {
                return c;
            }
        }
        throw new InvalidOperationException("souls counter not found");
    }
}