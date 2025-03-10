namespace DesignPatterns.Contracts;

public interface IIterator<T>
{
    T CurrentItem();
    bool IsDone();
    void First();
    void Next();

}
