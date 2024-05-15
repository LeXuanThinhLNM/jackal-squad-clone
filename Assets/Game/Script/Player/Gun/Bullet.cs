using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.Translate(Vector2.up * Time.deltaTime * 20);
    }
}
