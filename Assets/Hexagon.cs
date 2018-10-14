public class Hexagon : ColliderObject
{
    public float shrinkSpeed = 0.25f;

    // Use this for initialization
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfShouldRemove(shrinkSpeed);
    }
}
