using System.Collections;

namespace SimpleConsoleGame.LimitedList;

public class LimitedList<T> : ILimitedList<T>
{
    protected List<T> _list;
    private int _capacity;

    public int Count => _list.Count;
    public bool IsFull => _capacity <= Count;

    public T this[int index] => _list[index];
    //{
    //    get => _list[index]; 
    //    set => _list[index] = value; 
    //}

    public LimitedList(int capacity)
    {
        _capacity = Math.Max(capacity, 2);
        _list = new List<T>(_capacity);
    }

    public virtual bool Add(T item)
    {
        if (IsFull) return false;
        _list.Add(item); return true;
    }

    public void Print(Action<T> action)
    {
        // _list.ForEach(action);
        _list.ForEach(x => action?.Invoke(x));
    }

    public void ForEach(Action<T, int> action)
    {
        for (int i = 0; i < _list.Count; i++)
            action(_list[i], i);
    }

    public IEnumerator<T> GetEnumerator()
    {
        //return _list.GetEnumerator();
        foreach (T item in _list)
        {
            //....
            //....
            //....
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public bool Remove(T item) => _list.Remove(item);

}
