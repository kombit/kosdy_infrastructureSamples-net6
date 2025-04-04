svcutil.exe ^
 wsdl\YdelseIndeks.wsdl ^
 wsdl\xsd\6.0.STS-0\*.xsd ^
 wsdl\xsd\common\*.xsd ^
 wsdl\xsd\policies\*.wsdl ^
 /noLogo /n:"*,Kombit.InfrastructureSamples.YdelseIndeksService"  /d:..\..\Kombit.InfrastructureSamples\YdelsesIndeks\ /o:YdelseIndeksService.cs
 
svcutil.exe ^
 wsdl\BevillingIndeks.wsdl ^
 wsdl\xsd\6.0.STS-0\*.xsd ^
 wsdl\xsd\common\*.xsd ^
 wsdl\xsd\policies\*.wsdl ^
 /noLogo /n:"*,Kombit.InfrastructureSamples.BevillingIndeksService"  /d:..\..\Kombit.InfrastructureSamples\BevillingIndeks\ /o:BevillingIndeksService.cs
 
 svcutil.exe ^
 wsdl\OekonomiskEffektueringIndeks.wsdl ^
 wsdl\xsd\6.0.STS-0\*.xsd ^
 wsdl\xsd\common\*.xsd ^
 wsdl\xsd\policies\*.wsdl ^
 /noLogo /n:"*,Kombit.InfrastructureSamples.OekonomiskEffektueringIndeksService"  /d:..\..\Kombit.InfrastructureSamples\OekonomiskEffektueringIndeks\ /o:OekonomiskEffektueringIndeksService.cs
