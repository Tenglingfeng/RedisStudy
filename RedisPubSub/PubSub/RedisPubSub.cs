using StackExchange.Redis;
using System;

namespace RedisPubSub.PubSub
{
    /// <summary>
    /// Redis订阅与发布
    /// 1:订阅者
    /// 2:发布者
    /// 3:主题(事件)
    /// 4:主题消息
    /// </summary>
    public class RedisPubSub
    {
        //redis连接管理类
        public ConnectionMultiplexer ConnectionMultiplexer = null;

        public RedisPubSub()
        {
            ConnectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379");

        }

        /// <summary>
        /// 订阅者
        /// </summary>
        public void Sub(string messageTopic,Action<ChannelMessage> action)
        {
            //1: 获取订阅器

            var subScribe = ConnectionMultiplexer.GetSubscriber();

            //2:订阅消息
            ChannelMessageQueue channelMessageQueue = subScribe.Subscribe(messageTopic);
            
            /*3:处理消息
            channelMessageQueue.OnMessage(message =>
            {
                //3.1 获取消息
                string topicMessage = message.Message;

                //3.2 开始做业务逻辑

            });*/

            //封装
            channelMessageQueue.OnMessage(action);
        }

        /// <summary>
        /// 发布者
        /// </summary>
        /// <param name="messageTopic">主题消息</param>
        /// <param name="message">消息</param>
        public void Pub(string messageTopic, string message)
        {
            //1:获取发布器
            var pubScribe = ConnectionMultiplexer.GetSubscriber();

            //2:发布主题消息
            pubScribe.Publish(messageTopic, message);
        }
    }
}