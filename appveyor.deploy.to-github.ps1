$githubPayload = @'
{
  "tag_name": "v",
  "target_commitish": "master",
  "name": "v1.0.0",
  "body": "Description of the release",
  "draft": false,
  "prerelease": false
}'@

Invoke-WebRequest -Uri "$env:githubReleaseUrl?access_token=$env:githubAuthToken" -Method POST -Body $githubPayload