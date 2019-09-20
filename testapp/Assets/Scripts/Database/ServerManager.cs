using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public static partial class ServerManager
{
    // Database reference.
    public static DatabaseReference ConnectionReference;
    
    // Database settings.
    public static readonly string DATABASE_URL = "https://testbase-a8cea.firebaseio.com/";
    
    /// <summary>
    /// Initialize database.
    /// </summary>
    public static void InitDatabase()
    {
        // Check dependencies.
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => 
        {
            // Cache Status.
            var dependencyStatus = task.Result;

            // Firebase available?
            if (dependencyStatus == Firebase.DependencyStatus.Available) // Yes.
            {
                // Output successful.
                Debug.Log("Firebase available!");
                
                // Set Firebase instance.
                FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASE_URL);
                ConnectionReference = FirebaseDatabase.DefaultInstance.RootReference;
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