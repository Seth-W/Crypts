/**
*<summary>
*Base interface for the ICommand types
*Contains methods to execute and undo
*</summary>
*/
public interface ICommand
{
    void Exectute();
    void Undo();
}
