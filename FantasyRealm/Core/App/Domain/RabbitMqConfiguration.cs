﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Domain
{
    public class RabbitMqConfiguration
    {
        public RabbitMqConfiguration() { }
        public string HostName { get; set; }

        public string Username { get; set; }

        public string VirtualHost { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string URL { get; set; }

        public bool EnableSSL { get; set; }

        public override string ToString()
        {
            return $"ConnectionConfig: HostName: {HostName} Username: {Username} Password: {Password} Port: {Port} URL: {URL} VirtualHost: {VirtualHost} EnableSSL: {EnableSSL}";
        }
    }
}
