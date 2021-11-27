import { createServer } from 'node:net';

const server = createServer((socket) => {
    console.dir({
        localAddress: socket.localAddress,
        localPort: socket.localPort,
        remoteAddress: socket.remoteAddress,
        remoteFamily: socket.remoteFamily,
        remotePort: socket.remotePort,
    });

    socket.setNoDelay(true); //Disable TCP/IP buffering
    socket.write('Server payload!');

    //Listen to the client
    socket.on('data', (data) => console.log('Received:', data.toString()));
    socket.on('error', (err) => {
        console.error('Socket error', err);
    });
}).listen(3000, () => console.log('Server is started!'));

server.on('error', (err) => {
    console.error('Server error', err);
});



