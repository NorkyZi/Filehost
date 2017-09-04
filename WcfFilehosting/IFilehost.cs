using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace WcfFilehosting
{

    [ServiceContract]
    public interface IFilehost
    {
        [OperationContract]
        void sendFile(DTO file);

        [OperationContract]
        DTO getFile (string ind, long curByte);

        [OperationContract]
        string getFileInd(string fileName);
    }

    [DataContract]
    public class DTO
    {
        private string _name;
        private byte[] _data;
        private long _size;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [DataMember]
        public long Size
        {
            get { return _size; }
            set { _size = value; }
        }

    }
}
