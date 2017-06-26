using System;
using Context;

namespace CluxeBot
{
    public abstract class CallbackAttr : Attribute
    {
        public abstract bool IsCorrect(string message);
    }

    public class StartsWithCallback : CallbackAttr
    {
        public string Start { get; }
        public StartsWithCallback(string start)
        {
            Start = start;
        }

        public override bool IsCorrect(string message)
        {
            return message.StartsWith(Start);
        }
    }

    public class MeaningActCallback : CallbackAttr
    {
        public string Act { get; }
        public MeaningActCallback(string act)
        {
            Act = act;
        }

        public override bool IsCorrect(string message)
        {
            return new Sentence(message).IsMeaningAct(Act);
        }
    }
}
