using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

[assembly: CLSCompliant(true)]

namespace Muldis.Example.ServiceProtocolClient
{
    public class MuseFactory
    {
        public MuseProvider WantVmApi(String, className, Object requestedVersion)
        {
            throw new NotImplementedException();
        }
    }

    public class MuseProvider
    {
        public MuseMachine WantVmModel(Object requestedVersion)
        {
            throw new NotImplementedException();
        }
    }

    public class MuseMachine
    {
        public MuseValue Evaluates(MuseValue function, MuseValue args = null)
        {
            throw new NotImplementedException();
        }

        public void Performs(MuseValue procedure, MuseValue args = null)
        {
            throw new NotImplementedException();
        }

        public MuseValue Any(Object value)
        {
            throw new NotImplementedException();
        }

        public MuseValue NewVariable(MuseValue initialCurrentValue)
        {
            throw new NotImplementedException();
        }

        public MuseValue NewProcess()
        {
            throw new NotImplementedException();
        }

        public MuseValue NewStream()
        {
            throw new NotImplementedException();
        }

        public MuseValue NewExternal(Object value)
        {
            throw new NotImplementedException();
        }

        public MuseValue Current(MuseValue variable)
        {
            throw new NotImplementedException();
        }

        public void Assign(MuseValue variable, MuseValue value)
        {
            throw new NotImplementedException();
        }

        public Object ExportExternalObject(MuseValue external)
        {
            throw new NotImplementedException();
        }
    }

    public class MuseValue
    {
        public MuseMachine Machine()
        {
            throw new NotImplementedException();
        }
    }
}
