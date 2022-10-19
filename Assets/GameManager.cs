using UnityEngine;

public class GameManager : MonoBehaviour
{
     Ray ray;
    RaycastHit hit;

    bool LeftDoorIsOpen = false;
    bool RightDoorIsOpen = false;
    bool HoodIsOpen = false;

    private const float offset = 0.001f;
    /// <summary>
    /// Draws a line in screen space between the 
    /// <paramref name="startPixelPos"/> and the 
    /// <paramref name="endPixelPos"/>. 
    /// </summary>
    public static void DrawLine(
      Canvas canvas,
      Camera camera,
      Vector3 startPixelPos,
      Vector3 endPixelPos)
    {
        if (camera == null || canvas == null)
            return;
        Vector3 startWorld = PixelToCameraClipPlane(
          camera,
          canvas,
          startPixelPos);
        Vector3 endWorld = PixelToCameraClipPlane(
          camera,
          canvas,
          endPixelPos);
        Gizmos.DrawLine(startWorld, endWorld);
    }
    /// <summary>
    /// Converts the <paramref name="screenPos"/> to world space 
    /// near the <paramref name="camera"/> near clip plane. The 
    /// z component of the <paramref name="screenPos"/> 
    /// will be overriden.
    /// </summary>
    private static Vector3 PixelToCameraClipPlane(
      Camera camera,
      Canvas canvas,
      Vector3 screenPos)
    {
        // The canvas scale factor affects the
        // screen position of all UI elements.
        screenPos *= canvas.scaleFactor;
        // The z-position defines the distance to the camera
        // when using Camera.ScreenToWorldPoint.
        screenPos.z = camera.nearClipPlane + offset;
        return camera.ScreenToWorldPoint(screenPos);
    }


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
        }
    }
}

