using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Selector : MonoBehaviour
{
    public GameObject DemoShipsParent;
    //[HideInInspector]
    public List<Ship> SelectedShips = new List<Ship>();

    private List<Ship> demoShips = new List<Ship>();
    bool isSelecting = false;

    Vector3 startPos = Vector3.zero;
    Camera camera;
    Rect rectangle;

    // Use this for initialization
    void Start()
    {
        demoShips = DemoShipsParent.GetComponentsInChildren<Ship>().ToList();
        camera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.y < 200) return;
        if (Input.GetMouseButton(0))
        {
            if (!isSelecting)
            {
                isSelecting = true;
                startPos = Input.mousePosition;
            }

            var curMouse = Input.mousePosition;
            rectangle = new Rect(
                Mathf.Min(curMouse.x, startPos.x),
                Mathf.Min(curMouse.y, startPos.y),
                Mathf.Abs(curMouse.x - startPos.x),
                Mathf.Abs(curMouse.y - startPos.y)
                );
            
            SelectedShips.Clear();
            foreach (var ship in demoShips)
            {
                var shipOnScreenPoint = camera.WorldToScreenPoint(ship.transform.position);
                if (rectangle.Contains(shipOnScreenPoint)) SelectedShips.Add(ship);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isSelecting)
            {
                isSelecting = false;
            }
        }
    }

    private void OnGUI()
    {
        if (isSelecting)
        {
            var guiRect = rectangle;
            guiRect.y = Screen.height - guiRect.y;
            guiRect.height = - guiRect.height;
            GUI.Box(guiRect, "");
        }
    }
}
