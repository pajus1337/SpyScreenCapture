import socket

def start_server(host='hostName/IP', port=6667):
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.bind((host, port))
        s.listen()
        print(f"Server listening on {host}:{port}")

        conn, addr = s.accept()
        with conn:
            print('Connected by', addr)
            data = bytearray()
            while True:
                packet = conn.recv(4096) 
                if not packet:
                    break
                data.extend(packet)

            print("Data received.")

            with open("screen_capture.png", "wb") as f:
                f.write(data)
            print("File saved.")

if __name__ == "__main__":
    start_server()