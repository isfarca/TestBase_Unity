using System;

[Serializable]
public class Leaders
{
    // Database attributes.
    public string email;
    public int score;

    /// <summary>
    /// Instantiate leader.
    /// </summary>
    /// <param name="email">Email address from leader.</param>
    /// <param name="score">Current Highscore from leader.</param>
    public Leaders(string email, int score)
    {
        // Set current value.
        this.email = email;
        this.score = score;
    }
}