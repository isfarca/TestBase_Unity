using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance.
    public static GameManager Instance;

    /// <summary>
    /// Initialize Game manager instance.
    /// </summary>
    private void Awake()
    {
        // Have you a instance?
        if (Instance != null && Instance != this) // Yes.
        {
            // Kill the newest instance.
            Destroy(gameObject);
        } 
        else // No.
        {
            // Set instance and Call app start.
            Instance = this;
            OnAppStart();
        }
    }

    /// <summary>
    /// Load important components, by app start.
    /// </summary>
    private void OnAppStart()
    {
        ServerManager.InitDatabase();
    }

    /// <summary>
    /// Clear datas, before quite.
    /// </summary>
    private void OnApplicationQuit()
    {
    }
}