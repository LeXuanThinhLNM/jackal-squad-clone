using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.Translate(Vector2.up * Time.deltaTime * 35);
        Destroy(this.gameObject, 0.85f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("InteractiveObjects"))
        {
            Debug.Log("enter bullet");
            Destroy(this.gameObject,0.01f);
        }
    }
}
