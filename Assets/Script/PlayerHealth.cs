using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHeal = 20;
    public Text lifeText;
    private int currentHeal;

    void Update() {
        lifeText.text = currentHeal.ToString() + "x";
    }

    void Start() {
        currentHeal = maxHeal;
    }

    public bool IsAlive() {
        return currentHeal > 0;
    }

    public int getHeal() {
        return currentHeal;
    }

    public void AddLife()
    {
        currentHeal = Mathf.Clamp(currentHeal + 1, 0, maxHeal);
    }

    public void RemoveLife()
    {
        currentHeal = Mathf.Clamp(currentHeal - 1, 0, maxHeal);
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