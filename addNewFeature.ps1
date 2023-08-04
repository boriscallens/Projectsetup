param (
    [string]$featureName = $(Read-Host "Please provide a feature name"),
    [switch]$force
)

if (!$featureName) {
    Write-Error "No feature name provided. Please provide a feature name."
    return
}

$slnFile = Get-ChildItem -Path $PWD -Filter *.sln -File -ErrorAction SilentlyContinue
if (!$slnFile) {
    Write-Error "No solution file found in the current directory. Please run this script from the root of the solution."
    return
}

$businessPath = Get-ChildItem -Path $PWD -Filter *.business.csproj -Recurse -ErrorAction SilentlyContinue | Select-Object -ExpandProperty DirectoryName
if (!$businessPath) {
    Write-Error "No business project found in the current directory."
    return
}

$businessTestPath = Get-ChildItem -Path $PWD -Filter *.business.tests.csproj -Recurse -ErrorAction SilentlyContinue | Select-Object -ExpandProperty DirectoryName
if (!$businessTestPath) {
    Write-Error "No business tests project found in the current directory."
    return
}

if ($force) {
    Write-Host "Forcing creation of feature $featureName" -ForegroundColor Yellow
    dotnet new bsfeature -n $featureName -o $businessPath --force
    dotnet new bsfeatureTests -n $featureName -o $businessTestPath --force
} elseif (Test-Path "$businessPath\$featureName") {
    Write-Error "Feature $featureName already exists. Use the -Force flag to create anyway."
} elseif (Test-Path "$businessTestPath\$featureName") {
    Write-Error "Feature Tests $featureName already exist. Use the -Force flag to create anyway."
} else {
    dotnet new bsfeature -n $featureName -o $businessPath
    dotnet new bsfeatureTests -n $featureName -o $businessTestPath
}