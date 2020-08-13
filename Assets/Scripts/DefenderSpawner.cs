using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Defender Defender { get; set; }

    private void OnMouseDown() {
        AttemptToPlaceDefender(GetSquareClicked());
    }

    private void AttemptToPlaceDefender(Vector2 gridPos) {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = Defender.StarCost;
        if (starDisplay.HaveEnoughStars(defenderCost)) {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos) {
        Defender newDefender = Instantiate(Defender, roundedPos, Quaternion.identity) as Defender;
    }
}
