using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public SkeletonAnimation skeletonAnimation;
    int current = 0;
    int runSpeed = 7;
    void Update()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        if (x != 0 || y != 0)
        {
            skeletonAnimation.AnimationName = "Run";
            this.transform.position += Vector3.Normalize( new Vector3(x, y, 0)) * Time.deltaTime*runSpeed;
            if (x > 0)
            {
                this.transform.localScale = new Vector3(4, 4, 1);
            }
            else if (x < 0)
            {
                this.transform.localScale = new Vector3(-4, 4, 1);
            }
        }
        else
        {
            skeletonAnimation.AnimationName = "Idle";
        }
    }
}
