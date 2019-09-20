using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public static partial class ServerManager
{
    // Database reference.
    public static DatabaseReference ConnectionReference;
    
    // Database settings.
    private static readonly string DATABASE_URL = "https://testbase-a8cea.firebaseio.com/";
    internal static readonly string TABLE_NAME = "Leaders";
    
    /// <summary>
    /// Initialize database.
    /// </summary>
    public static void InitDatabase()
    {
        // Check dependencies.
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => 
        {
            // Cache Status.
            var dependencyStatus = task.Result;

            // Firebase available?
            if (dependencyStatus == DependencyStatus.Available) // Yes.
            {
                // Output successful.
                Debug.Log("Firebase available!");
                
                // Set Firebase instance.
                FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASE_URL);
                ConnectionReference = FirebaseDatabase.DefaultInstance.RootReference;
                
                // ToDo: Get the last id.
                ServerManager.GetTableValues();
            }
            else // No.
            {
                // Output error.
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}!");
                
                // Quit software, because Firebase can't be used.
                Application.Quit();
            }
        });
    }
}