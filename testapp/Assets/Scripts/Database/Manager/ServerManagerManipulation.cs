using System;
using UnityEngine;

public static partial class ServerManager
{
    /// <summary>
    /// Add new leader.
    /// </summary>
    /// <param name="email">Email address.</param>
    /// <param name="score">Highscore.</param>
    /// <param name="callback">After finishing to called function.</param>
    public static void WriteLeader(string email, int score, Action<string> callback = null)
    {
        // Send new leader to database.
        var leader = new Leaders(email, score);
        var json = JsonUtility.ToJson(leader);
        //ConnectionReference.Child(TABLE_NAME).Child(userId).SetRawJsonValueAsync(json);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="attributeName"></param>
    /// <param name="newValue"></param>
    /// <param name="callback"></param>
    public static void UpdateAttribute(string id, string attributeName, string newValue, Action<string> callback = null)
    {
        ConnectionReference.Child(TABLE_NAME).Child(id).Child(attributeName).SetValueAsync(newValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="callback"></param>
    public static void RemoveItem(string id, Action<string> callback = null)
    {
        ConnectionReference.Child(TABLE_NAME).Child(id).RemoveValueAsync();
    }
}