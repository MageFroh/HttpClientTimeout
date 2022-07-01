This repository contains a reproducer for a particular .NET 6 HttpClient behaviour.

The Web application can be run natively, or in Docker.
In both cases, it exposes an HTTP API on port 5243 and HTTPS on port 7243.

The ConsoleApplication uses the HTTPS port on localhost to send a request that exceeds
ASP.NET Core default max body size. It then prints the status code and response body.
