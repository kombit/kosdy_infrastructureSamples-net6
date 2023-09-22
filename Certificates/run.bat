@echo off
setlocal EnableExtensions EnableDelayedExpansion

echo Installing certificates for Secure Token Service
certutil -addstore -user -f Root "Secure Token Service\CA_root.cer"
certutil -addstore -user -f My "Secure Token Service\externtest-adgangsstyring-truststore.crt"
echo =================================================

echo Installing certificates for SagDokIndeks
certutil -addstore -user -f My "SagDokIndeks\SDI_EXTTEST_Sags-og-Dokindeks_1.crt"

echo Installing certificates for Organisation
certutil -addstore -user -f My "Organisation\ORG_EXTTEST_Organisation_1.crt"

echo Installing certificates for Klassifikation
certutil -addstore -user -f My "Klassifikation\KLA_EXTTEST_Klassifikation_1.crt"

:exit
