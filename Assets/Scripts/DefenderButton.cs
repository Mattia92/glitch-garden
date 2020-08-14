using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour {

    [SerializeField] Defender defender;

    private void Start() {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost() {
        Text costText = GetComponentInChildren<Text>();
        if (costText) {
            costText.text = defender.StarCost.ToString();
        } else {
            Debug.LogError(name + "has no cost text");
        }
    }

    private void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(50, 50, 50, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().Defender = defender;
    }
}
