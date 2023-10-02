using TCP_Chat;

ServerSocket server = new ServerSocket("127.0.0.1", 5050);

server.BindAndListen(10);
server.AcceptAndReceive();