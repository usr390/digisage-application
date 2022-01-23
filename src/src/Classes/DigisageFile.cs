using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Classes
{
    // class that abstracts the user's files.
    public class DigisageFile
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Filestream { get; set; }

        public DigisageFile()
        {
            Name = "";
            Filestream = null;
        }
    }
}
