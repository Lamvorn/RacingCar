using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Transform box;

    private void OnEnable()
    {
        box.localPosition = new Vector2 (0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void exitGameOver()
    {
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
    }
}
