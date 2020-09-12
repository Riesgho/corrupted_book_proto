namespace Assets.CorruptedBook.Domain
{
    public interface IItem
    {
        Vector3Object GetPosition();
    }

    public struct Vector3Object
    {
        public float x;
        public float y;
        public float z;
    }
}