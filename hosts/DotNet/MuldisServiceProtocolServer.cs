using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

[assembly: CLSCompliant(true)]

namespace Muldis.Example.DatabaseProtocolServer
{
    public interface IFactory
    {
        ProvidesMuldisDatabaseProtocol();

        IProvider WantVmApi(Object requestedVersion);
    }

    public interface IProvider
    {
        IMachine WantVmModel(Object requestedVersion);
    }

    public interface IMachine
    {
        IValue Evaluates(IValue function, IValue args = null);

        void Performs(IValue procedure, IValue args = null);

        IValue Any(Object value);

        IValue NewVariable(IValue initialCurrentValue);

        IValue NewProcess();

        IValue NewStream();

        IValue NewExternal(Object value);

        IValue Current(MdbpValue variable);

        void Assign(MdbpValue variable, IValue value);

        Object ExportExternalObject(MdbpValue external);
    }

    public interface IValue
    {
        IMachine Machine();
    }
}
