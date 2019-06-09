dotnet msbuild -property:version=1.0.0-preview-%Version% -target:publish src\Aguacongas.FootballChampionship
dotnet msbuild -property:version=1.0.0-preview-%Version% -target:pack src\Aguacongas.AwsServices
dotnet msbuild -property:version=1.0.0-preview-%Version% -target:pack src\Aguacongas.AwsComponents
xcopy /E /Y src\Aguacongas.FootballChampionship\bin\Release\netstandard2.0\publish\Aguacongas.FootballChampionship\dist\css docs\css
xcopy /E /Y src\Aguacongas.FootballChampionship\bin\Release\netstandard2.0\publish\Aguacongas.FootballChampionship\dist\_framework docs\_framework
xcopy /E /Y src\Aguacongas.FootballChampionship\bin\Release\netstandard2.0\publish\Aguacongas.FootballChampionship\dist\_content docs\_content