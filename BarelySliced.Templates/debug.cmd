del ".\bin\Debug\*.*" /q
dotnet pack
dotnet new uninstall BarelySliced
dotnet new install ".\bin\Debug\BarelySliced.1.0.0.nupkg"
dotnet new search BarelySliced
dotnet new bsfeature -n Test --force -o "H:\boriscallens\Projectsetup\BarelyBoris.SolutionTemplate\BarelyBoris.SolutionTemplate.Business\Features\Test"