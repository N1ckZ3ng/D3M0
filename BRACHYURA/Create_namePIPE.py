import win32pipe
import win32file
import time

# 創建 named pipe
pipe = win32pipe.CreateNamedPipe(
    r'\\.\pipe\Clock',
    win32pipe.PIPE_ACCESS_OUTBOUND,
    win32pipe.PIPE_TYPE_MESSAGE | win32pipe.PIPE_READMODE_MESSAGE | win32pipe.PIPE_WAIT,
    1, 65536, 65536,
    0,
    None)

# 等待客戶端連接
win32pipe.ConnectNamedPipe(pipe, None)

try:
    while True:
        # 獲取當前時間
        current_time = time.strftime('%Y-%m-%d %H:%M:%S')

        # 寫入數據到 named pipe
        win32file.WriteFile(pipe, f'Current time: {current_time}\r\n'.encode())

        # 等待一秒
        time.sleep(1)

finally:
    # 關閉 pipe
    win32file.CloseHandle(pipe)

