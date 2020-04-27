using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct RustRandomParameters
{
    public int Min;
    public int Max;
}

public static class RustRandom
{
    private static IntPtr RngPtr;
    
    [DllImport("unity_rust")]
    private static extern IntPtr create_random_generator(RustRandomParameters parameters);
    
    [DllImport("unity_rust")]
    private static extern int get_random_int(IntPtr rngPtr);
    
    [DllImport("unity_rust")]
    private static extern void destroy_random_generator(IntPtr rngPtr);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Initialize()
    {
        RngPtr = create_random_generator(new RustRandomParameters()
        {
            Min = 0,
            Max = 100
        });
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetRandomInt()
    {
        return get_random_int(RngPtr);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Dispose()
    {
        destroy_random_generator(RngPtr);
    }
}
