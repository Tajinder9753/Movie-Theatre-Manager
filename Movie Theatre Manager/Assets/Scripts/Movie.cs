using UnityEngine;

[CreateAssetMenu(fileName = "Movie", menuName = "Scriptable Objects/Movie")]
public class Movie : ScriptableObject
{
    public string movieName;
    public int numDaysPlaying;
    public float profitSharing;
}
