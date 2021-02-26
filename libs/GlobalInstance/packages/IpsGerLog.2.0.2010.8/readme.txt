THIS IS THE NEW IPSGERLOG V2 VERSION
IpsGerLog.dll - for .Net-Framework 4.x

MAJOR CHANGES compared to legacy 1.x versions:
- NO strong name

- New log level "Extra":  This is the new highest debug level
- New option to control log line prefix
- New methods for special logging purposes
- Versions >= 2.0.2005:
  Read ISM parameters logfile (path,name,ext) debug level (from cmdline)

WARNING:
If a module changes to IpsGerLog V2, all dependent assemblies using the static logger
must also use IpsGerLog V2. Note that one version of IpsGerLog can exist in one directory.
So all assemblies depending on IpsGerLog in a directory must use IpsGerLog V2!
** only possible workaround for this is: install IpsGerLog V1.x into GAC ...
** if this is an issue - contact Development for assistance

Product:                    IpsGerLog (V2)
Assembly Version:           2.0.0.0
File Version:               2.*
Product Version:            2.0.0 (.Net4)

For more information see:
.../doc/IpsGerLog_Readme.txt
.../doc/IpsGerLog_Description.txt
.../doc/IpsGerLog.chm

