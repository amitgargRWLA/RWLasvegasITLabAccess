dotnet add reference ../ITLabAccess.Core/ITLabAccess.Core.csproj
dotnet add reference ../ITLabAccess.Data/ITLabAccess.Data.csproj
dotnet add reference ../ITLabAccess.Service/ITLabAccess.Service.csproj

cls


dotnet add project ../ITLabAccess.Core/ITLabAccess.Core.csproj
dotnet add project ../ITLabAccess.Data/ITLabAccess.Data.csproj
dotnet add project ../ITLabAccess.Service/ITLabAccess.Service.csproj

dotnet ef migrations add test
dotnet ef database update

dotnet ef --startup-project ../RWLasvegasITLabAccess/RWLasvegasITLabAccess/ migrations add Initial