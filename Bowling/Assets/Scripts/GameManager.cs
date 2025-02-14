using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    private FallTrigger[] pins;

    private void Start()
    {
        // This line of code wasn't compiling, and after a quick Google search
        // it seems that older versions of Unity don't support this "FindObjectsInactive"
        // without casting it explicitly.
        pins = FindObjectsByType<FallTrigger>((FindObjectsSortMode)FindObjectsInactive.Include);
        foreach(FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
    }
}
