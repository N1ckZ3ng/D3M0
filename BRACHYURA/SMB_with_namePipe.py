from smb.SMBConnection import SMBConnection

# 設定用於連接的參數
remote_host = "192.168.1.100"  # 遠端主機IP地址
username = "your_username"  # SMB用戶名
password = "your_password"  # SMB密碼
my_name = "local_machine_name"  # 本地機器名稱
remote_name = "remote_machine_name"  # 遠端機器名稱
domain_name = "WORKGROUP"  # 通常是WORKGROUP或者網域名稱

# 建立連接
conn = SMBConnection(username, password, my_name, remote_name, domain=domain_name, use_ntlm_v2=True)

# 連接至遠端主機
assert conn.connect(remote_host, 445)  # 445是SMB協議的預設端口

# 列出遠端主機的共享資源
shares = conn.listShares()
for share in shares:
    print("Share Name:", share.name)

# 列出遠端主機上某個共享資源中的所有項目（包括Pipe名稱，如果存在的話）
share_name = "Your_Share_Name"
files = conn.listPath(share_name, "/")
for file_info in files:
    print("File:", file_info.filename)

