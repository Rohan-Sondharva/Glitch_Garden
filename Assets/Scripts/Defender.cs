using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int startCost = 100;

    public void AddStars(int amount)
    {
        FindObjectOfType<StartDisplay>().AddStars(amount);
    }

    public int GetStartCost()
    {
        return startCost;
    }
}
