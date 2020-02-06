using System;

namespace  Match.API.V1.Dtos
{
    public class MessageForReturnDto
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTime MessageSent { get; set; }
        public string Content { get; set; }

        public MessageForReturnDto()
        {
            MessageSent = DateTime.Now;
        }
    }
}