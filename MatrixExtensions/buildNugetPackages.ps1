rm *.nupkg
nuget pack .\MatrixExtensions.nuspec -IncludeReferencedProjects -Prop Configuration=Release
nuget pack .\MatrixExtensions.Bridge.nuspec -IncludeReferencedProjects -Prop Configuration=Release
cp *.nupkg C:\Projects\Nugets\
nuget push *.nupkg -Source https://www.nuget.org/api/v2/package