using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsList : MonoBehaviour
{
    public Selector selector;
    public Transform contentPanel;
    public ShipOverlay ShipOverlayPrefab;
    public float overlayWidth = 200f;

    protected List<ShipOverlay> shipOverlays = new List<ShipOverlay>();

    RectTransform _contentRect;

    // Use this for initialization
    void Start()
    {
        _contentRect = contentPanel.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //If selected ships more than overlays
        if (selector.SelectedShips.Count != shipOverlays.Count)
        {
            ModifyOverlayCount();
            RearrangeUI();
        }

        //
        var min = Mathf.Min(shipOverlays.Count, selector.SelectedShips.Count);
        for (int i = 0; i < min; i++)
        {
            shipOverlays[i].SetShip(selector.SelectedShips[i]);
        }
    }

    void RearrangeUI()
    {
        for (int i = 0; i < shipOverlays.Count; i++)
        {
            shipOverlays[i].selfTransform.anchoredPosition = new Vector2(i * overlayWidth, 0);
        }
        _contentRect.sizeDelta = new Vector2(shipOverlays.Count * overlayWidth, _contentRect.sizeDelta.y);
    }

    void ModifyOverlayCount()
    {
        if (selector.SelectedShips.Count > shipOverlays.Count)
        {
            for (int i = 0; i < selector.SelectedShips.Count - shipOverlays.Count; i++)
            {
                var overlay = GameObject.Instantiate(ShipOverlayPrefab.gameObject, contentPanel);
                shipOverlays.Add(overlay.GetComponent<ShipOverlay>());
            }
        }
        else
        {
            for (int i = selector.SelectedShips.Count; i < shipOverlays.Count; i++)
            {
                Destroy(shipOverlays[selector.SelectedShips.Count].gameObject);
                shipOverlays.RemoveAt(selector.SelectedShips.Count);
            }
        }
    }
}
