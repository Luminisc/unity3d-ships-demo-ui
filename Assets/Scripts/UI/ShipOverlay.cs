using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipOverlay : MonoBehaviour
{
    private Ship _ship;

    public Image Icon;
    public RectTransform HPBar;
    public RectTransform ShieldBar;
    public RectTransform EnergyBar;
    public GameObject MarginPanel;

    public RectTransform selfTransform
    {
        get
        {
            if (_selfTransform != null)
                return _selfTransform;
            _selfTransform = GetComponent<RectTransform>();
            return _selfTransform;
        }
        protected set { _selfTransform = value; }
    }


    protected RectTransform _selfTransform;

    // Use this for initialization
    void Start()
    {
        SetShip(_ship);
    }

    void Awake()
    {
        SetShip(_ship);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void SetShip(Ship ship)
    {
        _ship = ship;
        MarginPanel.SetActive(ship != null);
        UpdateUI();
        UpdateIcon();
    }

    void UpdateUI()
    {
        if (_ship == null) return;
        HPBar.anchorMax = new Vector2(_ship.stats.CurHP / _ship.stats.MaxHP, 0);
        ShieldBar.anchorMax = new Vector2(_ship.stats.CurShield / _ship.stats.MaxShield, 0);
        EnergyBar.anchorMax = new Vector2(_ship.stats.CurEnergy / _ship.stats.MaxEnergy, 1);
    }

    void UpdateIcon()
    {
        if (_ship == null) return;
        Icon.sprite = _ship.icon;
    }
}
