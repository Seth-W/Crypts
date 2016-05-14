using System;

/**
*<summary>
*Generic Wrapper Class for event objects
*</summary>
*/
public class InfoEventArgs<T> : EventArgs
{
    public T info;

    public InfoEventArgs()
    {
        info = default(T);
    }
    public InfoEventArgs(T info)
    {
        this.info = info;
    }
}