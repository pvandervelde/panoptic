//-----------------------------------------------------------------------
// <copyright company="Panoptic">
//     Copyright 2013 Panoptic. Licensed under the Apache License, Version 2.0.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Panoptic.Areas.Ops")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyProduct("Panoptic.Areas.Ops")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9015af9b-d46b-40d0-9040-07aa77dd8bee")]

[assembly: WebActivatorEx.PostApplicationStartMethod(
    typeof(Panoptic.UI.Web.Areas.Ops.App_Start.RazorGeneratorMvcStart), 
    nameof(Panoptic.UI.Web.Areas.Ops.App_Start.RazorGeneratorMvcStart.Start))]
