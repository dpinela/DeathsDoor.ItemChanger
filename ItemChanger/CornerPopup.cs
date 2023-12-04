using System;
using UE = UnityEngine;

namespace DeathsDoor.ItemChanger;

public class CornerPopup
{
    private static CornerPopup? Instance;

    public static void Show(string msg)
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
        Instance.ShowMessage(msg);
    }

    private UE.GameObject go;
    private UICount counter;

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
        counter.enabled = true;
        var cs = origCounter.gameObject.transform.parent.gameObject;
        var rt = cs.GetComponent<UE.RectTransform>();
        rt.SetSizeWithCurrentAnchors(UE.RectTransform.Axis.Horizontal, 800f);
        go.SetActive(true);
        // cs also has an Image component, probably the sprite (which we will want
        // to change at some point)
    }

    private const float DisplayTime = 3f;
    private const float Xpos = -250f;

    internal void ShowMessage(string s)
    {
        counter.counter.text = s;
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