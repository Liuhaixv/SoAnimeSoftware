﻿using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IMoveHelper : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetHostDlg(IntPtr ptr, Entity* host);

        public SetHostDlg _SetHost;

        public IMoveHelper(IntPtr Address) : base(Address)
        {
            _SetHost = GetInterfaceFunction<SetHostDlg>(1);
        }

        public void SetHost(Entity* host)
        {
            _SetHost(Address, host);
        }
    }
}