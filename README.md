# Freebitcoin Claimer

Automatic claimer for Freebitco.in.

Running Freebitcoin Claimer requires the .NET 6. If you do not have it, you can download it [from Microsoft's website](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0).

# Configuration
You can configure Freebitcoin Claimer through the `Settings.json` file in the Config directory or in the interface after login.

* **ClaimDelay** (*default: 30*) How long to wait (in seconds) before trying to claim.
* **CheckForUpdates** (*default: true*) Whether to automatically check for updates on startup or not.
* **LogToFile** (*default: true*) Whether to log to file or not.
* **LogLevel** (*default: "Information"*) How much stuff to log. Valid options are, in decreasing order of spamminess: `Verbose`, `Debug`, `Information`, `Warning`, `Error`, `Fatal`.

# Acknowledgements
Freebitcoin Claimer uses the following 3<sup>rd</sup> party libraries:
* [Json.NET](https://github.com/JamesNK/Newtonsoft.Json) &ndash; [MIT License](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md)
* [Serilog](https://github.com/serilog/serilog) &ndash; [Apache License 2.0](https://github.com/serilog/serilog/blob/dev/LICENSE)
