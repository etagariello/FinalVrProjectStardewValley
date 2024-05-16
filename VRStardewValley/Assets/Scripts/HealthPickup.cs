using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public TextMeshProUGUI PlayerHealthText;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Bandage")
        {
            other.transform.gameObject.SetActive(false);

            string[] splitHealthText = PlayerHealthText.text.Split();
            int PlayerHealth = int.Parse(splitHealthText[1]);

            if (PlayerHealth < 100)
            {
                PlayerHealth = PlayerHealth + 25;

                if (PlayerHealth > 100)
                {
                    PlayerHealth = 100;
                }

                PlayerHealthText.text = "Health: " + PlayerHealth;
            }
        }
    }
}
