public class Hexagon : ColliderObject
{
    public float shrinkSpeed = 0.25f;

    void Update()
    {
        CheckIfShouldRemove(shrinkSpeed);
    }
}
