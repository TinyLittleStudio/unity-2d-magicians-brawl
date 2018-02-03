using UnityEngine;
using MagiciansBrawl.MBUtils;

public class Manager : MonoBehaviour
{
    [Header("Manager Settings")]
    // Player
    public GameObject player;

    // Awake
    private void Awake()
    {
        // Search Player
        GameObject temp = GameObject.FindGameObjectWithTag(Settings.Tags.PLAYER);

        if (player == null)
        {
            if (temp != null)
            {
                player = temp;
            }
            else
            {
                Debug.LogError("No Player in Scene. Failed to Instantiate.");
            }
        }
        else
        {
            if (temp != null)
            {
                player = temp;
            }
            else
            {
                player = Instantiate(player, player.gameObject.transform.position, Quaternion.identity);
            }
        }
    }

    // Get Player Game Object
    public GameObject GetPlayer()
    {
        return player;
    }
}
