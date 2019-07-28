using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

[assembly: CLSCompliant(true)]

namespace Muldis.ServiceProtocol
{
    public interface IInfo
    {
        Boolean ProvidesMuldisServiceProtocol();

        IMachine WantVmApi(Object requestedVersion);
    }

    public interface IMachine
    {
        MuseAny Evaluates(MuseAny function, MuseAny args = null);

        void Performs(MuseAny procedure, MuseAny args = null);

        MuseAny MuseAny(Object value);

        MuseBoolean MuseBoolean(Boolean value);

        MuseInteger MuseInteger(BigInteger value);

        MuseInteger MuseInteger(Int32 value);

        MuseFraction MuseFraction(MuseInteger numerator, MuseInteger denominator);

        MuseFraction MuseFraction(BigInteger numerator, BigInteger denominator);

        MuseFraction MuseFraction(Int32 numerator, Int32 denominator);

        MuseFraction MuseFraction(Decimal value);

        MuseFraction MuseFraction(Double value);

        MuseBits MuseBits(BitArray members);

        MuseBlob MuseBlob(Byte[] members);

        MuseText MuseText(String members);

        MuseArray MuseArray(List<Object> members);

        MuseSet MuseSet(List<Object> members);

        MuseBag MuseBag(List<Object> members);

        MuseInterval MuseInterval();

        MuseInterval MuseInterval(Object value);

        MuseInterval MuseInterval(Object low, Object high,
            Boolean excludesLow = false, Boolean excludesHigh = false);

        MuseIntervalSet MuseIntervalSet(MuseSet members);

        MuseIntervalBag MuseIntervalBag(MuseBag members);

        MuseTuple MuseTuple(
            Object a0 = null, Object a1 = null, Object a2 = null,
            Dictionary<String,Object> attrs = null);

        MuseTupleArray MuseTupleArray(MuseHeading heading);

        MuseTupleArray MuseTupleArray(MuseArray body);

        MuseRelation MuseRelation(MuseHeading heading);

        MuseRelation MuseRelation(MuseSet body);

        MuseTupleBag MuseTupleBag(MuseHeading heading);

        MuseTupleBag MuseTupleBag(MuseBag body);

        MuseUnit MuseUnit(Dictionary<MuseArticle,MuseInteger> factors);

        MuseUnit MuseUnit(MuseArticle label);

        MuseMeasure MuseMeasure(MuseFraction coefficient, MuseUnit unit);

        MuseMeasure MuseMeasure(MuseArticle label);

        MuseCompoundMeasure MuseCompoundMeasure(Dictionary<MuseFraction,MuseUnit> terms);

        MuseCompoundMeasure MuseCompoundMeasure(MuseArticle label);

        MuseArticle MuseArticle(MuseAny label, MuseTuple attrs = null);

        MuseArticle MuseArticle(String label, MuseTuple attrs = null);

        MuseArticle MuseArticle(String[] label, MuseTuple attrs = null);

        MuseExcuse MuseExcuse(MuseAny label, MuseTuple attrs = null);

        MuseExcuse MuseExcuse(String label, MuseTuple attrs = null);

        MuseExcuse MuseExcuse(String[] label, MuseTuple attrs = null);

        MuseIgnorance MuseIgnorance();

        MuseNesting MuseNesting(String[] label);

        MuseHeading MuseHeading(
            Nullable<Boolean> a0 = null, Nullable<Boolean> a1 = null,
            Nullable<Boolean> a2 = null, HashSet<String> attrNames = null);

        MuseRenaming MuseRenaming(Dictionary<String,String> attrNamesFromTo);

        MuseEntity MuseEntity(Object value);

        MuseVariable NewMuseVariable(MuseAny initialCurrentValue);

        MuseProcess NewMuseProcess();

        MuseStream NewMuseStream();

        MuseExternal NewMuseExternal(Object value);
    }

    public interface MuseAny
    {
        IMachine Machine();
    }

    public interface MuseBoolean : MuseAny
    {
        Boolean ExportBoolean();
    }

    public interface MuseInteger : MuseAny
    {
        BigInteger ExportBigInteger();

        Int32 ExportInt32();
    }

    public interface MuseFraction : MuseAny
    {
    }

    public interface MuseBits : MuseAny
    {
    }

    public interface MuseBlob : MuseAny
    {
    }

    public interface MuseText : MuseAny
    {
    }

    public interface MuseArray : MuseAny
    {
    }

    public interface MuseSet : MuseAny
    {
    }

    public interface MuseBag : MuseAny
    {
    }

    public interface MuseInterval : MuseAny
    {
    }

    public interface MuseIntervalSet : MuseAny
    {
    }

    public interface MuseIntervalBag : MuseAny
    {
    }

    public interface MuseTuple : MuseAny
    {
    }

    public interface MuseTupleArray : MuseAny
    {
    }

    public interface MuseRelation : MuseAny
    {
    }

    public interface MuseTupleBag : MuseAny
    {
    }

    public interface MuseUnit : MuseAny
    {
    }

    public interface MuseMeasure : MuseAny
    {
    }

    public interface MuseCompoundMeasure : MuseAny
    {
    }

    public interface MuseArticle : MuseAny
    {
    }

    public interface MuseExcuse : MuseAny
    {
    }

    public interface MuseIgnorance : MuseAny
    {
    }

    public interface MuseNesting : MuseAny
    {
    }

    public interface MuseHeading : MuseAny
    {
    }

    public interface MuseRenaming : MuseAny
    {
    }

    public interface MuseEntity : MuseAny
    {
    }

    public interface MuseHandle : MuseAny
    {
    }

    public interface MuseVariable : MuseHandle
    {
        MuseAny Current();

        void Assign(MuseAny value);
    }

    public interface MuseProcess : MuseHandle
    {
    }

    public interface MuseStream : MuseHandle
    {
    }

    public interface MuseExternal : MuseHandle
    {
        Object ExportExternalObject();
    }
}
