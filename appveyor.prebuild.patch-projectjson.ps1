# project.json patch script for AppVeyor Environment

param([parameter(Mandatory=$true,ValueFromRemainingArguments=$true)]
    [string[]]$patchFolderPath,
    [string] $version,
    [string] $placeHolder)
	
Try
{
    for ($i = 0; $i -lt $patchFolderPath.Length; ++$i) {
        $path = $($patchFolderPath[$i])
        
        Write-Host "PATCHING '$path' with '$placeHolder' to '$version'"
        (Get-Content $path\project.json).replace($placeHolder, $version) | Set-Content $path\project.json
    }
}
Catch
{
    exit -1
}