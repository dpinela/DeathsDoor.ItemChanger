using System;
using UE = UnityEngine;

namespace DDoorItemChanger;

public class CornerPopup
{
    private static CornerPopup? Instance;

    public static void Show(string msg)
    {
        if (Instance == null)
        {
            Instance = new();
        }
        Instance.ShowMessage(msg);
    }

    private UE.GameObject go;
    private UICount counter;

    internal CornerPopup()
    {
        var origCounter = FindSoulsCounter();
        go = UE.Object.Instantiate(origCounter.gameObject, origCounter.gameObject.transform);
        UE.Object.DontDestroyOnLoad(go);
        go.SetActive(true);
        counter = go.GetComponent<UICount>();
        counter.notGlobal = true;
        counter.maxOffsetX = Xpos;
        counter.count = 0;
        counter.realCount = 0;
        counter.showTimer = 0;
        counter.name = "IC-CornerPopup";
        counter.enabled = true;
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
            if (c.name == "SOULS")
            {
                return c;
            }
        }
        throw new InvalidOperationException("souls counter not found");
    }
}