﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using infrastructure.Events;
using infrastructure.Enums;

namespace Connection
{
    /// <summary>
    /// this class is a --SINGLETON-- aims to connect to ImageService server.
    /// Instantiated by all Models in Gui. 
    /// </summary>
    public class Client
    {
        #region members
        //single instance
        private static Client instance;
        private bool isConnectionAttemptDone;
        public bool isOn;
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter writer;
        #endregion

        #region properties

        public static Client Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Client();
                }
                return instance;
            }
        }
        #endregion

        #region events
        public event EventHandler<CommandRecievedEventArgs> CommandRecieved;
        #endregion
        /// <summary>
        /// constructor.
        /// </summary>
        private Client()
        {
            this.isConnectionAttemptDone = false;
            this.isOn = false;
        }

        /// <summary>
        /// initializes members and connects to server
        /// </summary>
        public bool Start()
        {
            if (this.isConnectionAttemptDone) { return isOn; }

            this.isConnectionAttemptDone = true;

            try
            {
                //Auto choose client socket (no params)
                client = new TcpClient();
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
                client.Connect(endPoint);
                stream = client.GetStream();
                reader = new BinaryReader(stream);
                writer = new BinaryWriter(stream);
            }
            catch (Exception e) { return false; }
            this.isOn = true;
            string rawData;
            CommandRecievedEventArgs commandArgs;
            new Task(() => {
                while (true)
                {
                    try
                    {
                        rawData = reader.ReadString();

                        commandArgs = JsonConvert.DeserializeObject<CommandRecievedEventArgs>(rawData);
                        CommandRecieved?.Invoke(this, commandArgs);
                    }
                    catch (Exception e) {; }
                }
            }).Start();
            return true;
        }
        /// <summary>
        /// sends command to server.
        /// </summary>
        /// <param name="args"></param>
        public void SendCommand(CommandRecievedEventArgs args)
        {
            try
            {
                writer.Write(JsonConvert.SerializeObject(args));
            }
            catch (Exception e) {; }
        }
    }
}
