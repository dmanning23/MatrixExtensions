nuget pack .\MatrixExtensions.nuspec -IncludeReferencedProjects -Prop Configuration=Release
nuget push *.nupkg