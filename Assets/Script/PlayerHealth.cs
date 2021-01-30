using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHeal = 20;
    public Text lifeText;

    void Update() {
        lifeText.text = maxHeal.ToString() + "x";
    }

    public bool IsAlive() {
        return currentHeal > 0;
    }

    int currentHeal;

    public void AddLife()
    {
        currentHeal = Mathf.Clamp(currentHeal + 1, 0, maxHeal);
    }

    public void RemoveLife()
    {
        currentHeal = Mathf.Clamp(currentHeal - 1, 0, maxHeal);
        if (currentHeal <= 0) {
            Debug.Log("DEAD"); //TODO DEAD
        }
    }

    public void Die()
    {
        while(currentHeal > 0) RemoveLife();
    }

    public void Heal()
    {
        currentHeal = maxHeal;
    }
}