dotnet msbuild -property:version=1.0.0-preview-%Version%;configuration=Release -target:publish src\Aguacongas.FootballChampionship\Aguacongas.FootballChampionship.csproj
dotnet msbuild -property:version=1.0.0-preview-%Version%;configuration=Release -target:pack src\Aguacongas.AwsServices\Aguacongas.AwsServices.csproj
dotnet msbuild -property:version=1.0.0-preview-%Version%;configuration=Release -target:pack src\Aguacongas.AwsComponents\Aguacongas.AwsComponents.csproj

xcopy /E /Y src\Aguacongas.FootballChampionship\bin\Release\netstandard2.0\publish\Aguacongas.FootballChampionship\dist\css docs\css
xcopy /E /Y src\Aguacongas.FootballChampionship\bin\Release\netstandard2.0\publish\Aguacongas.FootballChampionship\dist\_framework docs\_framework
xcopy /E /Y src\Aguacongas.FootballChampionship\bin\Release\netstandard2.0\publish\wwwroot\_content docs\_content