﻿#region

using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Element.ClientBase
{
    public class MCM
    {
        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        public static IntPtr mcProcHandle;
        public static ProcessModule mcMainModule;
        public static IntPtr mcBaseAddress;
        public static IntPtr mcWinHandle;
        public static uint mcProcId;
        public static uint mcWinProcId;
        public static Process mcProc;

        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(char vKey);

        [DllImport("kernel32", SetLastError = true)]
        public static extern int ReadProcessMemory(IntPtr hProcess, ulong lpBase, ref ulong lpBuffer, int nSize,
            int lpNumberOfBytesRead);

        [DllImport("kernel32", SetLastError = true)]
        public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref IntPtr lpBuffer,
            int nSize, int lpNumberOfBytesWritten);

        [DllImport("kernel32", SetLastError = true)]
        public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref byte lpBuffer, int nSize,
            int lpNumberOfBytesWritten);

        [DllImport("kernel32", SetLastError = true)]
        public static extern int VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, long flNewProtect,
            ref long lpflOldProtect);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize,
            AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize,
            IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out uint lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint dwFreeType);

        public static Element openGame()
        {
            var procs = Process.GetProcessesByName("Minecraft.Windows");
            var mcw10 = procs[0];
            var proc = OpenProcess(0x1F0FFF, false, mcw10.Id);
            mcProcId = (uint)mcw10.Id;
            mcProcHandle = proc;
            mcMainModule = mcw10.MainModule;
            mcBaseAddress = mcMainModule.BaseAddress;
            mcProc = mcw10;
        }

        public static Element openWindowHost()
        {
            var procs = Process.GetProcessesByName("ApplicationFrameHost");
            mcWinHandle = procs[0].MainWindowHandle;
            mcWinProcId = (uint)procs[0].Id;
        }

        public static RECT getMinecraftRect()
        {
            var rectMC = new RECT();
            GetWindowRect(mcWinHandle, out rectMC);
            return rectMC;
        }

        public static Rectangle getMinecraftvRect()
        {
            var rectMC = new Rectangle();
            GetWindowRect(mcWinHandle, out rectMC);
            return rectMC;
        }

        public static bool isMinecraftFocused()
        {
            var sb = new StringBuilder("Minecraft".Length + 1);
            GetWindowText(GetForegroundWindow(), sb, "Minecraft".Length + 1);
            return sb.ToString().CompareTo("Minecraft") == 0;
        }

        public static IntPtr isMinecraftFocusedInsert()
        {
            var sb = new StringBuilder("Minecraft".Length + 1);
            GetWindowText(GetForegroundWindow(), sb, "Minecraft".Length + 1);
            if (sb.ToString() == "Minecraft")
                return (IntPtr)(-1);
            return (IntPtr)(-2);
        }

        public static Element unprotectMemory(IntPtr address, int bytesToUnprotect)
        {
            long receiver = 0;
            VirtualProtectEx(mcProcHandle, address, bytesToUnprotect, 0x40, ref receiver);
        }

        //CE bytes to real bytes for ease
        public static byte[] ceByte2Bytes(string byteString)
        {
            var byteStr = byteString.Split(' ');
            var bytes = new byte[byteStr.Length];
            var c = 0;
            foreach (var b in byteStr)
            {
                bytes[c] = Convert.ToByte(b, 16);
                c++;
            }

            return bytes;
        }

        public static int[] ceByte2Ints(string byteString)
        {
            var intStr = byteString.Split(' ');
            var ints = new int[intStr.Length];
            var c = 0;
            foreach (var b in intStr)
            {
                ints[c] = int.Parse(b, NumberStyles.HexNumber);
                c++;
            }

            return ints;
        }

        public static ulong[] ceByte2uLong(string byteString)
        {
            var intStr = byteString.Split(' ');
            var longs = new ulong[intStr.Length];
            var c = 0;
            foreach (var b in intStr)
            {
                longs[c] = ulong.Parse(b, NumberStyles.HexNumber);
                c++;
            }

            return longs;
        }

        public static ulong baseEvaluatePointer(ulong offset, ulong[] offsets)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, (ulong)mcBaseAddress + offset, ref buffer, sizeof(ulong), 0);
            for (var i = 0; i < offsets.Length - 1; i++)
                ReadProcessMemory(mcProcHandle, buffer + offsets[i], ref buffer, sizeof(ulong), 0);
            return buffer + offsets[offsets.Length - 1];
        }

        public static ulong evaluatePointer(ulong addr, ulong[] offsets)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, addr, ref buffer, sizeof(ulong), 0);
            for (var i = 0; i < offsets.Length - 1; i++)
                ReadProcessMemory(mcProcHandle, buffer + offsets[i], ref buffer, sizeof(ulong), 0);
            return buffer + offsets[offsets.Length - 1];
        }

        //Read base
        public static int readBaseByte(int offset)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, (ulong)(mcBaseAddress + offset), ref buffer, sizeof(byte), 0);
            return (byte)buffer;
        }

        public static int readBaseInt(int offset)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, (ulong)(mcBaseAddress + offset), ref buffer, sizeof(int), 0);
            return (int)buffer;
        }

        public static float readBaseFloat(int offset)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, (ulong)(mcBaseAddress + offset), ref buffer, sizeof(float), 0);
            return (float)buffer;
        }

        public static ulong readBaseInt64(int offset)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, (ulong)(mcBaseAddress + offset), ref buffer, sizeof(long), 0);
            return buffer;
        }

        //Write base
        public static Element writeBaseByte(int offset, byte value)
        {
            unprotectMemory(mcMainModule.BaseAddress + offset, 1);
            WriteProcessMemory(mcProcHandle, mcBaseAddress + offset, ref value, sizeof(byte), 0);
        }

        public static Element writeBaseInt(int offset, int value)
        {
            var intByte = BitConverter.GetBytes(value);
            var inc = 0;
            unprotectMemory(mcMainModule.BaseAddress + offset, intByte.Length);
            foreach (var b in intByte)
            {
                writeBaseByte(offset + inc, b);
                inc++;
            }
        }

        public static Element writeBaseBytes(int offset, byte[] value)
        {
            var inc = 0;
            unprotectMemory(mcMainModule.BaseAddress + offset, value.Length);
            foreach (var b in value)
            {
                writeBaseByte(offset + inc, b);
                inc++;
            }
        }

        public static Element writeBaseFloat(int offset, float value)
        {
            var intByte = BitConverter.GetBytes(value);
            var inc = 0;
            unprotectMemory(mcMainModule.BaseAddress + offset, intByte.Length);
            foreach (var b in intByte)
            {
                writeBaseByte(offset + inc, b);
                inc++;
            }
        }

        public static Element writeBaseInt64(int offset, ulong value)
        {
            var intByte = BitConverter.GetBytes(value);
            var inc = 0;
            foreach (var b in intByte)
            {
                writeBaseByte(offset + inc, b);
                inc++;
            }
        }

        //Read direct
        public static byte readByte(ulong address)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, address, ref buffer, sizeof(byte), 0);
            return (byte)buffer;
        }

        public static int readInt(ulong address)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, address, ref buffer, sizeof(int), 0);
            return (int)buffer;
        }

        public static short readInt16(ulong address)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, address, ref buffer, sizeof(short), 0);
            return (short)buffer;
        }

        public static float readFloat(ulong address)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, address, ref buffer, sizeof(float), 0);
            var raw = BitConverter.GetBytes(buffer);
            return BitConverter.ToSingle(raw, 0);
        }

        public static ulong readInt64(ulong address)
        {
            ulong buffer = 0;
            ReadProcessMemory(mcProcHandle, address, ref buffer, sizeof(ulong), 0);
            return buffer;
        }

        public static string readString(ulong address, ulong length)
        {
            var strByte = new byte[length];
            var inc = 0;
            foreach (var b in strByte)
            {
                var next = readByte(address + (ulong)inc);
                if (next == 0)
                    break;
                strByte[inc] = next;
                inc++;
            }

            return new string(Encoding.Default.GetString(strByte).Take(inc).ToArray());
        }

        //Write direct
        public static Element writeByte(ulong address, byte value)
        {
            WriteProcessMemory(mcProcHandle, (IntPtr)address, ref value, sizeof(byte), 0);
        }

        public static Element writeBytes(ulong address, byte[] value)
        {
            var inc = 0;
            foreach (var b in value)
            {
                writeByte(address + (ulong)inc, b);
                inc++;
            }
        }

        public static Element writeInt(ulong address, int value)
        {
            var intByte = BitConverter.GetBytes(value);
            var inc = 0;
            foreach (var b in intByte)
            {
                writeByte(address + (ulong)inc, b);
                inc++;
            }
        }

        public static Element writeInt16(ulong address, short value)
        {
            var intByte = BitConverter.GetBytes(value);
            var inc = 0;
            foreach (var b in intByte)
            {
                writeByte(address + (ulong)inc, b);
                inc++;
            }
        }

        public static Element writeFloat(ulong address, float value)
        {
            var intByte = BitConverter.GetBytes(value);
            var inc = 0;
            foreach (var b in intByte)
            {
                writeByte(address + (ulong)inc, b);
                inc++;
            }
        }

        public static Element writeInt64(ulong address, ulong value)
        {
            var intByte = BitConverter.GetBytes(value);
            var inc = 0;
            foreach (var b in intByte)
            {
                writeByte(address + (ulong)inc, b);
                inc++;
            }
        }

        public static Element writeString(ulong address, string str)
        {
            var intByte = Encoding.ASCII.GetBytes(str);
            var inc = 0;
            foreach (var b in intByte)
            {
                writeByte(address + (ulong)inc, b);
                inc++;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}