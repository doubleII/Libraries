IPSGERLOG (V2) - in-process logger for DotNet Framework
General Information:

THIS IS A NEW IPSGERLOG VERSION (without strong name!)
IpsGerLog (V2) is available as:
- IpsGerLog.dll - for .Net-Framework 4.x

WARNING:
If one assembly changes to IpsGerLog V2, all dependent assemblies using the static logger
must use IpsGerLog V2 as well. Since only one IpsGerLog.dll can exist in a directory, all
assemblies depending on IpsGerLog in that directory must use IpsGerLog V2!
** a possible workaround for this is: install old IpsGerLog V1.x into GAC ...
** for the very rare case where coexistance is really required, contact KZE for IpsGerLogNet
   - however, this is not a "public" module - it is only provided and supported on request!

Files required (runtime):
- IpsGerLog.dll

Files delivered (runtime and development)
- IpsGerLog.dll
- doc\IpsGerLog_Description.txt
- doc\IpsGerLog_Readme.txt
- doc\IpsGerLog.chm

MAJOR CHANGES compared to legacy 1.x versions

 NEW - NO strong name!
 NEW - Added log level: Extra
 NEW - Versions >= 2.0.2005 - Obtain logfile and debug level as preset from ISM
 
 NEW - Preferred registry path (old v1.x path still supported):
       32bit: HKLM\Software\Wow6432Node\Intergraph Public Safety\IpsGerLog\Defaults
       64bit: HKLM\Software\Intergraph Public Safety\IpsGerLog\Defaults
                                               
 New - Added common log line prefix configuration

 ** Only for GerLogger instances:
 New - Added LogWrite function for raw logging - no prefix, optionally no newline (retval = 0)
 New - Added LogMessage function for special logging purposes (retval = 0)
 New - Added LogClose function for special purposes (retval = 0)
 New - Added LogConfig function for special purposes (retval = x 0=Success,1=Invalid,2=Error)

Always see "Version History" for more details on changes, fixes and new features

Product:                    IpsGerLog (V2)
CAD Version:                n/a
Assembly Version:           2.0.0.0
Current File Version:       2.0.2010.8
Product Version:            2.0.0 DotNet 4.x

============
Known Issues
============
General: see doc/IpsGerLog_Description.txt

=====================================================
Version History (File version unless otherwise noted)
=====================================================

2.0.2010.8 - Corrected internal GerLogError log file name
             Info: Only used if IpsGerLog cannot be instantiated (invalid app.config file)

2.0.2005.7 - V2 RESTORED AssemblyVersion
             AssemblyVersion 2.0.0.0
             ** Will not be changed for functional enhancements!

--- Deprecated due to 'bad' assembly version ---
2.0.2004.6 - V2 only doc corrections

2.0.2004.5 - V2 build with ISM configuration
    ***      AssemblyVersion 2.0.1.0
-------------------------------------------------

2.0.2003.4 - V2 build (removed support for clr2.0)
             AssemblyVersion 2.0.0.0

2.0.2003.3 - V2 preliminary build
    Fix - Internal prefix mode processing
    Mod - Filename suffix generation for GerLogger instances:
          InstanceNum is now only used for fallbacks (now having 2 fallback levels)
    New - Added Log* functions for special purposes (provide retval - default 0)

2.0.2003.2 - Initial V2 release build

 
=============
Configuration
=============

IpsGerLog does not need configuration by default.
However, it is recommended that applications configure IpsGerLog before starting to log.

Optional: IpsGerLog supports configuration using the module specific configuration file
   Name: <ModuleName.exe>.config
   
 WARNING: xml config files are in UTF-8 format by default.

 Sample settings header (paste into <configSections> of config file):
   
  <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
      <section name="Intergraph.IPS.Germany.Logging.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  </sectionGroup>

 Sample settings data (paste into config file, modify Values to your needs):
 - configure a new default log path: D:\Logs
 - Configure a maximum log file size: 256 MB

   <applicationSettings> 
       <Intergraph.IPS.Germany.Logging.Properties.Settings>
          <setting name="LogPath" serializeAs="String">
             <value>D:\Logs</value>
          </setting>
          <setting name="MaxFileSize_MB" serializeAs="String">
             <value>256</value>
          </setting>
       </Intergraph.IPS.Germany.Logging.Properties.Settings>
   </applicationSettings>
   
   See doc\IpsGerLog_Description for details.
   Use doc\IpsGerLog.dll.config as sample for settings.
   Note: Only non default settings are required and should appear in the config file

=============
The End
=============
