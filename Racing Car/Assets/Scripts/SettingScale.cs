using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingScale
{
    private static int height = Screen.height;
    private static int width = Screen.width;
    public static Vector3 setLocalScale(float scaleWeWantX, float scaleWeWantY)
    {
        return new Vector3((float)(1.67f * width / height)*scaleWeWantX, (float)(1.67f * width / height) * scaleWeWantY, (float)(1.67f * width / height) * 1f);
    }
    public static float setLocalDistance(float scaleWeWant)
    {
        return (float)(1.67f * width / height) * scaleWeWant;
    }
}
