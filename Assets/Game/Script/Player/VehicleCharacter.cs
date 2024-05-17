using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class VehicleCharacter : MonoBehaviour
{
    public Joystick joystick;
    public GameObject vehicleCharacterAnim;
    public GameObject wheelPrintTrailUnit;
    public Transform wheelPrint1;
    public Transform wheelPrint2;
    public Button changeCharacter;
    int runSpeed = 20;
    int  timePrintWheelTrail = 2;
    int timePrintWheelTrailTemp = 0;
    int currentAnimation = 0;
    public Collider2D attachArea;
    public List<GameObject> attachObject;
    public Gun gun;
    private void Start()
    {
        gun.VehicleCharacter = this;
    }
    private void FixedUpdate()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        if (x != 0 || y != 0)
        {
            //personCharacter.AnimationName = "Run";
            this.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(y, x) * Mathf.Rad2Deg - 90);
            this.GetComponent<Rigidbody2D>().MovePosition(this.transform.position + Vector3.Normalize(new Vector3(x, y, 0)) * runSpeed * Time.deltaTime);

            if (currentAnimation == 0)
            {
                vehicleCharacterAnim.GetComponent<Animator>().SetTrigger("ToRun");
                currentAnimation = 1;
            }
                
            WheelPrint();
        }
        else
        {
            timePrintWheelTrailTemp = 0;
            if (currentAnimation == 1)
            {
                vehicleCharacterAnim.GetComponent<Animator>().SetTrigger("ToIdle");
                currentAnimation = 0;
            }
        }
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z), Time.deltaTime * 5);
    }

    public (bool, Transform) CheckAttack()
    {
        if(attachObject.Count>0)
        {
            GameObject nearestObject = attachObject[0];
            float minDistance = Vector3.Distance(nearestObject.transform.position, this.transform.position);
            for (int i = 0; i < attachObject.Count; i++)
            {
                float distance = Vector3.Distance(attachObject[i].transform.position, this.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestObject = attachObject[i];
                }
            }

            return (true, nearestObject.transform);
        }
        else
        {
            return (false, null);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("InteractiveObjects"))
        {
            attachObject.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("InteractiveObjects"))
        {
            attachObject.Remove(collision.gameObject);
        }
    }
    private void WheelPrint()
    {

        timePrintWheelTrailTemp += 1;
        if (timePrintWheelTrailTemp>= timePrintWheelTrail)
        {
            GameObject wheelPrintTrailClone1= Instantiate(wheelPrintTrailUnit, wheelPrint1.position, wheelPrint1.rotation);
            GameObject wheelPrintTrailClone2 = Instantiate(wheelPrintTrailUnit, wheelPrint2.position, wheelPrint2.rotation);
            timePrintWheelTrailTemp = 0;
            Destroy(wheelPrintTrailClone1, 0.7f);
            Destroy(wheelPrintTrailClone2, 0.7f);
        }
    }
}
