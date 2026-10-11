using UnityEngine;

public class Movie : MonoBehaviour
{
    public string title { get; private set; }
    public int duration { get; private set; }
    public float profitSharing { get; private set; }
    public MovieType genre { get; private set; }
    public int numDaysPlaying { get; private set; }
    public int numDaysLeft { get; private set; }
    public int numScreensPlaying { get; private set; } = 0;

    public Movie(string title, int duration, float profitSharing, MovieType genre, int numDaysPlaying)
    {
        this.title = title;
        this.duration = duration;
        this.profitSharing = profitSharing;
        this.genre = genre;
        this.numDaysPlaying = numDaysPlaying;
    }

    public void AddToScreen()
    {
        numScreensPlaying++;
    }

    public void EndDay()
    {
        numDaysLeft--;
    }
}
