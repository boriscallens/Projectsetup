Remove-Item -Path ".\bin\Debug\*" -Recurse -Force
Remove-Item -Path "$env:USERPROFILE\.templateengine" -Recurse -Force

dotnet pack
dotnet new uninstall BarelySliced
dotnet new install ".\bin\Debug\BarelySliced.1.0.0.nupkg" -d > .\debug.log
dotnet new list --tag BarelySliced
dotnet new bsfeature -n Example --force -o "H:\Projectsetup\BarelyBoris.SolutionTemplate\BarelyBoris.SolutionTemplate.Business\"