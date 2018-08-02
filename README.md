# Simple RESTful Web Service implemented with .NET 4.7, WCF and MongoDB 4.0

This is a simple RESTful web service implemented with .NET 4.7, WCF and MongoDB 4.0.
The example web service exposes a number of operations that can be used to handle hero objects stored a [MongoDB](https://www.mongodb.com/) database running locally.
The web service exposes the same operations as [dotnetcore-simple-nancy-example](https://github.com/StefanRehder/dotnetcore-simple-nancy-example) but the version in this repository can only run on Windows computers.

## Requirements

- [Microsoft Visual Studio (recommended but not required)](https://visualstudio.microsoft.com/)
- [.NET 4.7 Framework (included with Visual Studio so no need to install both)](http://go.microsoft.com/fwlink/?LinkId=528259)
- MongoDB 4.0 is required to run locally on the default port (e.g. [MongoDB Community](https://www.mongodb.com/download-center#community))

## Getting Started
Build the solution from Visual Studio and run the ConsoleApp project (or build from command line with [Microsoft Build Tools](http://www.microsoft.com/en-us/download/details.aspx?id=48159) and execute the output exe file).
When the web service is running, you can play around with the running web service with curl or Postman.
e.g. `curl -X PUT http://localhost:8210/hero -H 'content-type: application/json' -v -d '{ "Name": "Robin",  "Strength": 1 }'`