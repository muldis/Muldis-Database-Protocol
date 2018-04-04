using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

[assembly: CLSCompliant(true)]

namespace Muldis.Example.DatabaseProtocolClient
{
    public class MdbpFactory
    {
        public MdbpProvider WantVmApi(String, className, Object requestedVersion)
        {
            throw new NotImplementedException();
        }
    }

    public class MdbpProvider
    {
        public MdbpMachine WantVmModel(Object requestedVersion)
        {
            throw new NotImplementedException();
        }
    }

    public class MdbpMachine
    {
        public MdbpValue Evaluates(MdbpValue function, MdbpValue args = null)
        {
            throw new NotImplementedException();
        }

        public void Performs(MdbpValue procedure, MdbpValue args = null)
        {
            throw new NotImplementedException();
        }

        public MdbpValue Any(Object value)
        {
            throw new NotImplementedException();
        }

        public MdbpValue NewVariable(MdbpValue initialCurrentValue)
        {
            throw new NotImplementedException();
        }

        public MdbpValue NewProcess()
        {
            throw new NotImplementedException();
        }

        public MdbpValue NewStream()
        {
            throw new NotImplementedException();
        }

        public MdbpValue NewExternal(Object value)
        {
            throw new NotImplementedException();
        }

        public MdbpValue Current(MdbpValue variable)
        {
            throw new NotImplementedException();
        }

        public void Assign(MdbpValue variable, MdbpValue value)
        {
            throw new NotImplementedException();
        }

        public Object ExportExternalObject(MdbpValue external)
        {
            throw new NotImplementedException();
        }
    }

    public class MdbpValue
    {
        public MdbpMachine Machine()
        {
            throw new NotImplementedException();
        }
    }
}
