set newip=%1

pushd "%windir%\system32\drivers\etc"
type hosts|find /i /v "pis-server" > hosts.new
move "%cd%\hosts.new" "%cd%\hosts"
echo 192.148.1.100 pis-server >>"%cd%\hosts"

popd
