using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("RAF Client")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("IFAR")]
[assembly: AssemblyProduct("RAF Client")]
[assembly: AssemblyCopyright("Copyright © 2007 IFAR")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("cbcf24ed-20c7-48eb-ad62-73981ba3e9d7")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

/*
Major:
	Assemblies with the same name but
	different major versions are not
	interchangeable. A higher version
	number might indicate a major
	rewrite of a product where
	backward compatibility cannot be
	assumed.
Minor:
	If the name and major version
	number on two assemblies are the
	same, but the minor version number
	is different, this indicates
	significant enhancement with the
	intention of backward
	compatibility. This higher minor
	version number might indicate a
	point release of a product or a
	fully backward-compatible new
	version of a product.
Build:
	A difference in build number
	represents a recompilation of the
	same source. Different build
	numbers might be used when the
	processor, platform, or compiler
	changes.
Revision:
	Assemblies with the same name,
	major, and minor version numbers
	but different revisions are
	intended to be fully
	interchangeable. A higher revision
	number might be used in a build
	that fixes a security hole in a
	previously released assembly.
 
*/



[assembly: AssemblyVersion("1.1.0.0")]
[assembly: AssemblyFileVersion("1.1.0.0")]


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log.config",Watch = true)]
