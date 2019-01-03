using System;
using System.Runtime.InteropServices;

namespace CoderMachine.Core.Structs
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ProductStruct
    {
        [MarshalAs(UnmanagedType.U1, SizeConst = 1)]
        public byte No;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public char[] UID;

        [MarshalAs(UnmanagedType.R8, SizeConst = 4)]
        public double Current;

        [MarshalAs(UnmanagedType.U1, SizeConst = 1)]
        public byte Pass;

    }
}
