public class Hexagon : ColliderObject
{
    public float shrinkSpeed = 0.25f;

    void Start()
    {
        Setup();
    }

    void Update()
    {
        CheckIfShouldRemove(shrinkSpeed);
    }
}
