using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovieInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text durationText;
    [SerializeField] private TMP_Text profitSharingText;
    [SerializeField] private TMP_Text genreText;
    [SerializeField] private TMP_Text numDaysPlayingText;
    [SerializeField] private Button chooseButton;

    private Movie movie;
    private Action<Movie> onChosen;

    public void Initialize(Movie movie, Action<Movie> callback)
    {
        onChosen = callback;
        this.movie = movie;

        titleText.text = movie.title;
        durationText.text = $"Duration: {movie.duration} min";
        profitSharingText.text = $"Profit Sharing: {movie.profitSharing * 100}%";
        genreText.text = $"Genre: {movie.genre}";
        numDaysPlayingText.text = $"Days Playing: {movie.numDaysPlaying}";

        if (chooseButton != null)
        {
            chooseButton.onClick.RemoveAllListeners();
            chooseButton.onClick.AddListener(Choose);
        }
    }

    void Choose()
    {
        onChosen?.Invoke(movie);
    }
}
