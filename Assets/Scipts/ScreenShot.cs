using System;
using Steamworks;
using UnityEngine;

public static class ScreenShot
{
    public static void Take()
    {
        var path = string.Format("{0}/ScreenShots/{1: yy-mm-dd hh-mm}.png", Application.dataPath, DateTime.Now);
        Application.CaptureScreenshot(path);
    }
}