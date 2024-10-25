using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public class HttpServer
{
    private HttpListener _listener;
    private const string UrlPrefix = "http://+:5001/";

    public void Start()
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add(UrlPrefix);  // Allow connections on all interfaces (LAN)
        _listener.Start();
        Console.WriteLine("Listening for HTTP requests...");

        // Start listening for incoming requests
        Task.Run(() => Listen());
    }

    private async Task Listen()
    {
        while (true)
        {
            var context = await _listener.GetContextAsync();  // Wait for a request
            var request = context.Request;
            var response = context.Response;

            Console.WriteLine($"Received request: {request.HttpMethod} {request.Url}");

            // Send a response
            var responseString = "Hello from WinForms!";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }
    }

    public void Stop()
    {
        _listener.Stop();
    }
}
