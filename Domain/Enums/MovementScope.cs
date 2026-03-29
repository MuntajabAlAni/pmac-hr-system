namespace Domain.Entities.Movements.Enums
{
    /// <summary>
    /// هل النقل او التنسيب او التكليف داخلي ام خارجي
    /// </summary>
    public enum MovementScope
    {
        Internal = 1,  // داخلي
        External = 2   // خارجي
    }
}