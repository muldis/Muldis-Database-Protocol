# NAME

Muldis Database Protocol: .NET -
Reference API for Muldis Database Protocol Over .NET

# VERSION

The fully-qualified name of this document is
`Muldis_Database_Protocol_DotNet http://muldis.com 0.300.0`.

# SYNOPSIS

*TODO.*

# DESCRIPTION

This is a bundled supporting document for the feature specification named
**Muldis Database Protocol** (**MDBP**) whose fully-qualified name is
`Muldis_Database_Protocol http://muldis.com 0.300.0`.

See the file
[spec/Muldis_Database_Protocol.md](../../spec/Muldis_Database_Protocol.md)
for that feature document.

**Muldis Database Protocol: .NET** is a reference API specification that
specializes the more abstract **Muldis Database Protocol** specification
for Microsoft's .NET platform.  It is essentially the same but uses
standard .NET/C\# features and idioms and syntax instead of pseudocode.

Since the idiomatic way for two participants to communicate with MDBP
involves them being at arms length and having zero shared depencency code
and not even knowing each others' names at compile time, the actual
mechanics of communication generally requires runtime binding using
reflection and/or introspection.  Zero shared dependency code means not
having a common "interface" library to bind to at compile time either.

To help make using MDBP easier, the two bundled .NET/C\# library files
[MuldisDatabaseProtocolServer.cs](MuldisDatabaseProtocolServer.cs) and
[MuldisDatabaseProtocolClient.cs](MuldisDatabaseProtocolClient.cs) are
templates that may be copied into a MDBP implementing library or a user
application, respectively.  Each copy of the template would then need to be
renamed from `Muldis.Example.*` into the namespace of the target and then
otherwise be modified to fit as necessary.  In particular, the "client"
template should take care of most of the runtime introspection and binding
logic for you so your application can use it as a shim for any protocol
speaking library that you can bind to at compile time.

# INTERFACE

The interface of MDBP is entirely object-oriented; you use it by creating
objects from its member classes and then invoking methods on those objects.
All of their attributes are private, so you must use accessor methods.

*TODO.*

# AUTHOR

Darren Duncan - darren@DarrenDuncan.net

# LICENSE AND COPYRIGHT

This file is part of the formal specification named
**Muldis Database Protocol** (**MDBP**).

MDBP is Copyright © 2002-2019, Muldis Data Systems, Inc.

See the LICENSE AND COPYRIGHT of
[spec/Muldis_Database_Protocol.md](../../spec/Muldis_Database_Protocol.md)
for details.
