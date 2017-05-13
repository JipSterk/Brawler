namespace Brawler
{
    public delegate void Callback();
    public delegate void Callback<in T0>(T0 t0);
    public delegate void Callback<in T0, in T1>(T0 t0, T1 t1);
    public delegate void Callback<in T0, in T1, in T2>(T0 t0, T1 t1, T2 t2);
    public delegate void Callback<in T0, in T1, in T2, in T3>(T0 t0, T1 t1, T2 t2, T3 t3);
    public delegate void Callback<in T0, in T1, in T2, in T3, in T4>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4);
    public delegate void Callback<in T0, in T1, in T2, in T3, in T4, in T5>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    public delegate void Callback<in T0, in T1, in T2, in T3, in T4, in T5, in T6>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
    public delegate void Callback<in T0, in T1, in T2, in T3, in T4, in T5, in T6, in T7>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
    public delegate void Callback<in T0, in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
    public delegate void Callback<in T0, in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
}