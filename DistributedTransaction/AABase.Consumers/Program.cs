using AA.Log4Net;
using AA.ServiceBus;
using AABase.InitConfig;
using MassTransit;
using System;

namespace AABase.Consumers
{
    class Program
    {
        static void Main(string[] args)
        {
            InitConfig.Init(); //初始化 日志  数据map

            //消费者消费
            string rabbitMqUri = "rabbitmq://localhost:5672";
            string rabbitMqUserName = "you";
            string rabbitMqPassword = "you";
            
            var busControl = ServiceBusManager.Instance.UseRabbitMq(rabbitMqUri, rabbitMqUserName, rabbitMqPassword)
             .RegisterConsumer<SecurityServiceConsumer>(null)  //注册防伪码初始化消费者
             .Build();
            busControl.Start();

            Console.WriteLine("hi");
        }
    }


    public static class InitConfig
    {
        public static void Init()
        {
            Log4NetLogger.Use("log4net.config");
            FluentDBMapConf.Map();
        }
    }
}
