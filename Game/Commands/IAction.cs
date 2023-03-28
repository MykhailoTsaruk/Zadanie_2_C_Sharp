namespace Game.Commands
{
    public interface IAction<T>
    {
        public void Execute(T value);
    }
}
