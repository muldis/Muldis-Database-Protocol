# NAME

Muldis Service Protocol (MUSE) -
Abstract library API for noncoupled services

# VERSION

The fully-qualified name of this document is
`Muldis_Service_Protocol http://muldis.com 0.300.0`.

# SYNOPSIS

*TODO.*

# DESCRIPTION

This document is the human readable authoritative formal specification named
**Muldis Service Protocol** (**MUSE**).
The fully-qualified name of this document and specification is
`Muldis_Service_Protocol http://muldis.com 0.300.0`.
This is the official/original version by the authority Muldis Data Systems
(`http://muldis.com`), version number `0.300.0`.

**Muldis Service Protocol** specifies an abstract library API for
noncoupled services, particularly database
engines.  It is completely language independent but uses conventions that
are familiar to programmers of many other languages.  It often takes the
form of API documentation for a pseudocode virtual library named **FooDB**.

An actual concrete library in some programming language that implements and
is fully conformant to the MUSE specification is one that provides an API
that is a (possibly non-proper) superset of the API of the virtual library
defined here.  And so, any applications or other libraries depending on the
MUSE should be fully portable between all such conforming libraries of
their own programming language or platform, at least with respect to what
the API spec defines; furthermore, dependents should be able to
programmatically discover to what degree the entire feature set and API of
the implementing library is able to satisfy its needs and gracefully handle
when they aren't met.

**Muldis Service Protocol** is expressly designed so that multiple
implementing service providers or
DBMS engines etc can be drop-in compatible for each other
while at the same time having no library dependencies in common.  This is
in stark contrast to typical cross-DBMS access solutions which require a
common shared implementing codebase, extensible with a plug-in
architecture, regardless of what backend is in use.  Shared-nothing is a
primary MUSE feature, at least in principle; implementations can choose to
have shared code, but MUSE makes no requirements that they do so.

This document also uses the terms *MUSE server* and *MUSE client* to refer
to, respectively, a concrete library that supports being invoked with the
MUSE API, and a concrete application (or library) that supports invoking
something else with the MUSE API.

**Muldis Service Protocol** is bundled with a set of reference API
specifications such that each of the latter is specific to an externally
defined programming language and demonstrates how to apply the abstract
MUSE to the particular paradigms/features/idioms of that language.  Where
the language supports the concept, which is common, the reference API is an
actual concrete interface-defining source code file which can be included
in or be a concrete dependency for a MUSE implementation in that language.

See the language-specific subdirectories of [hosts](../hosts) for those.

# DEPENDENCIES

**Muldis Service Protocol** has formal dependencies on, and is defined
partly in terms of, the externally defined formal specifications named
**Muldis Content Predicate** (**MCP**) and
**Muldis Object Notation** (**MUON**).

See [https://github.com/muldis/Muldis_Content_Predicate](
https://github.com/muldis/Muldis_Content_Predicate)
and [https://github.com/muldis/Muldis_Object_Notation](
https://github.com/muldis/Muldis_Object_Notation) for those.

The MUSE specification liberally re-uses concepts and definitions from
those externals, so they should be read and understood as necessary in order
to best understand the current document.

# INTERFACE

This document uses some object-oriented terminology such as *class* and
*object* to describe the abstract API, but an object-oriented language is
not required to implement it.  Conversely, this document describes routines
such that all arguments are explicit, and none are described as object
instance methods, but an OO language is free to use such if it wants to.

The interface of **FooDB** primarily uses the *abstract factory* and
*factory method* design patterns; users are expected in general to not need
to know the actual implementing classes of the objects they create or are
given, just that the objects provide expected interfaces and behaviour.

Otherwise, **FooDB** most frequently uses the *command* or *interpreter*
design patterns; the API has a fairly small number of actual routines, such
that users invoke them with structures (either native or serialized) that
describe a desired action to take, and receive back structures describing
the results.

A *MUSE client* would typically use the *bridge* design pattern for the
portion of its code that actually speaks the MUSE, especially when the
implementing language features compile-time type checking and binding, so
that the majority of the client code can be written in terms of specific
and known type or class names or equivalents, and it can avoid the added
complexities of dealing with runtime reflection itself.

**Muldis Service Protocol** is generally agnostic to command languages and
data models and is designed to be usable with many different ones.

This document uses *snake case*, for example `Foo_Bar`, as its generic
naming convention for the API components; however, each implementation does
not need to follow this, and indeed the bundled language-specific reference
API specifications will instead follow the standard naming conventions of
those languages.

This document gives the `MUSE_` prefix for type/class names that are
defined by the API, and gives the `SYS_` prefix for type/class names that
are defined by the host/implementing programming language, so that they are
not confused; actual implementations should use non-conflicting names also.

## MUSE_Entrance

A concrete library in some programming language that implements MUSE will
have exactly one entrance class, whose name the user needs to know, which
is the initial entrance class to bootstrap the API.  That entrance class is
represented in this document by the fake class name `MUSE_Entrance`.  An
application using a MUSE-implementing library might either hard-code this
class name if it is only using a specific one, or it might load that name
from a configuration file if it lets users specify the library to use.

## MUSE_Entrance::Provides_Muldis_Service_Protocol_Entrance()

```
    procedure MUSE_Entrance::Provides_Muldis_Service_Protocol_Entrance()
```

The procedure `MUSE_Entrance::Provides_Muldis_Service_Protocol_Entrance`
exists entirely to serve as a "magic number" that identifies the library as
one that implements the **Muldis Service Protocol**, or specifically that
some given class provides the `MUSE_Entrance` API.  An application which
takes instruction from the user or a config file on which MUSE-implementing
library to use can do appropriate sanity checks elegantly with the host
language's reflection capabilities, checking for the existence of the
requested entrance class and that said class provides this niladic
procedure, and only proceeding further to try and use the entrance if it
does.  Actually invoking this procedure should be a no-op.

## MUSE_Entrance::New_MUSE_Factory(SYS_Object requested_MUSE_version)

```
    function MUSE_Factory MUSE_Entrance::New_MUSE_Factory(
        SYS_Object requested_MUSE_version)
```

The function `MUSE_Entrance::New_MUSE_Factory` will attempt to result in a
new `MUSE_Factory` object that implements the specific version/set of the
MUSE API named by its `requested_MUSE_version` argument; this function will
instead result in failure if it can't provide such an object.

## MUSE_Factory

A concrete library in some programming language that implements MUSE will
have at least one class, whose name the user should not need to know, each
of whose objects provides a specific version/set of the MUSE API.  Each
such class is represented in this document by the fake class name
`MUSE_Factory`.  The primary reason that the `MUSE_Factory` exists,
rather than `MUSE_Entrance` handling its functionality, is so that the
latter can be absolutely as small as possible, so there can be the greatest
potential variance between versions of the MUSE API.  A *MUSE client* would
typically utilize a separate *bridge* class (either its own or that of
another library) and avoid hard-coding any `MUSE_Factory` class name.

## MUSE_Factory::Provides_Muldis_Service_Protocol_Factory()

```
    procedure MUSE_Factory::Provides_Muldis_Service_Protocol_Factory()
```

The procedure `MUSE_Factory::Provides_Muldis_Service_Protocol_Factory`
exists to identify that some given class provides the `MUSE_Factory` API.
Any code that wants to know if some given object is usable as a
`MUSE_Factory` object can start by using the host language's reflection
capabilities to test that the object's class declares this procedure.
Actually invoking this procedure should be a no-op.

## MUSE_Factory::New_MUSE_Machine(MUSE_Factory factory, SYS_Object requested_model_version)

```
    function MUSE_Machine MUSE_Factory::New_MUSE_Machine(
        MUSE_Factory factory
        SYS_Object requested_model_version)
```

The function `MUSE_Factory::New_MUSE_Machine` will attempt to result in a
new `MUSE_Machine` object that implements the specific version/set of the
MUSE API represented by its `factory` argument, such that the DBMS /
virtual machine represented by the `MUSE_Machine` fundamentally behaves
according to the data model version/set named by its
`requested_model_version` argument; this function will instead result in
failure if it can't provide such an object.

## MUSE_Machine

A concrete library in some programming language that implements MUSE will
have at least one class, whose name the user should not need to know, each
of whose objects represents a single active instance of a database
management system (DBMS) or virtual machine environment, which is the
widest scope stateful context in which any other database activities
happen.  Each such class is represented in this document by the fake class
name `MUSE_Machine`.  A *MUSE client* would typically utilize a separate
*bridge* class (either its own or that of another library) and avoid
hard-coding any `MUSE_Machine` class name.

The *any other database activities* refers to the creation or destruction
or association or disassociation with one or more databases, the authoring
or compilation or execution of routines, either to fetch data or manipulate
data, the creation or destruction of database constraints, the management
of transactions, and so on.  A `MUSE_Machine` object also represents the
global memory pool of an active DBMS instance, within which all processes
and values and variables live.

A typical application would use exactly one `MUSE_Machine` object at a time
and it would tend to be as long-lived as the application process itself.
Some libraries implementing MUSE may treat a `MUSE_Machine` as a singleton,
so only one such object may exist at a time through which it manages
resources; other implementers may allow several at once, in which case they
should be completely independent.

## MUSE_Machine::Provides_Muldis_Service_Protocol_Machine()

```
    procedure MUSE_Machine::Provides_Muldis_Service_Protocol_Machine()
```

The procedure `MUSE_Machine::Provides_Muldis_Service_Protocol_Machine`
exists to identify that some given class provides the `MUSE_Machine` API.
Any code that wants to know if some given object is usable as a
`MUSE_Machine` object can start by using the host language's reflection
capabilities to test that the object's class declares this procedure.
Actually invoking this procedure should be a no-op.

## MUSE_Value

A `MUSE_Value` object represents a single in-DBMS value of the `Any` type,
meaning both regular constant values as well as mutable `Handle` values.
A `MUSE_Value` object is associated with a specific `Machine` object, the one
whose `new_value` method created it.  `MUSE_Value` objects are the normal way
to directly share or move data between the DBMS and main .NET environments.
The way to represent an in-DBMS variable with a `MUSE_Value` object is to use
a *value* whose *data type* is `Variable`.  The way to represent an
in-DBMS process with a `Value` object is to use a *value* whose *data
type* is `Process`.

## MUSE_Value::Provides_Muldis_Service_Protocol_Value()

```
    procedure MUSE_Value::Provides_Muldis_Service_Protocol_Value()
```

The procedure `MUSE_Value::Provides_Muldis_Service_Protocol_Value`
exists to identify that some given class provides the `MUSE_Value` API.
Any code that wants to know if some given object is usable as a
`MUSE_Value` object can start by using the host language's reflection
capabilities to test that the object's class declares this procedure.
Actually invoking this procedure should be a no-op.


*TODO.*

# VERSIONING

Every version of this specification document is expected to declare its own
fully-qualified name, or *identity*, so that it can easily be referred to
and be distinguished from every other version that does or might exist.

The expected fully-qualified name of every version of this specification
document, as either declared in said document or as referenced by other
documents or by source code, has 3 main parts: *document base name*,
*authority*, and *version number*.

The *document base name* is the character string `Muldis_Service_Protocol`.

An *authority* is some nonempty character string whose value uniquely
identifies the authority or author of the versioned entity.  Generally
speaking, the community at large should self-regulate authority identifier
strings so they are reasonable formats and so each prospective
authority/author has one of their own that everyone recognizes as theirs.
Note that an authority/author doesn't have to be an individual person; it
could be some corporate entity instead.

Examples of recommended *authority* naming schemes include a qualified
base HTTP url belonging to the authority (example `http://muldis.com`) or
a qualified user identifier at some well-known asset repository
(example `http://github.com/muldis` or `cpan:DUNCAND`).

For all official/original works by Muldis Data Systems, Inc., the
*authority* has always been `http://muldis.com` and is expected to remain
so during the foreseeable future.

If someone else wants to *embrace and extend* this specification document,
then they must use their own (not `http://muldis.com`) base authority
identifier, to prevent ambiguity, assist quality control, and give due credit.

In this context, *embrace and extend* means for someone to do any of the
following:

- Releasing a modified version of this current document or any
component thereof where the original of the modified version was released
by someone else (the original typically being the official release), as
opposed to just releasing a delta document that references the current one
as a foundation.  This applies both for unofficial modifications and for
official modifications following a change of who is the official maintainer.

- Releasing a delta document for a version of this current document or
any component thereof where the referenced original is released by someone
else, and where the delta either makes significant incompatible changes.

A *version number* is an ordered sequence of 1 or more integers.  A
*version number* is used to distinguish between all of the versions of a
named entity that have a common *authority*, per each kind of versioned
entity; version numbers typically indicate the release order of these
related versions and how easily users can substitute one version for
another.  The actual intended meaning of any given *version number*
regarding for example substitutability is officially dependant on each
*authority* and no implicit assumptions should be made that 2 *version
number* with different *authority* are comparable in any meaningful way,
aside from case-by-case where a particular *authority* declares they use a
scheme compatible with another.  The only thing this document requires is that
every distinct version of an entity has a distinct fully-qualified name.

For each official/original work by Muldis Data Systems related to this
specification document and released after 2016 April 1, except where
otherwise stated, it uses *semantic versioning* for each *version number*,
as described below.  Others are encouraged to follow the same format, but
are not required to.  For all intents and purposes, every *version number*
of an official Muldis work is intended to conform to the external public
standard **Semantic Versioning 2.0.0** as published at
[https://semver.org](https://semver.org), but it is re-explained below for
clarity or in case the external document disappears.

A *version number* for authority `http://muldis.com` is an ordered sequence
of integers, the order of these being from most significant to least, with
3 positions [MAJOR,MINOR,PATCH] and further ones possible.  The version
sequence may have have as few as 1 most significant position.  Any omitted
trailing position is treated as if it were zero.  Each of
{MAJOR,MINOR,PATCH} must be a non-negative integer. MAJOR is always (except
when it is zero) incremented when a change is made which breaks
backwards-compatibility for functioning uses, such as when removing a
feature; it may optionally be incremented at other times, such as for
marketing purposes.  Otherwise, MINOR is always incremented when a change
is made that breaks forwards-compatibility for functioning uses, such as
when adding a feature; it may optionally be incremented at other times,
such as for when a large internals change is made.  Otherwise, PATCH must
be incremented when making any kind or size of change at all, as long as it
doesn't break compatibility; typically this is bug-fixes or performance
improvements or some documentation changes or any test suite changes.  For
fixes to bugs or security holes which users may have come to rely on in
conceptually functioning uses, they should be treated like API changes.
When MAJOR is zero, MINOR is incremented for any kind of breaking change.
There is no requirement that successive versions have adjacent integers,
but they must be increases.

Strictly speaking a *version number* reflects intention of the authority's
release and not necessarily its actuality.  If PATCH is incremented but the
release unknowingly had a breaking change, then once this is discovered
another release should be made which increments PATCH again and undoes that
breaking change, in order to safeguard upgrading users from surprises; an
additional release can be made which instead increments MAJOR or MINOR with
the breaking change if that change was actually desired.

*Currently this document does not specify matters such as how to indicate
maturity, for example production vs pre-production/beta/etc, so explicit
markers of such can either be omitted or be based on other standards.
However, a major version of zero should be considered either pre-production
or that the authority expects frequent upcoming backwards-incompatible changes.*

See also [http://design.perl6.org/S11.html#Versioning](
http://design.perl6.org/S11.html#Versioning) which was the primary
influence for the versioning scheme described above.

# SEE ALSO

*TODO.*

# AUTHOR

Darren Duncan - darren@DarrenDuncan.net

# LICENSE AND COPYRIGHT

This file is part of the formal specification named
**Muldis Service Protocol** (**MUSE**).

MUSE is Copyright © 2002-2019, Muldis Data Systems, Inc.

[http://www.muldis.com/](http://www.muldis.com/)

MUSE is free documentation for software;
you can redistribute it and/or modify it under the terms of the Artistic
License version 2 (AL2) as published by the Perl Foundation
([http://www.perlfoundation.org/](http://www.perlfoundation.org/)).
You should have received copies of the AL2 as part of the
MUSE distribution, in the file
[LICENSE/artistic-2_0.txt](../LICENSE/artistic-2_0.txt); if not, see
[https://www.perlfoundation.org/artistic-license-20.html](
https://www.perlfoundation.org/artistic-license-20.html).

Any versions of MUSE that you modify and distribute must carry prominent
notices stating that you changed the files and the date of any changes, in
addition to preserving this original copyright notice and other credits.

While it is by no means required, the copyright holder of MUSE would
appreciate being informed any time you create a modified version of MUSE
that you are willing to distribute, because that is a practical way of
suggesting improvements to the standard version.

# TRADEMARK POLICY

**MULDIS** and **MULDIS MULTIVERSE OF DISCOURSE** are trademarks of Muldis
Data Systems, Inc. ([http://www.muldis.com/](http://www.muldis.com/)).
The trademarks apply to computer database software and related services.
See [http://www.muldis.com/trademark_policy.html](
http://www.muldis.com/trademark_policy.html) for the full written details
of Muldis Data Systems' trademark policy.

# ACKNOWLEDGEMENTS

*None yet.*

# FORUMS

*TODO.*
