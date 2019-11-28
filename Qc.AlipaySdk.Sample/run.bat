taskkill /F /T /FI "WINDOWTITLE eq Qc.AlipaySdk.Sample" /IM dotnet.exe
start "Qc.AlipaySdk.Sample" dotnet run
exit