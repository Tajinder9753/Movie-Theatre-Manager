using UnityEngine;

[CreateAssetMenu(fileName = "CustomerSO", menuName = "Scriptable Objects/CustomerSO")]
public class CustomerSO : ScriptableObject
{
    public bool buyingConcessions;
    public float concessionSpending;
    public bool isMessy;

    public MovieType preferredMovieType;
    public MovieType dislikedMovieType;
}
