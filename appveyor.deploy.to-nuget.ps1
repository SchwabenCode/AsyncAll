# deploy script for AppVeyor CI environment for SchwabenCode.FlexMapper
Try
{
    # publish only on version tag!!!
    if($env:APPVEYOR_REPO_TAG_NAME -eq "v($env:APPVEYOR_BUILD_VERSION)")
    {
        Invoke-Expression -Command "dnu pack src\FlexMapper --configuration $env:CONFIGURATION --out $env:ARTIFACTSPATH"
        Invoke-Expression -Command "nuget push artifacts\build\$env:CONFIGURATION\FlexMapper.$env:APPVEYOR_BUILD_VERSION.nupkg -ApiKey $env:NUGETKEY -NonInteractive"
        Invoke-Expression -Command "nuget push artifacts\build\$env:CONFIGURATION\FlexMapper.$env:APPVEYOR_BUILD_VERSION.symbols.nupkg -ApiKey $env:NUGETKEY -NonInteractive"
    }
}
Catch
{
    exit -1
}