# Tutorial https://www.youtube.com/watch?v=eSN_41n0QDw&ab_channel=TechSnips
# https://adamtheautomator.com/openssl-windows-10/
# Install Chocolatey if needed, see https://chocolatey.org/install

choco install openSSL.Light -y

# region customize your environment ...

### Create a PowerShell profile if you don't  have one already
### your profile script runs everytime you launch PowerShell and is customizable.

# Create a directory  dedicated to managing cerificates
New-Item -ItemType Directory -Path C:\certs

# Download example config file
Invoke-WebRequest 'http://web.mit.edu/crypto/openssl.cnf' -OutFile c:\certs\openssl.cnf

# Edit config file as desired, see https://www.openssl.org/docs/manmaster/man5/config.html
# Change / to \ in the CA_default section if performing Certificate Authority tasks
ise C:\certs\openssl.cnf # open file

# Create Directory: C:\Users\iivanov\Documents\WindowsPowerShell
if (-not (test-path $profile)){
    New-Item -Path $profile -Type File -Force
}

# change the policy on the computer
Set-ExecutionPolicy RemoteSigned
Set-ExecutionPolicy Restricted # Defaul for all windows


# Edit profile to add these lines
'$env:path = "$env:path;C:\Program Files\OpenSSL\bin"' | Out-File $profile -Append
'$env:OPENSSL_CONF = "C:\certs\openssl.cnf"' | Out-File $profile -Append

ise $profile

# re-open your PowerShell terminal or manually run your profile script
. $profile

# Open SSL path
$env:path
# Open SLL Config
$env:OPENSSL_CONF

# region Running OpenSLL ...
# confirm OpenSSL  works
openssl version

# interactivite commands are not supported in ISE, use Ctrl+C to escape
OpenSSL req -new -out first.csr

# if you want to automate the process
$openSSlArgs = "req -new out first.csr"
Start-Process openssl $openSSlArgs
# endregion Running OpenSSL

# https://man.openbsd.org/openssl.1

# X.509 V3 format
# openssl req -newkey rsa:2048 -new -nodes -x509 -days 365 -keyout ca-key.pem -out ca-cert.pem -extensions v3_req