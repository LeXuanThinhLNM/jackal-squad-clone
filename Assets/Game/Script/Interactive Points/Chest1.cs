using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest1 : MonoBehaviour
{
    [SerializeField] private GameObject animExplosion;
    private void OnEnable()
    {
        Destroy(gameObject, 7.5f/12f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            animExplosion.SetActive(true);
        }
    }
}
