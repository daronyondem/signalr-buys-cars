# Project Overview

This repository contains two main projects:

## 1. Console Publisher
The `console-publisher` project is a console application that sends broadcast messages to a SignalR hub indefinitely at a specified frequency. This application can be restarted at any time, and all SignalR listeners will remain connected and continue to receive messages.

## 2. Web Listener
The `web-listener` project is a web application that receives messages from the SignalR hub and displays them on the screen. This ensures that users can see real-time updates as they are broadcasted by the `console-publisher`.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.