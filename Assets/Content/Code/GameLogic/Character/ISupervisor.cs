namespace Character
{
    public interface ISupervisor
    {
        Command CurrenntCommand { get; }
        void Consume();
    }
}