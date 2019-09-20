using UnityEngine;

public static partial class ServerManager
{
    /// <summary>
    /// 
    /// </summary>
    public static void GetTableValues()
    {
        // Current username output.
        ConnectionReference.GetValueAsync().ContinueWith(task => 
        {
            // Task completed?
            if (task.IsFaulted) // Yes with error.
            {
                // Output error.
                Debug.Log("Get value task error!");
            }
            else if (task.IsCompleted) // Yes successfully.
            {
                // It's not working correctly.
                var snapshot = task.Result;
                int i = 0;
                foreach (var children in snapshot.Children)
                {
                    Debug.Log(children.Child(i.ToString()).Child(LeadersAttributeName.EMAIL).Value);
                    Debug.Log(children.Child(i.ToString()).Child(LeadersAttributeName.SCORE).Value);
                    i++;
                }
            }
        });
    }
}