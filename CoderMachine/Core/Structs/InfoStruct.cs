using System;
using System.Runtime.InteropServices;

namespace CoderMachine.Core
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct InfoStruct
    {
        [MarshalAs(UnmanagedType.U1, SizeConst = 1)]
        public byte SlotNum;

        [MarshalAs(UnmanagedType.U4, SizeConst = 4)]
        public UInt32 ModuleID;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] DeviceName;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] HardwareNum;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] HardwareVersion;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] SoftwareVersion;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] SoftwareDate;

    }
}
