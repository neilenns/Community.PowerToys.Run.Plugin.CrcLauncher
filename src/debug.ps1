﻿# this script uses [gsudo](https://github.com/gerardog/gsudo)

Push-Location
Set-Location $PSScriptRoot

sudo {
	Start-Job { Stop-Process -Name PowerToys* } | Wait-Job > $null

	# change this to your PowerToys installation path
	$ptPath = "$env:LOCALAPPDATA\PowerToys"
	$debug = '.\bin\x64\Debug\net8.0-windows10.0.22621.0'
	$dest = "$env:LOCALAPPDATA\Microsoft\PowerToys\PowerToys Run\Plugins\CrcLauncher"
	$files = @(
		"Community.PowerToys.Run.Plugin.CrcLauncher.deps.json",
		"Community.PowerToys.Run.Plugin.CrcLauncher.dll",
		'plugin.json',
		'Images'
	)

	Set-Location $debug
	mkdir $dest -Force -ErrorAction Ignore | Out-Null
	Copy-Item $files $dest -Force -Recurse

	& "$ptPath\PowerToys.exe"
}

Pop-Location