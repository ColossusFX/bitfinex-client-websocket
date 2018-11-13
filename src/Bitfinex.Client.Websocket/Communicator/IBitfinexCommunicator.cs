﻿using System;
using System.Threading.Tasks;

namespace Bitfinex.Client.Websocket.Communicator
{
    public interface IBitfinexCommunicator : IDisposable
    {
        /// <summary>
        /// Stream with received message (raw format)
        /// </summary>
        IObservable<string> MessageReceived { get; }

        /// <summary>
        /// Stream for reconnection event (trigerred after the new connection) 
        /// </summary>
        IObservable<ReconnectionType> ReconnectionHappened { get; }

        /// <summary>
        /// Time range in ms, how long to wait before reconnecting if no message comes from server.
        /// Default 60000 ms (1 minute)
        /// </summary>
        int ReconnectTimeoutMs { get; set; }

        /// <summary>
        /// Time range in ms, how long to wait before reconnecting if last reconnection failed.
        /// Default 60000 ms (1 minute)
        /// </summary>
        int ErrorReconnectTimeoutMs { get; set; }

        /// <summary>
        /// Returns true if Start() method was called at least once. False if not started or disposed
        /// </summary>
        bool IsStarted { get; }

        /// <summary>
        /// Returns true if communicator is running and connected to the server
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Start listening to the stream on the background thread
        /// </summary>
        Task Start();

        /// <summary>
        /// Send message to the stream channel. 
        /// It inserts the message to the queue and actual sending is done on an other thread.
        /// </summary>
        /// <param name="message">Message to be sent</param>
        Task Send(string message);

        /// <summary>
        /// Send message to the stream channel. 
        /// It doesn't use a sending queue, 
        /// beware of issue while sending two messages in the exact same time 
        /// on the full .NET Framework platform
        /// </summary>
        /// <param name="message">Message to be sent</param>
        Task SendInstant(string message);

        /// <summary>
        /// Force reconnection. 
        /// Closes current websocket stream and perform a new connection to the server.
        /// </summary>
        Task Reconnect();
    }
}