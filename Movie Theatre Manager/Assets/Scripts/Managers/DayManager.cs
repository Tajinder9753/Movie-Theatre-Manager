using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    private int numScreens = 1;
    private int currentDay = 1;
    private List<Movie> availableMovies = new List<Movie>();
    private int maxPossibleMoviesToSelect = 5;
    private int minPossibleMoviesToSelect = 1;
    private int numMoviesAvailable = 1;
    private RoomManager currentRoom;

    [SerializeField] private RoomManager[] roomManagers;
    [SerializeField] private GameObject movieSelectionPanel;
    [SerializeField] private MovieInfoUI movieInfoPrefab;
    [SerializeField] private Transform contentRoot;
    [SerializeField] private TextMeshProUGUI roomText;
    [SerializeField] private TextMeshProUGUI dayText;

    private void Start()
    {
        StartDay();
        minPossibleMoviesToSelect = numScreens;
    }
    private void StartDay()
    {
        dayText.text = "Day: " + currentDay.ToString();
        //open movie selection canvas on first day and every 7 days
        if (currentDay == 1 || currentDay % 7 == 0)
        {
            roomText.text = "Room: 1";
            movieSelectionPanel.gameObject.SetActive(true);
            currentRoom = roomManagers[0]; // start selection from the first room
            GetAvailableMovies();
            //display available movies to select from
            DisplayMovies();
        }
    }

    //generate movies to select from based on the number of screens available
    private void GetAvailableMovies()
    {
        numMoviesAvailable = Random.Range(minPossibleMoviesToSelect, maxPossibleMoviesToSelect + 1);
        
        for (int i = 0; i < numMoviesAvailable; i++)
        {
            //generate a random movie and add it to the available movies list
            Movie newMovie = GenerateMovie();
            availableMovies.Add(newMovie);
        }
    }

    private Movie GenerateMovie()
    {
        //generate a random movie
        //fixed valus for now will be random later
        Movie newMovie = new Movie("Random Movie", 120, 0.5f, MovieType.Action, 7);
        return newMovie;
    }

    private void DisplayMovies()
    {
        foreach (Movie movie in availableMovies)
        {
            MovieInfoUI movieInfo = Instantiate(movieInfoPrefab, contentRoot);
            movieInfo.Initialize(movie, onMovieChosen);
        }
    }

    private void onMovieChosen(Movie movie)
    {
        currentRoom.AddMovie(movie);
        if (currentRoom == roomManagers[roomManagers.Length - 1])
        {
            //if the last room has been filled, close the movie selection canvas
            movieSelectionPanel.gameObject.SetActive(false);
        }
        else
        {
            //move to the next room
            roomText.text = "Room: " + (System.Array.IndexOf(roomManagers, currentRoom) + 2).ToString();
            currentRoom = roomManagers[System.Array.IndexOf(roomManagers, currentRoom) + 1];
        }
    }

    private void EndDay()
    {

    }

    //add a new screen when player buys one
    public void AddScreen()
    {
        numScreens++;
        minPossibleMoviesToSelect = numScreens;
    }
}
