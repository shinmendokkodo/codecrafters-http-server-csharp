using System.Net;
using System.Net.Sockets;
using System.Text;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

// Uncomment this block to pass the first stage
TcpListener server = new(IPAddress.Any, 4221);
server.Start();

var socket = await server.AcceptSocketAsync(); // wait for client
Console.WriteLine("Client connected");

string response = "HTTP/1.1 200 OK\r\n\r\n";
byte[] sendBytes = Encoding.ASCII.GetBytes(response);

var bytesRead = await socket.SendAsync(sendBytes, SocketFlags.None);
Console.WriteLine($"Received {bytesRead} bytes");

socket.Close();