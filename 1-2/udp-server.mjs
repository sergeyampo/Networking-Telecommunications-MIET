import dgram from 'node:dgram';

const server = dgram.createSocket('udp4');

server.on('message', (msg) => {
    console.log(msg.toString());
});

server.bind(3000, console.log('UDP server is up!'));
