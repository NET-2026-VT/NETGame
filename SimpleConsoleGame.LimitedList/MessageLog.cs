using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleGame.LimitedList;

public class MessageLog<T> : LimitedList<T>
{
    public MessageLog(int capacity) : base(capacity){}

    public override bool Add(T item)
    {
        if (IsFull) _list.RemoveAt(0);
        return base.Add(item);
    }
}
