# Init script for AppVeyor Environment

Try
{
	Write-Host "Patching version $env:APPVEYOR_BUILD_VERSION"
	
	# change version
	switch -wildcard ($env:APPVEYOR_REPO_BRANCH)
	{
		"master" {
			Write-Host "Branch '$env:APPVEYOR_REPO_BRANCH' found: $env:APPVEYOR_BUILD_VERSION"
			# do not touch
		}
		"release/*" {
			Write-Host "Branch '$env:APPVEYOR_REPO_BRANCH' found: $env:APPVEYOR_BUILD_VERSION"
			# do not touch
		}
		"develop" {
			Update-AppveyorBuild -Version $env:APPVEYOR_BUILD_VERSION + "-develop"
			Write-Host "Branch '$env:APPVEYOR_REPO_BRANCH' found. Add suffix '-develop': $env:APPVEYOR_BUILD_VERSION"
		}
		default{
			Update-AppveyorBuild -Version $env:APPVEYOR_BUILD_VERSION + "-develop"
			Write-Host "Unconfigured branch '$env:APPVEYOR_REPO_BRANCH' found. Add suffix '-pre': $env:APPVEYOR_BUILD_VERSION"
		}
	}
}
Catch
{
    exit -1
}