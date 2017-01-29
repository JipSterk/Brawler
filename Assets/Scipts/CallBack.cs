namespace Brawler
{
    public delegate void CallBack();
    public delegate void CallBack<T>(T t);
    public delegate void CallBack<T, U>(T t, U u);
    public delegate void CallBack<T, U, V>(T t, U u, V v);
}