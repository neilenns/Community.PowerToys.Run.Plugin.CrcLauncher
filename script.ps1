$xmlFilePath = './src/Community.PowerToys.Run.Plugin.CrcLauncher.csproj'
$xmlPathsInput = '/Project/PropertyGroup/TargetFramework'
  
# Parse the XML paths input into an array
$paths = $xmlPathsInput -split "`n"
  
# Load the XML file
$xml = [xml](Get-Content -Path $xmlFilePath)
  
# Iterate through paths and extract values
foreach ($path in $paths) {
	$trimmedPath = $path.Trim()
	if (-not $trimmedPath) { continue } # Skip empty lines
  
	# Use the last segment of the XPath as the environment variable name
	$envVar = $trimmedPath.Split('/')[-1]
	$value = ($xml.SelectNodes($trimmedPath) | ForEach-Object { $_.InnerText }) -join ','
  
	Write-Output "$envVar=$value" | Out-File -Append -FilePath $env:GITHUB_ENV
}