from impacket import smb
from impacket.smbconnection import SMBConnection
import win32pipe
import win32file

RHost = '1.1.1.1'
user='username'
passwd='userpasswd'

conn = SMBConnection(RHost,RHost )
conn.login(user,passwd)
conn.connectTree('IPC$')

handle = win32file.CreateFile('\\\\1.1.1.1\pipe\Clock',win32file.GENERIC_READ,0,None,win32file.OPEN_EXISTING,0,None)

try: 
    while True:
        hr , data=win32file.ReadFile(handle,64*1024)

        if hr ==0:
            print(data.decode().strip())
except KeyboardInterrupt:
    pass

finally:
    win32file.CloseHandle(handle)
