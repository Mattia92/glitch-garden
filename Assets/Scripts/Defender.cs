using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    [SerializeField] int starCost = 100;

    public int StarCost { get => starCost; }

    public void AddStars(int amount) {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }
}
