@echo off
del *.nupkg
@echo on
".nuget/nuget.exe" pack EvoHome.Signed.nuspec -symbols

".nuget/nuget.exe" push LVMS.EvoHome*.Signed.*.nupkg

pause