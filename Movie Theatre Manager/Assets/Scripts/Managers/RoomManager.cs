using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private Movie currentMoviePlaying;

    public void AddMovie(Movie movie)
    {
        currentMoviePlaying = movie;
        Debug.Log("current movie playing: " + currentMoviePlaying.title);
    }
}
