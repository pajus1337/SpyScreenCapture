# SpyScreenCapture

## Overview
SpyScreenCapture is a preliminary implementation of a screen capture program designed to test the functionality and feasibility of a screen capturing utility over a network. This project is entirely educational, built to satisfy personal curiosity about network based applications and screen capturing techniques.

## Status
The code provided is in an initial phase. It has been fully tested and confirmed to work as intended. Future developments will depend on available time and motivation.

## Features
- Captures the screen to a byte array or file using Windows API.
- Runs discreetly in the background, minimizing distraction and visibility.
- Sends captured data to a server over TCP.
- Implements basic server functionality to receive and save captured screen data as a PNG file.
  
## Usage
The project is divided into client and server sections:
- The **Client Side** captures the screen and sends the data to a specified host.
- The **Server Side** receives data from the client and writes it to a file.

**Important**: To run the application, launch both the server script (Python) and the client application (C#) after setting up the correct host/IP addresses.

## Disclaimer
This application is for educational purposes only and is not intended for unauthorized use. Please ensure that all screen capturing and data transmission is conducted in accordance with laws and regulations.

## Get Started
1. Ensure you have Python installed for the server script and .NET for the C# client application.
2. Clone the repository.
3. Configure the IP addresses in both the client and server scripts.
4. Run the server script first, then the client application.

## Contributions
Contributions are welcome. If you have ideas for improvements or want to report bugs, please open an issue or submit a pull request.

## License
This project is open-source and available under the MIT License. See the LICENSE file for more details.
