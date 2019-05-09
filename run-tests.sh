# Run the tests and collate code coverage results
dotnet test -c Release --no-build --no-restore MoneyType.Tests/MoneyType.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover