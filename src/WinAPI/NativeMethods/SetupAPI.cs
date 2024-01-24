// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Larin.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the SetupAPI.dll Windows API library
/// </summary>
[SupportedOSPlatform("WINDOWS")]
public static class SetupAPI
{
	private const string _setupApiLib = "SetupAPI.dll";

	/// <summary>
	/// Returns a handle to a device information set that contains requested device information elements for a local computer.
	/// </summary>
	/// <param name="ClassGuid">A pointer to the GUID for a device setup class or a device interface class. This pointer is optional and can be NULL.</param>
	/// <param name="Enumerator">A pointer to a NULL-terminated string that specifies:
	/// An identifier(ID) of a Plug and Play(PnP) enumerator.This ID can either be the value's globally unique identifier (GUID) or symbolic name. For example, "PCI" can be used to specify the PCI PnP value. Other examples of symbolic names for PnP values include "USB," "PCMCIA," and "SCSI".
	/// A PnP device instance ID.When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter.
	/// This pointer is optional and can be NULL.If an enumeration value is not used to select devices, set Enumerator to NULL</param>
	/// <param name="hwndParent">A handle to the top-level window to be used for a user interface that is associated with installing a device instance in the device information set. This handle is optional and can be NULL.</param>
	/// <param name="Flags">A variable of type DWORD that specifies control options that filter the device information elements that are added to the device information set.</param>
	/// <returns>If the operation succeeds, SetupDiGetClassDevs returns a handle to a device information set that contains all installed devices that matched the supplied parameters. If the operation fails, the function returns INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevsw</remarks>
	[DllImport(_setupApiLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint SetupDiGetClassDevsW(
		[In] nint ClassGuid,
		[In] nint Enumerator,
		[In] nint hwndParent,
		[In] uint Flags
	);

	/// <summary>
	/// The GUID_DEVINTERFACE_DISK device interface class is defined for hard disk storage devices.
	/// </summary>
	public static readonly Guid GUID_DEVINTERFACE_DISK = new("53f56307-b6bf-11d0-94f2-00a0c91efb8b");

	/// <summary>
	/// Return a list of installed devices for all device setup classes or all device interface classes.
	/// </summary>
	public const uint DIGCF_ALLCLASSES = 0x00000004;

	/// <summary>
	/// Return devices that support device interfaces for the specified device interface classes. This flag must be set in the Flags parameter if the Enumerator parameter specifies a device instance ID.
	/// </summary>
	public const uint DIGCF_DEVICEINTERFACE = 0x00000010;

	/// <summary>
	/// Return only the device that is associated with the system default device interface, if one is set, for the specified device interface classes.
	/// </summary>
	public const uint DIGCF_DEFAULT = 0x00000001;

	/// <summary>
	/// Return only devices that are currently present in a system.
	/// </summary>
	public const uint DIGCF_PRESENT = 0x00000002;

	/// <summary>
	/// Return only devices that are a part of the current hardware profile.
	/// </summary>
	public const uint DIGCF_PROFILE = 0x00000008;
}
