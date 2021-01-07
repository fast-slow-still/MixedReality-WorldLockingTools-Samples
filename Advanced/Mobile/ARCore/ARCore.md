# Direct to ARCore

## Summary:

This sample codes directly to Google's ARCore SDK for Unity.

## Dependencies:
* Built on WLT version 1.2.2.
* Incompatible with MRTK
* Built on Unity v2019.4.15f.
* Built on ARCore Unity SDK v1.22.0.
* Uses Frozen World Engine DLL v1.0.0 or later.

## Additional setup:

The instructions here are trying to be brief. If anything is unclear, please refer to the full documentation for details.

### Install Frozen World

Install the Frozen World Engine DLL, as described in the [WLT Initial Setup documentation](https://microsoft.github.io/MixedReality-WorldLockingTools-Unity/DocGen/Documentation/HowTos/InitialSetup.html#frozenworld-engine-installation).

### ARCore and its dependencies

Building the sample requires installing Google's ARCore Unity SDK v1.22.0 or later, including dependencies.

These notes are intended to be helpful in setting up ARCore Unity SDK, but are no substitute for the official full documentation, which can be found at the following:

> https://developers.google.com/ar/develop/unity/quickstart-android

### Installing ARCore dependencies

From Unity Package Manager, install:

* Multiplayer HLAPI
* XR Legacy Input Helpers

### Installing ARCore Unity SDK

Download the ARCore Unity SDK unity package from [github](https://github.com/google-ar/arcore-unity-sdk/releases).

Import the .unitypackage into the Unity project. The examples may be imported or not, on your preference.

> [!NOTE]
> ARCore as packaged is not in an assembly specialization. That is, it compiles into the predefined Assembly-CSharp.dll. Unfortunately, [from the Unity documentation](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html):
>> Classes in assemblies created with an Assembly Definition cannot use types defined in the predefined assemblies.
>
> Therefore, in order for WLT to access and manage ARCore, ARCore must be moved into an Assembly Definition.
> This next step achieves that, by simply unpacking appropriate assembly definition (.asmdef) files onto the ARCore assets imported in the previous step.
> IMPORTANT: If the folder structure of the GoogleARCore assets is to be changed or renamed, first perform the following step.
 
Import arcore-1.22.0-asmdef-fixup.unitypackage into your project. This unity package can be found in the Misc folder of this sample. It contains only assembly definition (.asmdef) files.

* Once the ARCore unitypackage and the fixup unitypackage have been imported, you may safely rename or move the GoogleARCore folder to match your organization.

Ensure your build target is Android.

In your project's **Player Settings**, in the **XR** section at the end, ensure that "ARCore Supported" is enabled.

> [!NOTE] 
> If you hit a build error about manifest-merger failed, then follow the appropriate instructions here: https://developers.google.com/ar/develop/unity/android-11-build

## Adding WLT ARCore support to an existing project

In addition to installing ARCore Unity SDK as described above, and of course installing WLT as described [here](), there are two additional steps in order to get WLT to target the ARCore SDK directly.

First, the additional define of `WLT_ARCORE_SDK_INCLUDED` must be added to your project in `Player Settings => Other Settings` under the Android tab. 

<img src="~/DocGen/Images/ARCore/ARCoreDefine.PNG">

Next, in the `World Locking Context` in the `World Locking Manager` prefab within your scene, in the `Anchor Management` settings, change the `Anchor Subsystem` to `AR Core`, as shown below. Note that you will need to uncheck the `Use Defaults` checkbox in order to change the subsystem type.

<img src="~/DocGen/Images/ARCore/ARCoreSubsystem.PNG">

## Running the samples:

Several sample scenes may be found in Assets/ARCoreSample/Scenes

### ARCoreWLT.unity

This sample is the most elemental, the simplest possible application running WLT on top of ARCore. It does nothing but load a couple of cubes, which will remain fixed in physical space (contingent on tracking). 

#### Special controls:

The sample includes the anchor graph visualization enabled. To disable WLT's anchor graph visualization, and get the truly simplest WLT on ARCore application possible, delete or disable the AnchorGraphVisual attached to the scene's WorldLocking object.

### Placement.unity

This sample includes visualization of the found environment planes. 

#### Special controls:

Tap the screen to place a coordinate frame representation where a ray cast intersects the environment's planes.
