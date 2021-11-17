nuget pack C.math.NET.nuspec -Properties Configuration=Release
Get-ChildItem -Filter *.nupkg | Copy-Item -Destination C:\Users\noahp\source\packages\ -Force -PassThru