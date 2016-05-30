using MessageGeneratorApp.DataModels;
using System;

namespace MessageGeneratorApp
{
    public class GeneratorEventArgs
    {
        public MessageData Data;

        public GeneratorStatus Status;
        
        public GeneratorEventArgs(MessageData data)
        {
            this.Data = data;
        }

        public GeneratorEventArgs(GeneratorStatus status)
        {
            this.Status = status;
        }
    }
}
