import net from 'node:net';
import { setTimeout as setTimeoutPromises } from 'node:timers/promises';

const socket = new net.Socket();

socket.on('data', data => {
    console.log('Received:', data.toString());
});

socket.connect({
    port: 3000,
    host: '127.0.0.1',
}, () => {
    socket.write('Client payload!');
});

await setTimeoutPromises(150);
socket.unref();
