using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

[assembly: CLSCompliant(true)]

namespace Muldis.DatabaseProtocol
{
    public interface IInfo
    {
        Boolean ProvidesMuldisDatabaseProtocol();

        IMachine WantVmApi(Object requestedVersion);
    }

    public interface IMachine
    {
        IExecutor Executor();

        IImporter Importer();
    }

    public interface IExecutor
    {
        IMachine Machine();

        MdbpAny Evaluates(MdbpAny function, MdbpAny args = null);

        void Performs(MdbpAny procedure, MdbpAny args = null);
    }

    public interface IImporter
    {
        IMachine Machine();

        MdbpAny MdbpAny(Object value);

        MdbpBoolean MdbpBoolean(Boolean value);

        MdbpInteger MdbpInteger(BigInteger value);

        MdbpInteger MdbpInteger(Int32 value);

        MdbpFraction MdbpFraction(MdbpInteger numerator, MdbpInteger denominator);

        MdbpFraction MdbpFraction(BigInteger numerator, BigInteger denominator);

        MdbpFraction MdbpFraction(Int32 numerator, Int32 denominator);

        MdbpFraction MdbpFraction(Decimal value);

        MdbpFraction MdbpFraction(Double value);

        MdbpBits MdbpBits(BitArray members);

        MdbpBlob MdbpBlob(Byte[] members);

        MdbpText MdbpText(String members);

        MdbpArray MdbpArray(List<Object> members);

        MdbpSet MdbpSet(List<Object> members);

        MdbpBag MdbpBag(List<Object> members);

        MdbpInterval MdbpInterval();

        MdbpInterval MdbpInterval(Object value);

        MdbpInterval MdbpInterval(Object low, Object high,
            Boolean excludesLow = false, Boolean excludesHigh = false);

        MdbpIntervalSet MdbpIntervalSet(MdbpSet members);

        MdbpIntervalBag MdbpIntervalBag(MdbpBag members);

        MdbpTuple MdbpTuple(
            Object a0 = null, Object a1 = null, Object a2 = null,
            Dictionary<String,Object> attrs = null);

        MdbpTupleArray MdbpTupleArray(MdbpHeading heading);

        MdbpTupleArray MdbpTupleArray(MdbpArray body);

        MdbpRelation MdbpRelation(MdbpHeading heading);

        MdbpRelation MdbpRelation(MdbpSet body);

        MdbpTupleBag MdbpTupleBag(MdbpHeading heading);

        MdbpTupleBag MdbpTupleBag(MdbpBag body);

        MdbpUnit MdbpUnit(Dictionary<MdbpArticle,MdbpInteger> factors);

        MdbpUnit MdbpUnit(MdbpArticle label);

        MdbpMeasure MdbpMeasure(MdbpFraction coefficient, MdbpUnit unit);

        MdbpMeasure MdbpMeasure(MdbpArticle label);

        MdbpCompoundMeasure MdbpCompoundMeasure(Dictionary<MdbpFraction,MdbpUnit> terms);

        MdbpCompoundMeasure MdbpCompoundMeasure(MdbpArticle label);

        MdbpArticle MdbpArticle(MdbpAny label, MdbpTuple attrs = null);

        MdbpArticle MdbpArticle(String label, MdbpTuple attrs = null);

        MdbpArticle MdbpArticle(String[] label, MdbpTuple attrs = null);

        MdbpExcuse MdbpExcuse(MdbpAny label, MdbpTuple attrs = null);

        MdbpExcuse MdbpExcuse(String label, MdbpTuple attrs = null);

        MdbpExcuse MdbpExcuse(String[] label, MdbpTuple attrs = null);

        MdbpIgnorance MdbpIgnorance();

        MdbpNesting MdbpNesting(String[] label);

        MdbpHeading MdbpHeading(
            Nullable<Boolean> a0 = null, Nullable<Boolean> a1 = null,
            Nullable<Boolean> a2 = null, HashSet<String> attrNames = null);

        MdbpRenaming MdbpRenaming(Dictionary<String,String> attrNamesFromTo);

        MdbpEntity MdbpEntity(Object value);

        MdbpVariable NewMdbpVariable(MdbpAny initialCurrentValue);

        MdbpProcess NewMdbpProcess();

        MdbpStream NewMdbpStream();

        MdbpExternal NewMdbpExternal(Object value);
    }

    public interface MdbpAny
    {
        IMachine Machine();
    }

    public interface MdbpBoolean : MdbpAny
    {
        Boolean ExportBoolean();
    }

    public interface MdbpInteger : MdbpAny
    {
        BigInteger ExportBigInteger();

        Int32 ExportInt32();
    }

    public interface MdbpFraction : MdbpAny
    {
    }

    public interface MdbpBits : MdbpAny
    {
    }

    public interface MdbpBlob : MdbpAny
    {
    }

    public interface MdbpText : MdbpAny
    {
    }

    public interface MdbpArray : MdbpAny
    {
    }

    public interface MdbpSet : MdbpAny
    {
    }

    public interface MdbpBag : MdbpAny
    {
    }

    public interface MdbpInterval : MdbpAny
    {
    }

    public interface MdbpIntervalSet : MdbpAny
    {
    }

    public interface MdbpIntervalBag : MdbpAny
    {
    }

    public interface MdbpTuple : MdbpAny
    {
    }

    public interface MdbpTupleArray : MdbpAny
    {
    }

    public interface MdbpRelation : MdbpAny
    {
    }

    public interface MdbpTupleBag : MdbpAny
    {
    }

    public interface MdbpUnit : MdbpAny
    {
    }

    public interface MdbpMeasure : MdbpAny
    {
    }

    public interface MdbpCompoundMeasure : MdbpAny
    {
    }

    public interface MdbpArticle : MdbpAny
    {
    }

    public interface MdbpExcuse : MdbpAny
    {
    }

    public interface MdbpIgnorance : MdbpAny
    {
    }

    public interface MdbpNesting : MdbpAny
    {
    }

    public interface MdbpHeading : MdbpAny
    {
    }

    public interface MdbpRenaming : MdbpAny
    {
    }

    public interface MdbpEntity : MdbpAny
    {
    }

    public interface MdbpHandle : MdbpAny
    {
    }

    public interface MdbpVariable : MdbpHandle
    {
        MdbpAny Current();

        void Assign(MdbpAny value);
    }

    public interface MdbpProcess : MdbpHandle
    {
    }

    public interface MdbpStream : MdbpHandle
    {
    }

    public interface MdbpExternal : MdbpHandle
    {
        Object ExportExternalObject();
    }
}
