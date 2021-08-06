using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    // config params
    Defender defender;

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, transform.rotation) as Defender;
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    public void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StartDisplay>();
        int defenderCost = defender.GetStartCost();
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }
}
