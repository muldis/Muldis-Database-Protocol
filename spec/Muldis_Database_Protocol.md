# NAME

Muldis Database Protocol (MDBP) -
Abstract library API for database engines

# VERSION

The fully-qualified name of this document is
`Muldis_Database_Protocol http://muldis.com 0.201.0`.

# SYNOPSIS

*TODO.*

# DESCRIPTION

This document is the human readable authoritative formal specification named
**Muldis Database Protocol** (**MDBP**).
The fully-qualified name of this document and specification is
`Muldis_Database_Protocol http://muldis.com 0.201.0`.
This is the official/original version by the authority Muldis Data Systems
(`http://muldis.com`), version number `0.201.0`.

**Muldis Database Protocol** specifies an abstract library API for database
engines.  It is completely language independent but uses conventions that
are familiar to programmers of many other languages.  It often takes the
form of API documentation for a pseudocode virtual library named **FooDB**.

An actual concrete library in some programming language that implements and
is fully conformant to the MDBP specification is one that provides an API
that is a (possibly non-proper) superset of the API of the virtual library
defined here.  And so, any applications or other libraries depending on the
MDBP should be fully portable between all such conforming libraries of
their own programming language or platform, at least with respect to what
the API spec defines; furthermore, dependents should be able to
programmatically discover to what degree the entire feature set and API of
the implementing library is able to satisfy its needs and gracefully handle
when they aren't met.

**Muldis Database Protocol** is expressly designed so that multiple
implementing DBMS engines etc can be drop-in compatible for each other
while at the same time having no library dependencies in common.  This is
in stark contrast to typical cross-DBMS access solutions which require a
common shared implementing codebase, extensible with a plug-in
architecture, regardless of what backend is in use.  Shared-nothing is a
primary MDBP feature, at least in principle; implementations can choose to
have shared code, but MDBP makes no requirements that they do so.

**Muldis Database Protocol** is bundled with a set of reference API
specifications such that each of the latter is specific to an externally
defined programming language and demonstrates how to apply the abstract
MDBP to the particular paradigms/features/idioms of that language. Where
the language supports the concept, which is common, the reference API is an
actual concrete interface-defining source code file which can be included
in or be a concrete dependency for a MDBP implementation in that language.

See the language-specific subdirectories of [hosts](../hosts) for those.

# DEPENDENCIES

**Muldis Database Protocol** has formal dependencies on, and is defined
partly in terms of, the externally defined formal specifications named
**Muldis Content Predicate** (**MCP**) and
**Muldis Object Notation** (**MUON**).

See [https://github.com/muldis/Muldis_Content_Predicate](
https://github.com/muldis/Muldis_Content_Predicate)
and [https://github.com/muldis/Muldis_Object_Notation](
https://github.com/muldis/Muldis_Object_Notation) for those.

The MDBP specification liberally re-uses concepts and definitions from
those externals, so they should be read and understood as necessary in order
to best understand the current document.

# INTERFACE

This document uses some object-oriented terminology such as I<class> and
I<object> to describe the abstract API, but an object-oriented language is
not required to implement it.  Conversely, this document describes routines
such that all arguments are explicit, and none are described as object
instance methods, but an OO language is free to use such if it wants to.

The interface of **FooDB** primarily uses the *abstract factory* and
*factory method* design patterns; users are expected in general to not need
to know the actual implementing classes of the objects they create or are
given, just that the objects provide expected interfaces and behavior.

Otherwise, **FooDB** most frequently uses the *command* or *interpreter*
design patterns; the API has a fairly small number of actual routines, such
that users invoke them with structures (either native or serialized) that
describe a desired action to take, and receive back structures describing
the results.

**Muldis Database Protocol** is generally agnostic to command languages and
data models and is designed to be usable with many different ones.

This document uses *snake case*, for example `Foo_Bar`, as its generic
naming convention for the API components; however, each implementation does
not need to follow this, and indeed the bundled language-specific reference
API specifications will instead follow the standard naming conventions of
those languages.

This document gives the `MDBP_` prefix for type/class names that are
defined by the API, and gives the `SYS_` prefix for type/class names that
are defined by the host/implementing programming language, so that they are
not confused; actual implementations should use non-conflicting names also.

## MDBP_Factory

A concrete library in some programming language that implements MDBP will
have exactly one static factory class, whose name the user needs to know,
which is the initial factory class to bootstrap the API.  That factory
class is represented in this document by the fake class name `MDBP_Factory`.
An application using a MDBP-implementing library might either hard-code
this class name if it is only using a specific one, or it might load that
name from a configuration file if it lets users specify the library to use.

## MDBP_Factory::Provides_Muldis_Database_Protocol

```
    procedure MDBP_Factory::Provides_Muldis_Database_Protocol()
```

The static procedure `MDBP_Factory::Provides_Muldis_Database_Protocol`
exists entirely to serve as a "magic number" that identifies the library as
one that implements the **Muldis Database Protocol**.  An application which
takes instruction from the user or a config file on which MDBP-implementing
library to use can do appropriate sanity checks elegantly with the host
language's reflection capabilities, checking for the existence of the
requested factory class and that said class provides this niladic
procedure, and only proceeding further to try and use the factory if it
does.  Actually invoking this procedure should be a no-op.

*TODO.*

# VERSIONING

Every version of this specification document is expected to declare its own
fully-qualified name, or *identity*, so that it can easily be referred to
and be distinguished from every other version that does or might exist.

The expected fully-qualified name of every version of this specification
document, as either declared in said document or as referenced by other
documents or by source code, has 3 main parts: *document base name*,
*authority*, and *version number*.

The *document base name* is the character string `Muldis_Database_Protocol`.

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
**Muldis Database Protocol** (**MDBP**).

MDBP is Copyright © 2002-2017, Muldis Data Systems, Inc.

[http://www.muldis.com/](http://www.muldis.com/)

MDBP is free documentation for software;
you can redistribute it and/or modify it under the terms of the Artistic
License version 2 (AL2) as published by the Perl Foundation
([http://www.perlfoundation.org/](http://www.perlfoundation.org/)).
You should have received copies of the AL2 as part of the
MDBP distribution, in the file
[LICENSE/artistic-2_0.txt](../LICENSE/artistic-2_0.txt); if not, see
[http://www.perlfoundation.org/attachment/legal/artistic-2_0.txt](
http://www.perlfoundation.org/attachment/legal/artistic-2_0.txt).

Any versions of MDBP that you modify and distribute must carry prominent
notices stating that you changed the files and the date of any changes, in
addition to preserving this original copyright notice and other credits.

While it is by no means required, the copyright holder of MDBP would
appreciate being informed any time you create a modified version of Muldis
D that you are willing to distribute, because that is a practical way of
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
