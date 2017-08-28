pushd "%windir%\system32\drivers\etc"
type hosts|find /i /v "pis-server" > hosts.new
move "%cd%\hosts.new" "%cd%\hosts"

popd
