using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    void OnEndAnim()
    {
        this.gameObject.SetActive(false);
    }
}
