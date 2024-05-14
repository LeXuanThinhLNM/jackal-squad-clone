using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public SkeletonAnimation personCharacter;
    public GameObject vehicleCharacter;
    public GameObject vehicleCharacterParrent;
    public Button changeCharacter;
    int current = 0;
    int runSpeed = 9;
    int currentAnimation = 0;
    TypeCharacter currentCharacter= TypeCharacter.VEHICLE;
    private void Start()
    {
        currentAnimation = 0; 
        currentCharacter = TypeCharacter.VEHICLE;
        personCharacter.gameObject.SetActive(false);
        changeCharacter.onClick.AddListener(() =>
        {
            if (current == 0)
            {
                current = 1;
                currentCharacter = TypeCharacter.PERSON;
                personCharacter.gameObject.SetActive(true);
                vehicleCharacter.SetActive(false);
            }
            else
            {
                current = 0;
                currentCharacter = TypeCharacter.VEHICLE;
                personCharacter.gameObject.SetActive(false);
                vehicleCharacter.SetActive(true);
            }
        });
    }
    void Update()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        if (x != 0 || y != 0)
        {
            personCharacter.AnimationName = "Run";
            this.transform.position += Vector3.Normalize( new Vector3(x, y, 0)) * Time.deltaTime*runSpeed;
            if(currentCharacter== TypeCharacter.PERSON)
            {
                if (x > 0)
                {
                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                else if (x < 0)
                {
                    this.transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                vehicleCharacterParrent.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, Mathf.Atan2(y, x) * Mathf.Rad2Deg-90);
            }
            if(currentAnimation==0)
                vehicleCharacter.GetComponent<Animator>().SetTrigger("ToRun");
            currentAnimation = 1;
            // chuyen tu animation run sang animation idle cho vehicleCharacter

        }
        else
        {
            personCharacter.AnimationName = "Idle";
            if (currentAnimation == 1)
                vehicleCharacter.GetComponent<Animator>().SetTrigger("ToIdle");
            currentAnimation = 0;
        }
    }
    private void LateUpdate()
    {
        // cho camera theo player bang lerp
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z), Time.deltaTime * 5);
    }
}
public enum TypeCharacter
{
    PERSON,
    VEHICLE
}
