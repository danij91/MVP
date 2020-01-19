using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour {
    private Color DISABLED_COLOR = new Color(0.5f, 0.5f, 0.5f);
    private Color ENABLED_COLOR = new Color(0f, 0f, 0f);

    [SerializeField]
    private Text _Text_menuItem;

    public void SetEnabled(bool enabled) {
        if (enabled) {
            _Text_menuItem.color = ENABLED_COLOR;
        } else {
            _Text_menuItem.color = DISABLED_COLOR;
        }
    }
}
