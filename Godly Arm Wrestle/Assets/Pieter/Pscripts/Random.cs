using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomButtonTeleport : MonoBehaviour
{
    public float teleportRadius = 200f;
    public float teleportDelay = 1f; // Delay in seconds before auto teleport
    public GameObject panel;

    private Button teleportButton;
 

    void Start()
    {
        // Find the button component in the hierarchy
        teleportButton = GetComponentInChildren<Button>();

        // Add a listener to the button's onClick event
        teleportButton.onClick.AddListener(OnTeleportButtonClick);



        // Start the coroutine for auto teleport
        StartCoroutine(AutoTeleport());
    }

    void OnTeleportButtonClick()
    {
        TeleportButton();
        
    }

    void TeleportButton()
    {
        if (!panel.activeSelf)
        {
            // Calculate a random position within the teleport radius
            Vector3 randomPosition = GetRandomPosition();

            // Teleport the button to the random position
            RectTransform buttonRectTransform = teleportButton.GetComponent<RectTransform>();
            buttonRectTransform.anchoredPosition = randomPosition;
        }
    }

    

    Vector3 GetRandomPosition()
    {
        // Calculate a random position within the teleport radius
        float randomX = Random.Range(-teleportRadius, teleportRadius);
        float randomY = Random.Range(-teleportRadius, teleportRadius);
        Vector3 randomOffset = new Vector3(randomX, randomY, 0f);

        return randomOffset;
    }

    IEnumerator AutoTeleport()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportDelay);

            // Teleport the button automatically
            TeleportButton();
        }
    }
}
