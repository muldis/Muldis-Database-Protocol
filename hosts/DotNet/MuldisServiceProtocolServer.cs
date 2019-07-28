using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

[assembly: CLSCompliant(true)]

namespace Muldis.Example.ServiceProtocolServer
{
    public interface IFactory
    {
        ProvidesMuldisServiceProtocol();

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

        IValue Current(MuseValue variable);

        void Assign(MuseValue variable, IValue value);

        Object ExportExternalObject(MuseValue external);
    }

    public interface IValue
    {
        IMachine Machine();
    }
}
