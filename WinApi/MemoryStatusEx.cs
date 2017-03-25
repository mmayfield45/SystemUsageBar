﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WinApi.Structures
{
    /// <summary>
    /// contains information about the current state of both physical and virtual memory, including extended memory
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MemoryStatusEx
    {
        /// <summary>
        /// Size of the structure, in bytes. You must set this member before calling GlobalMemoryStatusEx. 
        /// </summary>
        public uint dwLength;

        /// <summary>
        /// Number between 0 and 100 that specifies the approximate percentage of physical memory that is in use (0 indicates no memory use and 100 indicates full memory use). 
        /// </summary>
        public uint dwMemoryLoad;

        /// <summary>
        /// Total size of physical memory, in bytes.
        /// </summary>
        public ulong ullTotalPhys;

        /// <summary>
        /// Size of physical memory available, in bytes. 
        /// </summary>
        public ulong ullAvailPhys;

        /// <summary>
        /// Size of the committed memory limit, in bytes. This is physical memory plus the size of the page file, minus a small overhead. 
        /// </summary>
        public ulong ullTotalPageFile;


        /// <summary>
        /// Size of available memory to commit, in bytes. The limit is ullTotalPageFile. 
        /// </summary>
        public ulong ullAvailPageFile;

        /// <summary>
        /// Total size of the user mode portion of the virtual address space of the calling process, in bytes. 
        /// </summary>
        public ulong ullTotalVirtual;

        /// <summary>
        /// Size of unreserved and uncommitted memory in the user mode portion of the virtual address space of the calling process, in bytes. 
        /// </summary>
        public ulong ullAvailVirtual;

        /// <summary>
        /// Size of unreserved and uncommitted memory in the extended portion of the virtual address space of the calling process, in bytes. 
        /// </summary>
        public ulong ullAvailExtendedVirtual;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WinApi.Structures.MemoryStatusEx"/> class.
        /// </summary>
        public MemoryStatusEx()
        {
            this.dwLength = (uint)Marshal.SizeOf(typeof(MemoryStatusEx));
        }
    }
}
