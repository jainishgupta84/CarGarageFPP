using UnityEngine;

public class GameManager : MonoBehaviour
{
     Ray ray;
    RaycastHit hit;

    bool LeftDoorIsOpen = false;
    bool RightDoorIsOpen = false;
    bool HoodIsOpen = false;

    [SerializeField] GameObject Wheel;
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Engine;
    [SerializeField] GameObject HeadLamp;
    [SerializeField] GameObject RearLamp;




    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(1))
            {
                print(hit.collider.name);
                if (hit.collider.CompareTag("LeftDoor"))
                {
                    if (LeftDoorIsOpen)
                    {
                        hit.collider.gameObject.transform.parent.gameObject.transform.Rotate(0, -60, 0);
                        LeftDoorIsOpen = false;

                    }
                    else
                    {
                        hit.collider.gameObject.transform.parent.gameObject.transform.Rotate(0, 60, 0);
                        LeftDoorIsOpen = true;

                    }

                }
                if (hit.collider.CompareTag("RightDoor"))
                {
                    if (RightDoorIsOpen)
                    {
                        hit.collider.gameObject.transform.parent.gameObject.transform.Rotate(0, 60, 0);
                        RightDoorIsOpen = false;

                    }
                    else
                    {
                        hit.collider.gameObject.transform.parent.gameObject.transform.Rotate(0, -60, 0);
                        RightDoorIsOpen = true;

                    }
                }
                if (hit.collider.CompareTag("Hood"))
                {
                    if (HoodIsOpen)
                    {
                        hit.collider.gameObject.transform.Rotate(60, 0, 0);
                        HoodIsOpen = false;

                    }
                    else
                    {
                        hit.collider.gameObject.transform.Rotate(-60, 0, 0);
                        HoodIsOpen = true;

                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.CompareTag("Wheel"))
                {
                    Wheel.SetActive(true);
                    Door.SetActive(false);
                    Engine.SetActive(false);
                    HeadLamp.SetActive(false);
                    RearLamp.SetActive(false);
                }
                else if (hit.collider.CompareTag("Engine"))
                {
                    Engine.SetActive(true);
                    Wheel.SetActive(false);
                    Door.SetActive(false);
                    HeadLamp.SetActive(false);
                    RearLamp.SetActive(false);
                }
                else if(hit.collider.CompareTag("HeadLight"))
                {
                    HeadLamp.SetActive(true);
                    Wheel.SetActive(false);
                    Door.SetActive(false);
                    Engine.SetActive(false);
                    RearLamp.SetActive(false);
                }
                else if(hit.collider.CompareTag("TailLight"))
                {
                    RearLamp.SetActive(true);
                    Wheel.SetActive(false);
                    Door.SetActive(false);
                    Engine.SetActive(false);
                    HeadLamp.SetActive(false);
                }
                else if(hit.collider.CompareTag("LeftDoor"))
                {
                    Wheel.SetActive(false);
                    Door.SetActive(true);
                    Engine.SetActive(false);
                    HeadLamp.SetActive(false);
                    RearLamp.SetActive(false);
                }
                else if(hit.collider.CompareTag("RightDoor"))
                {
                    Door.SetActive(true);
                    Wheel.SetActive(false);
                    Engine.SetActive(false);
                    HeadLamp.SetActive(false);
                    RearLamp.SetActive(false);
                }
                else
                {
                    Wheel.SetActive(false);
                    Door.SetActive(false);
                    Engine.SetActive(false);
                    HeadLamp.SetActive(false);
                    RearLamp.SetActive(false);
                }
            }
        }
    }
}

